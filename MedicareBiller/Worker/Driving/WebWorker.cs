using iTextSharp.text;
using iTextSharp.text.pdf;
using MedicareBiller.Worker.Reader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MedicareBiller.Worker.Driving
{
    class WebWorker
    {
        IWebDriver driver;
        PatientDiscriptor[] patients;

        public WebWorker(params PatientDiscriptor[] patients) {
            this.patients = patients;
            ChromeOptions co = new ChromeOptions();
            co.AddUserProfilePreference("download.default_directory", GlobalData.downloadLocation);
            co.AddUserProfilePreference("download.prompt_for_download", false);
            co.AddUserProfilePreference("disable-popup-blocking", "true");

            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),co,TimeSpan.FromSeconds(30));
            driver.Url = "https://www.payerlink.com/";
            driver.FindElement(By.XPath("/html/body[@class='login']/div[@id='dvWrapper']/div[@class='loginBox']/form[@id='form1']/table/tbody/tr[2]/td/input[@id='txtUserName']")).SendKeys(GlobalData.username);
            driver.FindElement(By.XPath("/html/body[@class='login']/div[@id='dvWrapper']/div[@class='loginBox']/form[@id='form1']/table/tbody/tr[4]/td/input[@id='txtPassword']")).SendKeys(GlobalData.password);
            driver.FindElement(By.XPath("/html/body[@class='login']/div[@id='dvWrapper']/div[@class='loginBox']/form[@id='form1']/table/tbody/tr[5]/td/input[@id='Button1']")).Click();
            driver.FindElement(By.Id("imgEligibility")).Click();
            //driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[7]/td[3]/input[@id='txtDate2']")).Clear();
            //driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[7]/td[3]/input[@id='txtDate2']")).SendKeys("12/31/2018");
        }

        public void work() {
            int y = 0;
            for (int x = 0; x < patients.Length; x++) {
                if (patients[x].name.IndexOf("-") != -1 || patients[x].surname.IndexOf("-") != -1)
                {
                    patients[x].elligibiltyState = PatientDiscriptor.ElligibiltyState.NotValid;
                    x++;
                    y++;
                }
                if (x-y == 0)
                {
                    File.Delete(GlobalData.downloadLocation + "report.pdf");
                    downloadAndSetEligibilty(patients[0], "report.pdf");
                    if (patients[0].elligibiltyState == PatientDiscriptor.ElligibiltyState.NotValid) {
                        y++;
                    }
                }
                else {
                    File.Delete(GlobalData.downloadLocation + "report (" + (x-y) + ").pdf");
                    downloadAndSetEligibilty(patients[x], "report ("+ (x - y) + ").pdf");
                    if (patients[x].elligibiltyState == PatientDiscriptor.ElligibiltyState.NotValid)
                    {
                        y++;
                    }
                }
            }
            driver.Close();
            GlobalData.doneWorking = true;
            end();
            Thread.CurrentThread.Abort();
        }

        private void downloadAndSetEligibilty(PatientDiscriptor patient, String predictedFileName) {
            // enter HICN
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[2]/td/input[@id='txtClaimNumber']")).Clear();
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[2]/td/input[@id='txtClaimNumber']")).SendKeys(patient.HICN);
            // enter last name
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[1]/input[@id='txtLName']")).Clear();
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[1]/input[@id='txtLName']")).SendKeys(patient.surname);
            // enter first name
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[2]/input[@id='txtFName']")).Clear();
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[2]/input[@id='txtFName']")).SendKeys(patient.name);
            // enter dob
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[3]/input[@id='txtDOB']")).Clear();
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[5]/td[3]/input[@id='txtDOB']")).SendKeys(patient.dateOfBirth);
            
            // click continue
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int count = 0;
            while (driver.WindowHandles.Count < 2 && count < 10)
            {
                js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[6]/div[@id='pngHeaderContainer']/div[@id='EligibilityPanel']/table[@class='tblElig']/tbody/tr[8]/td/input[@id='btnSave']")));
                count++;
                if (count == 10) {
                    patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.NotValid;
                    return;
                }
            }
            // switch tabs
            System.Threading.Thread.Sleep(1000);
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);

            // click download
            driver.FindElement(By.XPath("/html/body/form[@id='form1']/div[@class='btnContainer']/input[@id='btnSaveAsPDF']")).Click();
            System.Threading.Thread.Sleep(1000);
            patient.eligibilityForm = GlobalData.downloadLocation +"\\"+ predictedFileName;

            // close current tab and switch to original
            driver.Close();
            driver.SwitchTo().Window(tabs[0]);

            //set patients eligibility
            try
            {
                SetEligibilty(patient);
            }
            catch (Exception e) {
                patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.FailedToRead;
            }
        }

        private void SetEligibilty(PatientDiscriptor patient) {
            PdfReader pdf = new PdfReader(patient.eligibilityForm);
            if (pdf.NumberOfPages < 2)
            {
                patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.NotEligible;
            }
            else {
                String txt = PatientCreator.ReadPdfFile(patient.eligibilityForm);
                var result = Regex.Split(txt, "\r\n|\r|\n");
                int x;
                for (x = 0; x < result.Length; x++) {
                    if (result[x].IndexOf("Medical Plan") == 0) {
                        break;
                    }
                }
                foreach (String t in result) {
                    Console.WriteLine(t);
                }
                if (result[x + 1].IndexOf("No") == 0) {
                    patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.Medicare;
                    return;
                }


                for (x = 0; x < result.Length; x++)
                {
                    if (result[x].IndexOf("Enrollment Date:") == 0)
                    {
                        break;
                    }
                }
                if (result[x][((result[x].Length) - 1)] == ':')
                {
                    patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.HMO;
                }
                else {
                    patient.elligibiltyState = PatientDiscriptor.ElligibiltyState.Medicare;
                }
            }
        }

        private void end()
        {
            List<PatientDiscriptor> no = new List<PatientDiscriptor>();
            List<PatientDiscriptor> medicare = new List<PatientDiscriptor>();
            List<PatientDiscriptor> HMO = new List<PatientDiscriptor>();
            List<PatientDiscriptor> invalidName = new List<PatientDiscriptor>();
            List<PatientDiscriptor> failure = new List<PatientDiscriptor>();
            List<String> textfileLines = new List<String>();
            foreach (PatientDiscriptor patient in patients)
            {
                switch (patient.elligibiltyState)
                {
                    case PatientDiscriptor.ElligibiltyState.HMO:
                        HMO.Add(patient);
                        break;
                    case PatientDiscriptor.ElligibiltyState.Medicare:
                        medicare.Add(patient);
                        break;
                    case PatientDiscriptor.ElligibiltyState.NotEligible:
                        no.Add(patient);
                        break;
                    case PatientDiscriptor.ElligibiltyState.NotValid:
                        invalidName.Add(patient);
                        break;
                    case PatientDiscriptor.ElligibiltyState.FailedToRead:
                        failure.Add(patient);
                        break;
                }
            }

            String[] notEligible = new String[no.Count * 2];
            String[] medicareArr = new String[medicare.Count * 2];
            String[] HMOArr = new String[HMO.Count * 2];
            String[] invalid = new String[invalidName.Count * 2];
            String[] failed = new string[failure.Count * 2];
            int n = 0;
            textfileLines.Add("");
            textfileLines.Add("not eligible________________________________");
            for (int x = 0; x < notEligible.Length; x += 2)
            {
                notEligible[x] = no[n].superBill;
                notEligible[x + 1] = no[n].eligibilityForm;
                textfileLines.Add(no[n].ToString());
                n++;
            }
            n = 0;
            textfileLines.Add("");
            textfileLines.Add("medicare________________________________");
            for (int x = 0; x < medicareArr.Length; x += 2)
            {
                medicareArr[x] = medicare[n].superBill;
                medicareArr[x + 1] = medicare[n].eligibilityForm;
                textfileLines.Add(medicare[n].ToString());
                n++;
            }
            n = 0;
            textfileLines.Add("");
            textfileLines.Add("HMO________________________________");
            for (int x = 0; x < HMOArr.Length; x += 2)
            {
                HMOArr[x] = HMO[n].superBill;
                HMOArr[x + 1] = HMO[n].eligibilityForm;
                textfileLines.Add(HMO[n].ToString());
                n++;
            }
            n = 0;
            textfileLines.Add("");
            textfileLines.Add("Invalid Name or HICN was entered to much________________________________");
            for (int x = 0; x < invalid.Length; x += 2)
            {
                invalid[x] = invalidName[n].superBill;
                invalid[x + 1] = invalidName[n].eligibilityForm;
                textfileLines.Add(invalidName[n].ToString());
                n++;
            }
            String[] badData = null;
            if (GlobalData.badPatients != null)
            {
                n = 0;
                badData = new string[GlobalData.badPatients.Length * 2];
                for (int x = 0; x < badData.Length; x += 2)
                {
                    badData[x] = GlobalData.badPatients[n].superBill;
                    badData[x + 1] = GlobalData.badPatients[n].eligibilityForm;
                    n++;
                }
            }
            n = 0;
            textfileLines.Add("");
            textfileLines.Add("failure to read data________________________________");
            for (int x = 0; x < failed.Length; x += 2)
            {
                failed[x] = failure[n].superBill;
                failed[x + 1] = failure[n].eligibilityForm;
                textfileLines.Add(failure[n].ToString());
                n++;
            }
            int tLines = textfileLines.Count - 10;
            textfileLines.Add("");
            textfileLines.Add("Total patients" + tLines);
            //if (notEligible.Length > 0)
            //    MergeFiles(GlobalData.OutputLocation + "\\notEligible.pdf", notEligible);
            if (medicareArr.Length > 0)
                MergeFiles(GlobalData.OutputLocation + "\\medicare.pdf", medicareArr);
            if (HMOArr.Length > 0)
                MergeFiles(GlobalData.OutputLocation + "\\HMO.pdf", HMOArr);
            //if (invalid.Length > 0)
            //    MergeFiles(GlobalData.OutputLocation + "\\invalidNames.pdf", invalid);
            //if (badData != null && badData.Length > 0)
            //    MergeFiles(GlobalData.OutputLocation + "\\incorrectData.pdf", badData);
            if (failed.Length > 0)
                MergeFiles(GlobalData.OutputLocation + "\\failedToReadData.pdf", failed);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(GlobalData.OutputLocation, "overview list.txt")))
            {
                foreach (string line in textfileLines)
                    outputFile.WriteLine(line);
            }
        }

        public static void MergeFiles(string destinationFile, string[] sourceFiles)
        {

            try
            {
                int f = 0;
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(sourceFiles[f]);
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                //Console.WriteLine("There are " + n + " pages in the original file.");
                // step 1: creation of a document-object
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                // step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
                // step 3: we open the document
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int rotation;
                // step 4: we add content
                while (f < sourceFiles.Length)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                        //Console.WriteLine("Processed page " + i);
                    }
                    f++;
                    if (f < sourceFiles.Length)
                    {
                        reader = new PdfReader(sourceFiles[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages;
                        //Console.WriteLine("There are " + n + " pages in the original file.");
                    }
                }
                // step 5: we close the document
                document.Close();
            }
            catch (Exception e)
            {
                string strOb = e.Message;
            }
        }

        public static int CountPageNo(string strFileName)
        {
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(strFileName);
            // we retrieve the total number of pages
            return reader.NumberOfPages;
        }
    }
}


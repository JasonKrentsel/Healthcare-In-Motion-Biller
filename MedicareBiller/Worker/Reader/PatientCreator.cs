using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace MedicareBiller.Worker.Reader
{
    class PatientCreator
    {
        public PatientCreator()
        {

        }

        static public PatientDiscriptor GetPatientData(String fileDirectory)
        {
            PatientDiscriptor patient = new PatientDiscriptor();
            patient.superBill = fileDirectory;

            String text = ReadPdfFile(fileDirectory);
            try
            {
                patient.name = getName(text).Trim();
                patient.surname = getSurName(text).Trim();
                patient.dateOfBirth = getDateOfBirth(text).Trim();
                patient.HICN = getHICN(text).Trim();
                patient.serviceDate = getServiceDate(text).Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine(fileDirectory);
                Console.WriteLine(patient.ToString());
            }

            return patient;
        }

        static public String ReadPdfFile(string fileName)
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();
            }
            else
            {
                throw new Exception("File not found");
            }
            return text.ToString();
        }

        static private String getServiceDate(String document)
        {
            var result = Regex.Split(document, "\r\n|\r|\n");
            int x;
            for (x = 0; x < result.Length; x++)
            {
                if (result[x].IndexOf("SERVICE DATE:") == 0)
                {
                    break;
                }
            }
            String line = result[x];
            String sd = "";
            int i = 14;
            while (true)
            {
                if (line[i] != ' ')
                    sd += line[i];
                else
                    break;
                i++;
            }
            return sd;
        }

        static private String getName(String document)
        {
            var result = Regex.Split(document, "\r\n|\r|\n");
            int x;
            for (x = 0; x < result.Length; x++)
            {
                if (result[x].IndexOf("PATIENT NAME:") == 0)
                {
                    break;
                }
            }
            String line = result[x];
            String name = "";
            for (int i = line.IndexOf("GENDER:") - 2; line[i] != ' ' && line[i] != ','; i--)
            {
                name = line[i] + name;
            }
            return name;
        }

        static private String getSurName(String document)
        {
            var result = Regex.Split(document, "\r\n|\r|\n");
            int x;
            for (x = 0; x < result.Length; x++)
            {
                if (result[x].IndexOf("PATIENT NAME:") == 0)
                {
                    break;
                }
            }
            String line = result[x];
            String surname = "";
            for (int i = line.IndexOf(",") - 1; line[i] != ' '; i--)
            {
                surname = line[i] + surname;
            }
            return surname;
        }

        static private String getDateOfBirth(String document)
        {
            var result = Regex.Split(document, "\r\n|\r|\n");
            int x;
            for (x = 0; x < result.Length; x++)
            {
                if (result[x].IndexOf("DATE OF BIRTH:") == 0)
                {
                    break;
                }
            }
            String line = result[x];
            String text = "";
            for (int i = line.IndexOf("ROOM") - 2; line[i] != ' '; i--)
            {
                text = line[i] + text;
            }
            return text;
        }

        static private String getHICN(String document)
        {
            var result = Regex.Split(document, "\r\n|\r|\n");
            int x;
            for (x = 0; x < result.Length; x++)
            {
                if (result[x].IndexOf("(ie. Medicare/HMO)") == 0)
                {
                    x++;
                    break;
                }
            }
            String line = result[x];
            String text = "";
            for (int i = line.Length - 1; line[i] != ' '; i--)
            {
                text = line[i] + text;
            }
            return text;
        }
    }
}
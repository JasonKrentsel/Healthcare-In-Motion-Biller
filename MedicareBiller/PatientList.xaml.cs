using MedicareBiller.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicareBiller
{
    /// <summary>
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : UserControl
    {
        PatientDiscriptor[] patientInfo;
        public PatientBox[] boxes;
        public PatientList(params PatientDiscriptor[] patients)
        {
            patientInfo = patients;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            boxes = new PatientBox[patientInfo.Length];
            for (int x = 0; x < patientInfo.Length; x++) {
                boxes[x] = new PatientBox(patientInfo[x]);
                aListBox.Items.Add(boxes[x]);
            }
        }
    }

    public class PatientBox : GroupBox {
        private CheckBox isGood;
        public PatientDiscriptor patientData;

        public PatientBox(PatientDiscriptor patient) {
            patientData = patient;
            isGood = new CheckBox();
            isGood.IsChecked = true;
            isGood.Content = "Data is Correct";
            this.Header = "";
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(isGood);

            Label info = new Label();
            info.Content = "Name: " + patient.name + "     Surname: " + patient.surname + "     Birth Date: " + patient.dateOfBirth + "     HICN: " + patient.HICN;

            mainPanel.Children.Add(info);
            this.AddChild(mainPanel);
        }

        public Boolean DataIsGood() {
            return (Boolean)isGood.IsChecked;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Care_Center_Management_System_Task
{
    public partial class Patients : Form
    {
        Functions Con;
        public Patients()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPatients();
        }

        private void ShowPatients()
        {
            String Query = "Select * from PatientTable";
            PatientListGV.DataSource = Con.GetData(Query);
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if(PatientNameTB.Text == "" || PatientGenderCB.SelectedIndex == -1 || PatientPhoneTB.Text == "" || PatientAddressTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = PatientNameTB.Text;
                String gender = PatientGenderCB.SelectedItem.ToString();
                String birthDate = PatientBirthDateDTP.Value.Date.ToString();
                String phone = PatientPhoneTB.Text;
                String address = PatientAddressTB.Text;
                String Query = "insert into PatientTable values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, name, gender, birthDate, phone, address);
                Con.SetData(Query);
                ShowPatients();
                MessageBox.Show("Patient Added!!!");
            }
        }
    }
}

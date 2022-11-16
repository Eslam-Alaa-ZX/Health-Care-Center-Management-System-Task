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
            if (PatientNameTB.Text == "" || PatientGenderCB.SelectedIndex == -1 || PatientPhoneTB.Text == "" || PatientAddressTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = PatientNameTB.Text;
                String gender = PatientGenderCB.SelectedItem.ToString();
                String birthDate = PatientBirthDateDTP.Value.Date.ToString();
                //birthDate = "CAST('"+birthDate+"', 0)";
                String phone = PatientPhoneTB.Text;
                String address = PatientAddressTB.Text;
                String Query = "insert into PatientTable values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, name, gender, birthDate, phone, address);
                Con.SetData(Query);
                ShowPatients();
                MessageBox.Show("Patient Added!!!");
            }
        }

        int key = 0;

        private void PatientListGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientNameTB.Text = PatientListGV.SelectedRows[0].Cells[1].Value.ToString();
            PatientGenderCB.SelectedItem = PatientListGV.SelectedRows[0].Cells[2].Value.ToString();
            PatientBirthDateDTP.Text = PatientListGV.SelectedRows[0].Cells[3].Value.ToString();
            PatientPhoneTB.Text = PatientListGV.SelectedRows[0].Cells[4].Value.ToString();
            PatientAddressTB.Text = PatientListGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PatientNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientListGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}

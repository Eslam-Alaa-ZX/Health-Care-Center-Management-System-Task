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
    public partial class Diagnosts : Form
    {
        Functions Con;
        int key = 0;
        public Diagnosts()
        {
            InitializeComponent();
            Con = new Functions();
            //ShowDiagnosis();
            GetPatients();
            GetTests();
        }

        private void ShowDiagnosis()
        {
            String Query = "Select * from DiagnosisTable";
            DiagList.DataSource = Con.GetData(Query);
        }

        private void GetPatients()
        {
            string Query = "Select * from PatientTable";
            PatientDiagCB.DisplayMember = Con.GetData(Query).Columns["PatientName"].ToString();
            PatientDiagCB.ValueMember = Con.GetData(Query).Columns["PatientId"].ToString();
            PatientDiagCB.DataSource = Con.GetData(Query);
        }

        private void GetTests()
        {
            string Query = "Select * from TestTable";
            TestDiagCB.DisplayMember = Con.GetData(Query).Columns["TestName"].ToString();
            TestDiagCB.ValueMember = Con.GetData(Query).Columns["TestId"].ToString();
            TestDiagCB.DataSource = Con.GetData(Query);
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {

        }
    }
}

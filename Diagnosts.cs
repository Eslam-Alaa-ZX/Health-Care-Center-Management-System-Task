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
            ShowDiagnosis();
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

        private void GetCost()
        {
            string Query = "Select * from TestTable where TestId = {0}";
            Query = string.Format(Query, TestDiagCB.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                CostDiagTB.Text = dr["TestCost"].ToString();
            }
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (PatientDiagCB.SelectedIndex == -1 || CostDiagTB.Text == "" || ResultDiagTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                int name = Convert.ToInt32(TestDiagCB.SelectedValue.ToString());
                String date = DateDiag.Value.Date.ToString();
                int test = Convert.ToInt32(TestDiagCB.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostDiagTB.Text);
                String reslt = ResultDiagTB.Text;
                String Query = "insert into DiagnosisTable values({0},'{1}',{2},{3},'{4}')";
                Query = string.Format(Query, name, date, test, cost, reslt);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Added!!!");
            }
        }

        private void TestDiagCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        private void Clear()
        {
            PatientDiagCB.SelectedIndex = -1;
            TestDiagCB.SelectedIndex = -1;
            CostDiagTB.Text = "";
            ResultDiagTB.Text = "";
        }
    }
}

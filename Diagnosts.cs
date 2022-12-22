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
                int name = Convert.ToInt32(PatientDiagCB.SelectedValue.ToString());
                String date = DateDiag.Value.Date.ToShortDateString();
                int test = Convert.ToInt32(TestDiagCB.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostDiagTB.Text);
                String reslt = ResultDiagTB.Text;
                String Query = "insert into DiagnosisTable values('{0}',{1},{2},{3},'{4}')";
                Query = string.Format(Query, date, name, test, cost, reslt);
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

        private void DiagList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateDiag.Text = DiagList.SelectedRows[0].Cells[1].Value.ToString();
            PatientDiagCB.SelectedItem = DiagList.SelectedRows[0].Cells[2].Value.ToString();
            TestDiagCB.SelectedItem = DiagList.SelectedRows[0].Cells[3].Value.ToString();
            CostDiagTB.Text = DiagList.SelectedRows[0].Cells[4].Value.ToString();
            ResultDiagTB.Text = DiagList.SelectedRows[0].Cells[5].Value.ToString();
            if (CostDiagTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DiagList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String Query = "Delete from DiagnosisTable  where DiagId = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Deleted!!!");
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (PatientDiagCB.SelectedIndex == -1 || CostDiagTB.Text == "" || ResultDiagTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                int name = Convert.ToInt32(PatientDiagCB.SelectedValue.ToString());
                String date = DateDiag.Value.Date.ToShortDateString();
                int test = Convert.ToInt32(TestDiagCB.SelectedValue.ToString());
                int cost = Convert.ToInt32(CostDiagTB.Text);
                String reslt = ResultDiagTB.Text;
                String Query = "Update DiagnosisTable set DiagDate = {0},Patient = '{1}',Test = {2},Cost = {3},Result = '{4}' where DiagId = {5}";
                Query = string.Format(Query, date, name, test, cost, reslt, key);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Updated!!!");
            }
        }

        private void DateDiag_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login page = new Login();
            page.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patients page = new Patients();
            page.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests page = new Tests();
            page.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Diagnosts page = new Diagnosts();
            page.Show();
            this.Hide();
        }

        private void DiagList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DateDiag.Text = DiagList.SelectedRows[0].Cells[1].Value.ToString();
            PatientDiagCB.SelectedValue = DiagList.SelectedRows[0].Cells[2].Value.ToString();
            TestDiagCB.SelectedValue = DiagList.SelectedRows[0].Cells[3].Value.ToString();
            CostDiagTB.Text = DiagList.SelectedRows[0].Cells[4].Value.ToString();
            ResultDiagTB.Text = DiagList.SelectedRows[0].Cells[5].Value.ToString();
            if (CostDiagTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DiagList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}

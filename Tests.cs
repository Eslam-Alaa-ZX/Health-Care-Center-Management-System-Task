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
    public partial class Tests : Form
    {
        Functions Con;
        int key = 0;
        public Tests()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTests();
        }

        private void ShowTests()
        {
            String Query = "Select * from TestTable";
            TestListGV.DataSource = Con.GetData(Query);
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (TestNameTB.Text == "" || TestCostTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                String Query = "insert into TestTable values('{0}',{1})";
                Query = string.Format(Query, name, cost);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Added!!!");
            }
        }

        private void Clear()
        {
            TestNameTB.Text = "";
            TestCostTB.Text = "";
        }

        private void TestListGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            if (TestNameTB.Text == "" || TestCostTB.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                String Query = "Update TestTable set TestName = '{0}',TestCost = {1} where TestId = {2}";
                Query = string.Format(Query, name, cost,key);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Updated!!!");
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Test!!!");
            }
            else
            {
                String name = TestNameTB.Text;
                int cost = Convert.ToInt32(TestCostTB.Text);
                String Query = "Delete from TestTable where TestId = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowTests();
                Clear();
                MessageBox.Show("Test Deleted!!!");
            }
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

        private void TestListGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TestNameTB.Text = TestListGV.SelectedRows[0].Cells[1].Value.ToString();
            TestCostTB.Text = TestListGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TestNameTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestListGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void TestListGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

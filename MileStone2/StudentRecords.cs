using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MileStone2
{
    public partial class StudentRecords : Form
    {
        DataHandler myDataHandler = new DataHandler();
        private object txtStudentID;

        public StudentRecords()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login test = new Login();
            test.Show();
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ModuleRecords test = new ModuleRecords();
            test.Show();
            Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StudentRecords_Load(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            myDataHandler.Update(int.Parse(txtStudentID.Text), txtName.Text, txtSurname.Text);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            myDataHandler.DeleteStudent(int.Parse(txtStudentID.Text));
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchValue = txtSearch.Text;

            dgvStudentRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = @"DataSource=.;Initial Catalog=Belgiumcampus;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(connect);
                conn.Open();
                string query = @"Select * from tbl Student";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudentRecords.DataSource = dt;
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void txtNameUploadorDelete_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

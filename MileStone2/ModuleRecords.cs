using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MileStone2
{
    public partial class ModuleRecords : Form
    {
        DataHandler dh = new DataHandler();

        public ModuleRecords()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentRecords test = new StudentRecords();
            test.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.InsertUser(txtmodulecodeadd.Text, txtmodulenameadd.Text, txtmoduledesadd.Text, txtmoduleresadd.Text);
            txtmodulecodeadd.Text = "";
            txtmodulenameadd.Text = "";
            txtmoduledesadd.Text = "";
            txtmoduleresadd.Text = "";
        }

        private void ModuleRecords_Load(object sender, EventArgs e)
        {
            dh.DBAccess();
            Users u = new Users();

            BindingSource bs = new BindingSource();
            bs.DataSource = u.GetUsers();
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int word;
                listBox1.Items.Clear();
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                word = Convert.ToInt32(row.Cells["userId"].Value.ToString());

                mod p = new mod();
                foreach (var item in p.GetPets(word))
                {
                    
                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            MessageBox.Show(u.DeleteData(txtmodulecodedel.Text));
            txtmodulecodedel.Text = "";
            txtmodulenamedel.Text = "";
            txtmoduledesdel.Text = "";
            txtmodulereddel.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            txtmodulecodedel.Text = "";
            txtmodulenamedel.Text = "";
            txtmoduledesdel.Text = "";
            txtmodulereddel.Text = "";
            if (txtmodulecodedel.Text != "" && txtmodulenamedel.Text != "")
            {
                dh.updateName(Convert.ToInt32(txtmodulecodedel.Text), txtmodulenamedel.Text);

            }
            else if (txtmodulecodedel.Text != "" && txtmoduledesdel.Text != "")
            {
                dh.updateSurname(Convert.ToInt32(txtmodulecodedel.Text), txtmoduledesdel.Text);
            }
            else if (txtmodulecodedel.Text != "" && txtmoduledesdel.Text != "" && txtmodulecodedel.Text != "")
            {
                dh.updateAll(Convert.ToInt32(txtmodulecodedel.Text), txtmodulecodedel.Text, txtmoduledesdel.Text);
            }
        }
    }
}

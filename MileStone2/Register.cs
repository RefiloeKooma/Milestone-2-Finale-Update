using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MileStone2
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login test = new Login();
            test.Show();
            Visible = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Log.txt", true))
            {
                writer.WriteLine(txtUsername.Text + " " + txtPassword.Text);

                writer.Close();

                Login test = new Login();
                test.Show();
                Visible = false;

            }
        }
    }
}

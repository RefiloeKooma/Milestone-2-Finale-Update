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
    public partial class Login : Form
    {

        private readonly List<string> UserList = new List<string>();

        private readonly List<string> PasswordList = new List<string>();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Log.txt");

            string line;

            while ((line = sr.ReadLine()) != null)
            {

                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                UserList.Add(components[0]);

                PasswordList.Add(components[1]);
            }

            sr.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register test = new Register();
            test.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (UserList.Contains(textBox1.Text) && PasswordList.Contains(textBox2.Text) && PasswordList[UserList.IndexOf(textBox1.Text)] == textBox2.Text)
            {
                // Create the second form
                StudentRecords f2 = new StudentRecords();

                // Show the second form
                f2.ShowDialog();
            }
            else
                // Show the error message
                MessageBox.Show("The username and/or password is incorrect.");
        }
    }
}

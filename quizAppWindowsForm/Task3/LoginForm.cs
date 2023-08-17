using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3.Models;

namespace Task3
{
    public partial class LoginForm : Form
    {
        QuizDbContext _db = new QuizDbContext();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var UserName = textBox1.Text;
            var Password = textBox2.Text;
            if(UserName == "test" && Password == "123") {

                this.Hide();

                var us = new Form1(_db);
                us.Show();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect. Please re-enter ");
            }

        }

    }
}

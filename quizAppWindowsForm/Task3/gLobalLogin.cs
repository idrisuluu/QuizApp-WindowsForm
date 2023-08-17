using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3.Models;

namespace Task3
{
    public partial class gLobalLogin : Form
    {
        QuizDbContext _db = new QuizDbContext();

        public gLobalLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            this.Hide();
            var us = new LoginForm();
            us.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.Hide();
            var us = new UserAnswer(_db);
            us.Show();
        }
    }
}

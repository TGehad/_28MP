using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _28MP
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }
        private void mainMenu_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            

        }
        private void creatbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new create();
            f2.ShowDialog();
            this.Close();     
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new add();
            f2.ShowDialog();
            this.Close();
        }
        private void ordersbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new orders();
            f2.ShowDialog();
            this.Close();
        }
        private void viewbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new view();
            f2.ShowDialog();
            this.Close();
        }
        private void signoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new login();
            f2.ShowDialog();
            this.Close();
        }
    }
}

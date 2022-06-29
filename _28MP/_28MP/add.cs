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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        private void add_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            //WindowState = FormWindowState.Maximized;
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new mainMenu();
            f2.ShowDialog();
            this.Close();
        }
        private void complainbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new complaine();
            f2.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new pictures();
            f2.ShowDialog();
            this.Close();
        }

    }
}

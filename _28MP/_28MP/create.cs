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
    public partial class create : Form
    {
        public create()
        {
            InitializeComponent();
        }
        private void create_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            
        }
        private void complainbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new complain();
            f2.ShowDialog();
            this.Close();
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new mainMenu();
            f2.ShowDialog();
            this.Close();
        }
    }
}

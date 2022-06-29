using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace _28MP
{
    
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        // getting the application current path

        string filePath =  "save\\temp\\users.txt";
        

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" & textBox1.Text.Trim() != " ")
            {
                StreamReader sr = new StreamReader(filePath);
                string line = "";
                bool found = false;

                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] arrdata = line.Split(';');
                        if (textBox1.Text.Trim() == arrdata[0])
                        {
                            if (textBox2.Text.Trim() == arrdata[1])
                            {
                                LoginInfo.UserName = textBox1.Text;
                                this.Hide();
                                Form f2 = new mainMenu();
                                f2.ShowDialog();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("تأكد من الرقم السري");

                            }
                            found = true;
                        }

                    }

                } while (line != null);
                sr.Close();

                if (!found)
                {
                    MessageBox.Show("تأكد من أسم المستخدم");
                }
            }
            else
            {
                MessageBox.Show("أدخل أسم المستخدم");
                textBox1.Focus();
            }                
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
           
        }

      

     
        
        
    }
}

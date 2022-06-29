using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace _28MP
{
    public partial class view : Form
    {
        public view()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new mainMenu();
            f2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "C:\\save\\" + textBox1.Text + ".docx";
            //System.Diagnostics.Process.Start(@"C:\\save\\"+path+".docx");

            if (File.Exists(path))
            {

                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;
                Word.Document myWordDoc = wordApp.Documents.Open(@path, ReadOnly: true);
                myWordDoc.Activate();

            }
            else
            {
                string message = "المحضر غير موجود";
                string title = "خطأ";
                MessageBox.Show(message, title);
            }
        }

        private void view_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            WindowState = FormWindowState.Maximized;
        }
    }
}

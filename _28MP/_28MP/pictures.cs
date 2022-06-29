using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace _28MP
{
    public partial class pictures : Form
    {
        public pictures()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new add();
            f2.ShowDialog();
            this.Close();
        }

        private void addimage(object filepath, string image)
        {
            
            Word._Application wordApp = new Word.Application();
            object missing = Missing.Value;
            object readOnly = false;
            object isVisible = false;
            wordApp.Visible = false;
            Word.Document myWordDoc = null;
            object pageBreak = Word.WdBreakType.wdSectionBreakNextPage;

            if (File.Exists((string)filepath))
            {
                

                myWordDoc = wordApp.Documents.Open(ref filepath, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref isVisible,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                wordApp.ActiveDocument.Characters.Last.Select();
                wordApp.Selection.Collapse();               
                wordApp.Selection.InsertBreak(ref pageBreak);
                //optional
                var shape = wordApp.Selection.InlineShapes.AddPicture(image);
                shape.Width = 550;
                shape.Height = 720;

            }
            else
            {
                MessageBox.Show("المحضر غير موجود");
            }
           

            ((Microsoft.Office.Interop.Word._Document)myWordDoc).Close(ref missing, ref missing, ref missing);
            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref missing, ref missing, ref missing);

        }

        private void addpic_Click(object sender, EventArgs e)
        {

            string Cnumb = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
            string document = @"save\" + Cnumb + ".docx";
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox1.Text == " " | textBox2.Text == " " | textBox3.Text == " ")
            {
                MessageBox.Show("تأكد من رقم المحضر !");

            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All files (*.*)|*.*";  
                ofd.Multiselect = true;
                ofd.InitialDirectory = @"d:\";
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    // Read the files
                    string[] filepaths = ofd.FileNames;
                    for (int i = 0; i < filepaths.Length; i++)
                    {
                        try
                        {
                            string imgpath = filepaths[i];
                            addimage(document, imgpath);


                        }
                        catch
                        {
                            // Could not load the image - probably related to Windows file system permissions.
                            MessageBox.Show("Cannot display the image");
                        }

                    }

                    MessageBox.Show("تمت الإضافة!");

                }

            }
        }

        private void pictures_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            WindowState = FormWindowState.Maximized;
        }

    }



}

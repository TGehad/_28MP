using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace _28MP
{
    public partial class complaine : Form
    {
        public complaine()
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

        private void complaine_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
            WindowState = FormWindowState.Maximized;
            object missing = Missing.Value;

            if (Process.GetProcessesByName("winword").Count() > 0)
            {
                Word.Application wordInstance = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");

                foreach (Word.Document doc in wordInstance.Documents)
                {
                    if (doc.Name == "complaine.docx")//the main file need to close too
                    {
                        ((Microsoft.Office.Interop.Word._Document)doc).Close(ref missing, ref missing, ref missing);

                        break;
                    }
                }
            }
        }

        private void increasebtn_Click(object sender, EventArgs e)
        {
            if (textBox24.Visible == true)
            {
                textBox25.Visible = true;
            }
            else
            {
                textBox24.Visible = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox16.Visible == true)
            {
                textBox16.Visible = false;
            }
            else { textBox16.Visible = true; }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox17.Visible == true)
            {
                textBox17.Visible = false;
            }
            else { textBox17.Visible = true; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox18.Visible == true)
            {
                textBox18.Visible = false;
            }
            else { textBox18.Visible = true; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox21.Visible == true)
            {
                textBox21.Visible = false;
            }
            else { textBox21.Visible = true; }
        }

        //delete unchecked questions
        public void cleanBookmark(Word.Document currentDocument, string bookmark)
        {
            var start = currentDocument.Bookmarks[bookmark].Start;
            var end = currentDocument.Bookmarks[bookmark].End;
            Word.Range range = currentDocument.Range(start, end);
            range.Delete();

        }

        //Find and Replace Method
        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = false;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText, ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundLike, ref nmatchAllforms,
            ref forward, ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza, ref matchControl);
            //find inside header
            foreach (Word.Section section in wordApp.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Find.Execute(ref ToFindText, ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundLike, ref nmatchAllforms,
                ref forward, ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza, ref matchControl);
            }


        }

        //Creeate the Doc Method
        private void CreateWordDocument(object filename, object SaveAs)
        {

            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;
                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing,
                                                 ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myWordDoc.Activate();
                //find and replace
                string Cnumb = textBox1.Text + "/" + textBox2.Text + "/" + textBox3.Text;
                /////////////////////////////////data
                this.FindAndReplace(wordApp, "<Cnum>", Cnumb);
                this.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                this.FindAndReplace(wordApp, "<clock>", DateTime.Now.ToShortTimeString());
                this.FindAndReplace(wordApp, "<Dwriter>", textBox4.Text);
                this.FindAndReplace(wordApp, "<writer>", textBox5.Text);
                this.FindAndReplace(wordApp, "<name>", textBox6.Text);
                this.FindAndReplace(wordApp, "<address>", textBox7.Text);
                this.FindAndReplace(wordApp, "<age>", textBox8.Text);
                this.FindAndReplace(wordApp, "<job>", textBox9.Text);
                this.FindAndReplace(wordApp, "<mobile>", textBox10.Text);
                this.FindAndReplace(wordApp, "<Nid>", textBox11.Text);

                ////////////////////////////////////answers

                this.FindAndReplace(wordApp, "<Ans1>", textBox12.Text);
                this.FindAndReplace(wordApp, "<Ans2>", textBox13.Text);
                this.FindAndReplace(wordApp, "<Ans21>", textBox24.Text);
                this.FindAndReplace(wordApp, "<Ans22>", textBox25.Text);
                this.FindAndReplace(wordApp, "<Ans3>", textBox14.Text);
                this.FindAndReplace(wordApp, "<Ans4>", textBox15.Text);
                this.FindAndReplace(wordApp, "<Ans5>", textBox16.Text);
                this.FindAndReplace(wordApp, "<Ans6>", textBox17.Text);
                this.FindAndReplace(wordApp, "<Ans7>", textBox18.Text);
                this.FindAndReplace(wordApp, "<Ans8>", textBox19.Text);
                this.FindAndReplace(wordApp, "<Ans9>", textBox20.Text);
                this.FindAndReplace(wordApp, "<Ans10>", textBox21.Text);
                this.FindAndReplace(wordApp, "<Ans11>", textBox22.Text);
                this.FindAndReplace(wordApp, "<Ans12>", textBox23.Text);


                //delete questions
                if (checkBox1.Checked == false)
                {
                    string bookmark = "bookmark1";
                    cleanBookmark(myWordDoc, bookmark);

                }
                if (checkBox2.Checked == false)
                {
                    string bookmark = "bookmark2";
                    cleanBookmark(myWordDoc, bookmark);

                }
                if (checkBox3.Checked == false)
                {
                    string bookmark = "bookmark3";
                    cleanBookmark(myWordDoc, bookmark);

                }
                if (checkBox4.Checked == false)
                {
                    string bookmark = "bookmark4";
                    cleanBookmark(myWordDoc, bookmark);

                }

                //end of delete questions                  


                // male & female
                if (radioButton1.Checked)
                {
                    this.FindAndReplace(wordApp, "<gender1>", "أقواله");
                    this.FindAndReplace(wordApp, "<title>", "المدعو");
                    this.FindAndReplace(wordApp, "<gender2>", "أنه");
                    this.FindAndReplace(wordApp, "<gender3>", "حقه");
                    this.FindAndReplace(wordApp, "<gender4>", "سؤاله");
                    this.FindAndReplace(wordApp, "<gender5>", "فأجاب");
                    this.FindAndReplace(wordApp, "<gender6>", "أفهمناه");
                }

                if (radioButton2.Checked)
                {
                    this.FindAndReplace(wordApp, "<gender1>", "أقولها");
                    this.FindAndReplace(wordApp, "<title>", "المدعوة");
                    this.FindAndReplace(wordApp, "<gender2>", "أنها");
                    this.FindAndReplace(wordApp, "<gender3>", "حقها");
                    this.FindAndReplace(wordApp, "<gender4>", "سؤالها");
                    this.FindAndReplace(wordApp, "<gender5>", "فأجابت");
                    this.FindAndReplace(wordApp, "<gender6>", "أفهمناها");
                }

                // end of male & female

                //region
                if (textBox2.Text == "101")
                {
                    this.FindAndReplace(wordApp, "<region>", "شرق");
                }
                if (textBox2.Text == "102")
                {
                    this.FindAndReplace(wordApp, "<region>", "شمال");
                }
                if (textBox2.Text == "103")
                {
                    this.FindAndReplace(wordApp, "<region>", "غرب");
                }

                //end of region
            }

            else
            {
                MessageBox.Show("التمبلت غير موجود");
            }

            //Save as
            if (File.Exists((string)SaveAs))
            {
                MessageBox.Show("تم الإنشاء من قبل");
            }
            else
            {
                myWordDoc.SaveAs(ref SaveAs, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);


                ((Microsoft.Office.Interop.Word._Document)myWordDoc).Close(ref missing, ref missing, ref missing);
                ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref missing, ref missing, ref missing);
            }



        }
        private void OpenWordDocument(object filename)
        {
            Word._Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                wordApp.Visible = true;
                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                myWordDoc.Activate();
                WindowState = FormWindowState.Minimized;
            }

            else
            {
                MessageBox.Show("لم يتم الإنشاء!");
            }

        }
        private void Merge(string document1, string document2)
        {
            object missing = Missing.Value;
            object pageBreak = Word.WdBreakType.wdPageBreak;
            object readOnly = false;
            object isVisible = false;
            object fristfile = document1;
            string seconed = document2;
            
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            Word.Document myWordDoc = wordApp.Documents.Open(ref fristfile, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing,
                                              ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);

            // Word.Document myWordDoc = wordApp.Documents.Add(ref fristfile, ref missing, ref missing, ref missing);
            myWordDoc.Activate();
           
            // move the selection to the end of file1
            wordApp.ActiveDocument.Characters.Last.Select();
            wordApp.Selection.Collapse();

            // insert the seconed file  
            Word.Selection selection = wordApp.Selection;

            selection.InsertBreak(ref pageBreak);

            selection.InsertFile(seconed, ref missing, ref missing, ref missing, ref missing);


            ((Microsoft.Office.Interop.Word._Document)myWordDoc).Close(ref missing, ref missing, ref missing);
            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref missing, ref missing, ref missing);
            File.Delete(document2);

        }


        private void addbtn_Click(object sender, EventArgs e)
        {

            string Cnumb = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
            string document1 = @"C:\save\" + Cnumb + ".docx";
            string document2 = @"C:\save\" + Cnumb + "1.docx";

            CreateWordDocument(@"C:\save\temp\complaine.docx", document2);

            //if file exist
            if (File.Exists((string)document1))
            {
                Merge(document1, document2);
                MessageBox.Show("تمت الإضافة!");
            }
            else
            {

                MessageBox.Show("تم الإنشاء!");
            }

        }

        private void openbtn_Click(object sender, EventArgs e)
        {
            string Cnumb = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
            OpenWordDocument(@"C:\save\" + Cnumb + ".docx");
        }

        private void numbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

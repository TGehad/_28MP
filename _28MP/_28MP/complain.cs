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
using System.Diagnostics;
namespace _28MP
{
    public partial class complain : Form
    {
        public complain()
        {
            InitializeComponent();
        }
        object missing = Missing.Value;

        private void complain_Load(object sender, EventArgs e)
        {
            
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //WindowState = FormWindowState.Maximized;
            if (Process.GetProcessesByName("winword").Count() > 0)
            {
                Word.Application wordInstance = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");

                foreach (Word.Document doc in wordInstance.Documents)
                {
                    if (doc.Name == "complain.docx")
                    {
                        ((Microsoft.Office.Interop.Word._Document)doc).Close(ref missing, ref missing, ref missing);

                        break;
                    }
                }
            }

        }

        //delete unchecked questions
        private void cleanBookmark(Word.Document currentDocument, string bookmark)
        {
            var start = currentDocument.Bookmarks[bookmark].Start;
            var end = currentDocument.Bookmarks[bookmark].End;
            Word.Range range = currentDocument.Range(start, end);
            range.Delete();

        }
        private void savefilefunction(Word.Document myWordDoc, object SaveAs)
        {
            if (File.Exists((string)SaveAs))
            {
                MessageBox.Show("تم الإنشاء من قبل");
            }
            else
            {
                myWordDoc.SaveAs(ref SaveAs, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                MessageBox.Show("تم الإنشاء بنجاح!");
            }
        }
        private void Checkmalefemale(Word.Application wordApp)
        {
            if (radioButton1.Checked)
            {
                SearchinWord.FindAndReplace(wordApp, "<gender1>", "المقيم");
                SearchinWord.FindAndReplace(wordApp, "<title>", "المدعو");
                SearchinWord.FindAndReplace(wordApp, "<gender2>", "يحمل");
                SearchinWord.FindAndReplace(wordApp, "<gender3>", "يده");
                SearchinWord.FindAndReplace(wordApp, "<gender4>", "شكواه");
                SearchinWord.FindAndReplace(wordApp, "<gender5>", "تواجده");
                SearchinWord.FindAndReplace(wordApp, "<gender6>", "سؤاله");
                SearchinWord.FindAndReplace(wordApp, "<gender7>", "فأجاب");
            }

            if (radioButton2.Checked)
            {
                SearchinWord.FindAndReplace(wordApp, "<gender1>", "المقيمة");
                SearchinWord.FindAndReplace(wordApp, "<title>", "المدعوة");
                SearchinWord.FindAndReplace(wordApp, "<gender2>", "تحمل");
                SearchinWord.FindAndReplace(wordApp, "<gender3>", "يدها");
                SearchinWord.FindAndReplace(wordApp, "<gender4>", "شكواها");
                SearchinWord.FindAndReplace(wordApp, "<gender5>", "تواجدها");
                SearchinWord.FindAndReplace(wordApp, "<gender6>", "سؤالها");
                SearchinWord.FindAndReplace(wordApp, "<gender7>", "فأجابت");
            }
            if (radioButton4.Checked)
            {
                SearchinWord.FindAndReplace(wordApp, "حقه", "حقها");
            }

        }

        private void deleteQuestions(Word.Document myWordDoc)
        {
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
            if (checkBox5.Checked == false)
            {
                string bookmark = "bookmark5";
                cleanBookmark(myWordDoc, bookmark);

            }

        }
        private void changeRegion(Word.Application wordApp,string region)
        {
            if (region == "101")
            {
                SearchinWord.FindAndReplace(wordApp, "<region>", "شرق");
            }
            if (region == "102")
            {
                SearchinWord.FindAndReplace(wordApp, "<region>", "شمال");
            }
            if (region == "103")
            {
                SearchinWord.FindAndReplace(wordApp, "<region>", "غرب");
            }        
        }    
        private void addExtra_Click(object sender, EventArgs e)
        {
            if (textBox31.Visible == true)
            {
                textBox32.Visible = true;
            }
            else
            {
                textBox31.Visible = true;
            }
        }
        private void addphone_Click(object sender, EventArgs e)
        {

            if (textBox33.Visible == false)
            {
                textBox33.Visible = true;
                textBox33.Text = "/ ";
            }
            else
            {
                textBox33.Visible = false;
                textBox33.Text = "";
            }
        }
        private void againstmore_Click(object sender, EventArgs e)
        {
            if (textBox34.Visible == false)
            {
                textBox34.Visible = true;
            }
            else
            {
                textBox34.Visible = false;
                textBox34.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox20.Visible == true)
            {
                textBox20.Visible = false;
            }
            else { textBox20.Visible = true; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox21.Visible == true)
            {
                textBox21.Visible = false;
            }
            else { textBox21.Visible = true; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox22.Visible == true)
            {
                textBox22.Visible = false;
            }
            else { textBox22.Visible = true; }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox23.Visible == true)
            {
                textBox23.Visible = false;
            }
            else { textBox23.Visible = true; }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (textBox26.Visible == true)
            {
                textBox26.Visible = false;
            }
            else
            {
                textBox26.Visible = true;
            }

        }

        // event for handle the numbers inputs
        private void numbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // event for handle the text inputs
        private void chars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Create the Doc Method
        private void CreateWordDocument(object templatefile, object saveAsFile)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document myWordDoc = null;
            object readOnly = false;
            object isVisible = false;
            wordApp.Visible = false;

            if (File.Exists((string)templatefile))
            {
                myWordDoc = wordApp.Documents.Open(ref templatefile, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing,
                                                 ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();


                //find and replace
                string Cnumb = textBox1.Text.Trim() + "/" + textBox2.Text.Trim() + "/" + textBox3.Text.Trim();
                SearchinWord.FindAndReplace(wordApp, "<Cnum>", Cnumb);
                SearchinWord.FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());
                SearchinWord.FindAndReplace(wordApp, "<clock>", DateTime.Now.ToShortTimeString());
                /////////////////////////////////data               
                SearchinWord.FindAndReplace(wordApp, "<Dwriter>", textBox4.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<writer>", textBox5.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<name>", textBox6.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<address>", textBox7.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<age>", textBox8.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<job>", textBox9.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<mobile>", textBox10.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<mobile2>", textBox33.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Nid>", textBox11.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<againsttitle>", textBox12.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<againstname>", textBox13.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<force>", textBox14.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<againstmore>", textBox34.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<reason>", textBox15.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<relation>", textBox16.Text.Trim());
                ////////////////////////////////////answers
                SearchinWord.FindAndReplace(wordApp, "<Ans1>", textBox17.Text.Trim());
                //string str = textBox30.Text.Trim();
                //str.Substring(0,320);
                SearchinWord.FindAndReplace(wordApp, "<Ans2>", textBox30.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans22>", textBox31.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans23>", textBox32.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans3>", textBox18.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans4>", textBox19.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans5>", textBox20.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans6>", textBox21.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans7>", textBox22.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans8>", textBox23.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans9>", textBox24.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans10>", textBox25.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans11>", textBox26.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans12>", textBox27.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans13>", textBox28.Text.Trim());
                SearchinWord.FindAndReplace(wordApp, "<Ans14>", textBox29.Text.Trim());

                //region
                string region = textBox2.Text.Trim();
                changeRegion(wordApp, region);
                //delete questions
                deleteQuestions(myWordDoc);
                // male & female
                Checkmalefemale(wordApp);
            }
            else
            {

                MessageBox.Show("التمبلت غير موجود");
            }
            //Save as
            savefilefunction(myWordDoc, saveAsFile);
            //close  doc and app
            ((Microsoft.Office.Interop.Word._Document)myWordDoc).Close(ref missing, ref missing, ref missing);
            ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref missing, ref missing, ref missing);
        }

        private void creatWord_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "" | textBox2.Text.Trim() == "" | textBox3.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من رقم المحضر !");
                //textBox1.BackColor = Color.Yellow;

            }
            else if (textBox4.Text.Trim() == "" | textBox5.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من بيانات كاتب المحضر !");
            }
            else if (textBox6.Text.Trim() == "" | textBox7.Text.Trim() == "" | textBox8.Text.Trim() == "" | textBox9.Text.Trim() == "" | textBox10.Text.Trim() == "" 
                | textBox11.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من بيانات الشاكي !");
            }
            else if (textBox12.Text.Trim() == "" | textBox13.Text.Trim() == "" | textBox14.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من بيانات المشكو في حقه !");
            }
            else if (textBox15.Text.Trim() == "")
            {
                MessageBox.Show("أدخل سبب الشكوي !");
                textBox15.BackColor = Color.Yellow;
            }
            else if (textBox16.Text.Trim() == "")
            {
                MessageBox.Show("أدخل العلاقة !");
                textBox16.BackColor = Color.Yellow;
            }
            else if (textBox17.Text.Trim() == "" | textBox18.Text.Trim() == "" | textBox19.Text.Trim() == "" | textBox24.Text.Trim() == "" | textBox25.Text.Trim() == ""
                 | textBox27.Text.Trim() == "" | textBox28.Text.Trim() == "" | textBox29.Text.Trim() == "" | textBox30.Text.Trim() == "")
            {
                MessageBox.Show("أجب عن بقية الأسئلة");
            }
            else if (textBox11.TextLength < 14)
            {
                MessageBox.Show("تأكد من الرقم القومي!");
                textBox11.BackColor = Color.Yellow;
            }
            else if (textBox10.TextLength < 11)
            {
                MessageBox.Show("تأكد من رقم التليفون!");
                textBox10.BackColor = Color.Yellow;
            }
            else if (radioButton1.Checked == false & radioButton2.Checked == false)
            {
                MessageBox.Show("أختر نوع الشاكي");
            }
            else if (radioButton3.Checked == false & radioButton4.Checked == false)
            {
                MessageBox.Show("أختر نوع المشكو في حقه");
            }
            else
            {
                string Cnumb = textBox1.Text.Trim() + "-" + textBox2.Text.Trim() + "-" + textBox3.Text.Trim();
                string templateFile = @"save\temp\complain.docx";
                string saveAsFile = @"save\" + Cnumb + ".docx";
                CreateWordDocument(templateFile, saveAsFile);
            }
        }
        private void OpenWordDocument(object filename)
        {
            Word._Application wordApp = new Word.Application();
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
        private void openWord_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" | textBox2.Text.Trim() == "" | textBox3.Text.Trim() == "")
            {
                MessageBox.Show("تأكد من رقم المحضر !");
                //textBox1.BackColor = Color.Yellow;

            }
            else
            {
                string Cnumb = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text;
                OpenWordDocument(@"C:\save\" + Cnumb + ".docx");
            }
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new create();
            f2.ShowDialog();
            this.Close();
        }

        

      
    }
}

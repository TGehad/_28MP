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
    public partial class orders : Form
    {
        string filePath = @"save\temp\database.txt";

        public orders()
        {
            InitializeComponent();
        }
        private void orders_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            //WindowState = FormWindowState.Maximized;
            textBox1.Focus();
        }
        private void addorders_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" | textBox2.Text.Trim() == "" | textBox1.Text.Trim() == " " | textBox2.Text.Trim() == " ")
            {
                MessageBox.Show("أكمل البيانات !");
            }
            else
            {
                string id = DateTime.Now.ToString("yyMMddHHmmss");//unique id بالوقت والتاريخ والساعة
                string writer = LoginInfo.UserName; // اسم اليوزر اللي سجل

                string Cnum = textBox1.Text.Trim(); // رقم المحضر

                string order = textBox2.Text.Trim(); // القرار
                string done;              //ماتم حياله
                string sdate = dateTimePicker1.Text; //تاريخ الصدور 
                string edate;               //تاريخ الإنتهاء 
                if (dateTimePicker2.Checked == true)
                {
                    done = textBox3.Text.Trim();
                    edate = dateTimePicker2.Value.ToString();
                }
                else
                {
                    done = "جاري التنفيذ";
                    edate = "";
                }

                object[] data = { id, Cnum, order, done, sdate, edate, writer };
                dataGridView1.Rows.Add(data);

                StreamWriter sw = new StreamWriter(filePath, true);
                string savedata = id + ";" + Cnum + ";" + order + ";" + done + ";" + sdate + ";" + edate + ";" + writer;
                sw.WriteLine(savedata);
                sw.Close();

                //clear
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                    else if (c is DateTimePicker)
                    {
                        c.Text = DateTime.Now.ToString();
                    }
                }
                textBox1.Focus();
            }
        }

        private void showorders_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                StreamReader sr = new StreamReader(filePath);
                string line = "";
                bool found = false;

                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] arrdata = line.Split(';');
                        if (arrdata[1] == textBox1.Text.Trim())
                        {
                            dataGridView1.Rows.Add(arrdata);
                            found = true;
                        }

                    }

                } while (line != null);
                sr.Close();

                if (!found)
                {
                    MessageBox.Show("لا يوجد قرارات لهذا المحضر");
                }
            }
            else
            {
                MessageBox.Show("أدخل رقم المحضر");
                textBox1.Focus();
            }
        }

        private void showallorders_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (File.Exists((string)filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = "";
                var info = new FileInfo(filePath);

                if (info.Length == 0)
                {
                    //الفايل فاضي
                    MessageBox.Show("لا يوجد قرارات");
                }
                else
                {
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] arrdata = line.Split(';');
                            dataGridView1.Rows.Add(arrdata);

                        }

                    } while (line != null);
                    sr.Close();
                }

            }
            else
            {
                //لم يتم إنشاء فايل للقرارات
                MessageBox.Show("لا يوجد قرارات");
            }
        }

        private void edite_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(filePath);
            string line = "";
            string oldValue = "";
            string newvalue = "";
            string id = DateTime.Now.ToString("yyMMddHHmmss");

            if (dataGridView1.CurrentRow != null)
            {
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] arrdata = line.Split(';');
                        if (arrdata[0] == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        {
                            oldValue = line;
                        }
                    }
                } while (line != null);
                sr.Close();

                newvalue = dataGridView1.CurrentRow.Cells[0].Value.ToString() + ";" + textBox1.Text.Trim() + ";" + textBox2.Text.Trim() + ";" + textBox3.Text.Trim() + ";" + dateTimePicker1.Text + ";" + dateTimePicker2.Text + ";" + LoginInfo.UserName;

                string text = File.ReadAllText(filePath);
                text = text.Replace(oldValue, newvalue);
                File.WriteAllText(filePath, text);
                
                ////change on datagridview ///////////
                dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text.Trim();
                dataGridView1.CurrentRow.Cells[2].Value = textBox2.Text.Trim();
                dataGridView1.CurrentRow.Cells[3].Value = textBox3.Text.Trim();
                dataGridView1.CurrentRow.Cells[4].Value = dateTimePicker1.Text;
                dataGridView1.CurrentRow.Cells[5].Value = dateTimePicker2.Text;
                dataGridView1.CurrentRow.Cells[6].Value = LoginInfo.UserName;
            }

            else
            {
                MessageBox.Show("أختر قرار للتعديل");
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                string tempFile = Path.GetTempFileName();
                StreamReader sr = new StreamReader(filePath);
                StreamWriter sw = new StreamWriter(tempFile);
                string line = "";
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] arrdata = line.Split(';');
                        if (arrdata[0] == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        {
                            continue;
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }

                } while (line != null);
                sr.Close();
                sw.Close();
                File.Delete(filePath);
                File.Move(tempFile, filePath);

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            else
            {
                MessageBox.Show("أختر قرار للحذف");
            }

        }        

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f2 = new mainMenu();
            f2.ShowDialog();
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Checked == true)
            {
                textBox3.Visible = true;
            }
            else if (dateTimePicker2.Checked == false)
            {
                textBox3.Visible = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
        }    
    }
}

using System;
using System.Windows.Forms;

namespace SP_Ganeev_11
{
    public partial class MajorForm : Form
    {
        public MajorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listAdd(button1.Text);
                Form1 form1 = new Form1();
                form1.Owner = this;
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании Form1");
                LogException.WriteLog(ex, "Ошибка при создании Form1");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listAdd(button2.Text);
                Form2 form2 = new Form2();
                form2.Owner = this;
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании Form1");
                LogException.WriteLog(ex, "Ошибка при создании Form1");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listAdd(button3.Text);
                Form3 form2 = new Form3();
                form2.Owner = this;
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании Form1");
                LogException.WriteLog(ex, "Ошибка при создании Form1");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listAdd(button4.Text);
            MessageBox.Show("Ганеев Рустам. 6303");
        }

        public void listAdd(string textB)
        {
            try
            {
                listBox1.Items.Add(DateTime.Now);
                listBox1.Items.Add("Нажата кнопка - " + textB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в логе listBox");
                LogException.WriteLog(ex, "Ошибка в логе listBox");
            }
        }
    }
}

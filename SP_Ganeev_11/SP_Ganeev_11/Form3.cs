using System;
using System.Reflection;
using System.Windows.Forms;

namespace SP_Ganeev_11
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Visible = true;
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(button1.Text);
                Assembly asm = Assembly.LoadFrom("AsmFunc.dll");
                Type myType = asm.GetType("AsmFunc.Func", true);
                object obj = Activator.CreateInstance(myType);
                MethodInfo method = myType.GetMethod("GetFunc");
                object d = method.Invoke(obj, new object[] { Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text) });
                label5.Text = d.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке вызова низкоуровневых фунций");
                LogException.WriteLog(ex,"Ошибка в блоке вызова низкоуровневых фунций");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода в textBox1");
                LogException.WriteLog(ex, "Ошибка ввода в textBox1");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода в textBox2");
                LogException.WriteLog(ex, "Ошибка ввода в textBox2");
            }
        }
    }
}

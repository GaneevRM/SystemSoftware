using System;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Diagnostics;


namespace SP_Ganeev_11
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

           private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(button1.Text);
                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                string Output = "Out.exe";
                Button ButtonObject = (Button)sender;
                textBox2.Text = "";
                string preCode = @"
             using System;
             namespace For{
                class ProgramFor
                  {
                   static void Main(string[] args){Console.WriteLine(""Итераций - "" + ForCycle());Console.ReadLine();}
                   public static int ForCycle()
                         {
                            int forCounter =0;
             ";
                string code = textBox1.Text;
                string codeFormating = preCode + code.Substring(0, code.Length - 1) + "forCounter++;" + "}" + "return forCounter;" + "}" + "}" + "}";
                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = Output;
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, codeFormating);
                if (results.Errors.Count > 0)
                {
                    textBox2.ForeColor = Color.Red;
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        textBox2.Text = textBox2.Text + "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";" + Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    textBox2.ForeColor = Color.Blue;
                    textBox2.Text = "Компиляция прошла успешно!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке компиляции цикла");
                LogException.WriteLog(ex, "Ошибка в блоке компиляции цикла");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(button2.Text);
                Process.Start("Out.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вызове цикла");
                LogException.WriteLog(ex, "Ошибка при вызове цикла");
            }
        }
    }
}

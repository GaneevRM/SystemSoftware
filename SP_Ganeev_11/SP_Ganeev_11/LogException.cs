using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Ganeev_11
{
    static class LogException
    {
        public static void WriteLog(Exception e, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(msg)) return;
                string path = Directory.GetCurrentDirectory() + "\\log.txt";
                using (var outfile = new StreamWriter(path, true, Encoding.UTF8))
                {
                    outfile.WriteLine("///////////////////////");
                    outfile.WriteLine("дата: {0}", DateTime.Now);
                    outfile.WriteLine("Описание ошибки: " + msg);
                    outfile.WriteLine("Ошибка: " + e.Message);
                    outfile.WriteLine("Объект: " + e.Source);
                    outfile.WriteLine("Метод, вызвавший исключение: " + e.TargetSite);
                    outfile.WriteLine("Стэк: " + e.StackTrace);
                    outfile.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка записи лога TXT");
            }
        }
    }
}

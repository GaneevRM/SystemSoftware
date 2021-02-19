using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SP_Ganeev_11
{
    public partial class Form2 : Form
    {
        Logic.LinkedList<string> list = new Logic.LinkedList<string>();
        DataTable dt = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }


        public void UpdateTable()
        {
            try
            {
                dt.Clear();
                int upn = 0;
                for (int k = list.Count; 0 < k; k--)
                {
                    string[] rows = list.ElementAt(upn).Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                    upn++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в блоке обновления таблицы");
                LogException.WriteLog(e, "Ошибка в блоке обновления таблицы");
            }
        }

        public void UpdateList()
        {
            try
            {
                list.Clear();
                listBox1.Items.Clear();
                string b = null;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        b = b + dataGridView1[j, i].Value.ToString() + ',';
                    }
                    b = b.Substring(0, b.Length - 1);
                    list.Add(b);
                    b = null;
                }
                foreach (var lol in list)
                {
                    listBox1.Items.Add(lol);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в блоке обновления списка");
                LogException.WriteLog(e, "Ошибка в блоке обновления списка");
            }
        }

        public DataTable CsvReader(string way)
        {
            try
            {
                dt.Reset();
                StreamReader sr = new StreamReader(way, Encoding.Default);
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в блоке считывания CSV файла");
                LogException.WriteLog(e, "Ошибка в блоке считывания CSV файла");
            }
            return dt;

        }

        public void CsvWriter(string way)
        {
            try
            {
                StreamWriter sw = new StreamWriter(way, false, Encoding.Default);
                int cc = dataGridView1.ColumnCount;
                for (int i = 0; i < cc; i++)
                {
                    sw.Write(dataGridView1.Columns[i].Name);
                    if (i < cc - 1)
                        sw.Write(',');
                }
                sw.WriteLine();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < cc; j++)
                    {
                        sw.Write(dataGridView1[j, i].Value);
                        if (j < cc - 1)
                            sw.Write(',');
                    }
                    sw.WriteLine();
                }

                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в блоке записи CSV файла");
                LogException.WriteLog(e, "Ошибка в блоке записи CSV файла");
            }
        }

        private void downloadB_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(downloadB.Text);
                dataGridView1.Enabled = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileEx = new FileInfo(openFileDialog1.FileName);
                    string fe = fileEx.Extension;
                    if (fe == ".csv")
                    {
                        this.dt = new DataTable();
                        dataGridView1.DataSource = CsvReader(openFileDialog1.FileName);
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        UpdateList();
                    }
                    else throw new MyException("Выберите файл с расширением "," .CSV"); 
                }             
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message + "-" + ex.FileEx);
                LogException.WriteLog(ex, ex.Message + "-" + ex.FileEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке загрзуки CSV файла (диалоговое окно)");
                LogException.WriteLog(ex, "Ошибка в блоке загрзуки CSV файла (диалоговое окно)");
            }

        }

       private void inputB_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(inputB.Text);
                if (dataGridView1.Enabled == false)
                {
                    MessageBox.Show("Загрузите .CSV файл");
                }
                else
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileEx = new FileInfo(openFileDialog2.FileName);
                        string fe = fileEx.Extension;
                        if (fe == ".exe")
                        {
                            string a, b, c = null;
                            FileVersionInfo fileversion = FileVersionInfo.GetVersionInfo(openFileDialog2.FileName);
                            a = fileEx.Name;
                            b = fileversion.FileVersion;
                            c = fileEx.LastWriteTime.ToShortDateString();
                            list.Add(a + ',' + b + ',' + c);
                            UpdateTable();
                            UpdateList();
                        }
                        else throw new MyException("Выберите файл с расширением ", " .EXE");
                    }
                }
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message + "-" + ex.FileEx);
                LogException.WriteLog(ex, ex.Message + "-" + ex.FileEx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке загрзуки EXE файла (диалоговое окно)");
                LogException.WriteLog(ex, "Ошибка в блоке загрзуки EXE файла (диалоговое окно)");
            }
        }

        private void deleteB_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(deleteB.Text);

                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Загрузите .CSV файл или выделите строку для удаления");
                }
                else
                {
                    list.DeleteIndex(dataGridView1.CurrentRow.Index);
                    UpdateTable();
                    UpdateList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке удаления записи");
                LogException.WriteLog(ex, "Ошибка в блоке удаления записи");
            }
        }

        private void editB_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(editB.Text);
                if (dataGridView1.Enabled == false)
                {
                    MessageBox.Show("Загрузите .CSV файл");
                }
                else
                {
                    UpdateList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке редактирования записи");
                LogException.WriteLog(ex, "Ошибка в блоке редактирования записи");
            }
        }

        private void saveB_Click(object sender, EventArgs e)
        {
            try
            {
                MajorForm major = this.Owner as MajorForm;
                major.listAdd(saveB.Text);
                if (dataGridView1.Enabled == false)
                {
                    MessageBox.Show("Загрузите .CSV файл");
                }
                else
                {
                    saveFileDialog1.FileName = "Новый файл.csv";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        CsvWriter(saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в блоке сохранения CSV файла");
                LogException.WriteLog(ex, "Ошибка в блоке сохранения CSV файла");
            }
        }
    }
}

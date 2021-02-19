namespace SP_Ganeev_11
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputB = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.editB = new System.Windows.Forms.Button();
            this.downloadB = new System.Windows.Forms.Button();
            this.saveB = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputB
            // 
            this.inputB.Location = new System.Drawing.Point(73, 222);
            this.inputB.Name = "inputB";
            this.inputB.Size = new System.Drawing.Size(75, 23);
            this.inputB.TabIndex = 1;
            this.inputB.Text = "Ввод .EXE";
            this.inputB.UseVisualStyleBackColor = true;
            this.inputB.Click += new System.EventHandler(this.inputB_Click);
            // 
            // deleteB
            // 
            this.deleteB.Location = new System.Drawing.Point(201, 222);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(97, 23);
            this.deleteB.TabIndex = 2;
            this.deleteB.Text = "Удалить строку";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // editB
            // 
            this.editB.Location = new System.Drawing.Point(343, 222);
            this.editB.Name = "editB";
            this.editB.Size = new System.Drawing.Size(116, 23);
            this.editB.TabIndex = 3;
            this.editB.Text = "Применить редакт.";
            this.editB.UseVisualStyleBackColor = true;
            this.editB.Click += new System.EventHandler(this.editB_Click);
            // 
            // downloadB
            // 
            this.downloadB.Location = new System.Drawing.Point(130, 264);
            this.downloadB.Name = "downloadB";
            this.downloadB.Size = new System.Drawing.Size(98, 23);
            this.downloadB.TabIndex = 4;
            this.downloadB.Text = "Загрузить .CSV";
            this.downloadB.UseVisualStyleBackColor = true;
            this.downloadB.Click += new System.EventHandler(this.downloadB_Click);
            // 
            // saveB
            // 
            this.saveB.Location = new System.Drawing.Point(271, 264);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(97, 23);
            this.saveB.TabIndex = 5;
            this.saveB.Text = "Сохранить .CSV";
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\user\\Desktop\\Рабочий стол 2\\Student\\3 курс\\2 семак\\СП\\Programm\\Files";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(490, 192);
            this.dataGridView1.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(508, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(131, 173);
            this.listBox1.TabIndex = 7;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.InitialDirectory = "C:\\Users\\user\\Desktop\\Рабочий стол 2\\Student\\3 курс\\2 семак\\СП\\Programm\\Files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Что происходит в списке";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saveB);
            this.Controls.Add(this.downloadB);
            this.Controls.Add(this.editB);
            this.Controls.Add(this.deleteB);
            this.Controls.Add(this.inputB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Работа с файлами (.CSV)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button inputB;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button editB;
        private System.Windows.Forms.Button downloadB;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
    }
}
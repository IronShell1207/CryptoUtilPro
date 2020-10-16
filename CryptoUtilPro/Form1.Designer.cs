namespace CryptoUtilPro
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FileList = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonAddFiles = new MetroFramework.Controls.MetroButton();
            this.buttonClear = new MetroFramework.Controls.MetroButton();
            this.buttonEnq = new MetroFramework.Controls.MetroButton();
            this.buttonDec = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.mSM = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).BeginInit();
            this.SuspendLayout();
            // 
            // FileList
            // 
            this.FileList.BackColor = System.Drawing.Color.White;
            this.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileList.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileList.ForeColor = System.Drawing.Color.Black;
            this.FileList.FormattingEnabled = true;
            this.FileList.ItemHeight = 17;
            this.FileList.Location = new System.Drawing.Point(13, 63);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(435, 104);
            this.FileList.TabIndex = 0;
            this.FileList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FileList_KeyPress);
            this.FileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileList_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Location = new System.Drawing.Point(178, 175);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(125, 23);
            this.buttonAddFiles.TabIndex = 8;
            this.buttonAddFiles.Text = "Открыть файлы";
            this.buttonAddFiles.UseSelectable = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(313, 175);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(135, 23);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "Очистить список";
            this.buttonClear.UseSelectable = true;
            this.buttonClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonEnq
            // 
            this.buttonEnq.Location = new System.Drawing.Point(230, 235);
            this.buttonEnq.Name = "buttonEnq";
            this.buttonEnq.Size = new System.Drawing.Size(104, 29);
            this.buttonEnq.TabIndex = 11;
            this.buttonEnq.Text = "Шифровать";
            this.buttonEnq.UseSelectable = true;
            this.buttonEnq.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonDec
            // 
            this.buttonDec.Location = new System.Drawing.Point(344, 235);
            this.buttonDec.Name = "buttonDec";
            this.buttonDec.Size = new System.Drawing.Size(104, 29);
            this.buttonDec.TabIndex = 12;
            this.buttonDec.Text = "Расшифровать";
            this.buttonDec.UseSelectable = true;
            this.buttonDec.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(246, 1);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(13, 205);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PromptText = "Ключ шифрования";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(268, 23);
            this.textBox1.TabIndex = 13;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMark = "Ключ шифрования";
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox2
            // 
            // 
            // 
            // 
            this.textBox2.CustomButton.Image = null;
            this.textBox2.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(287, 205);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PromptText = "Регион ТУ/ФГБУ";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(161, 23);
            this.textBox2.TabIndex = 15;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMark = "Регион ТУ/ФГБУ";
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 23;
            this.comboBox1.Location = new System.Drawing.Point(13, 235);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 29);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.UseSelectable = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(358, 31);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 17;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // mSM
            // 
            this.mSM.Owner = this;
            this.mSM.Style = MetroFramework.MetroColorStyle.Lime;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 277);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDec);
            this.Controls.Add(this.buttonEnq);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAddFiles);
            this.Controls.Add(this.FileList);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "Крипто AES";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroButton buttonAddFiles;
        private MetroFramework.Controls.MetroButton buttonClear;
        private MetroFramework.Controls.MetroButton buttonEnq;
        private MetroFramework.Controls.MetroButton buttonDec;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Components.MetroStyleManager mSM;
    }
}


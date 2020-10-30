using MetroFramework;
using MetroFramework.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inifiles;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace CryptoUtilPro
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public IniFile iniFile = new IniFile(JsonWorker.DirCry + "settings.ini");
        private AesCryptoServiceProvider sSecretKey;
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            
                FileList.Items.Add(args[0]);
  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                int num1 = (int)MetroMessageBox.Show(this, "Введите ключ шифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.FileList.Items.Count == 0)
            {
                int num2 = (int)MessageBox.Show("Выберете файлы!");
            }
            else if (this.textBox1.Text.Length != 16)
            {
                int num3 = (int)MetroMessageBox.Show(this, "Количество символов открытого ключа должно равнятся 16!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                progress1.Value = 0;
                progress1.Maximum = FileList.Items.Count;
                this.sSecretKey = this.GenerateKey();
                GCHandle gcHandle = GCHandle.Alloc((object)this.sSecretKey.Key, GCHandleType.Pinned);
                foreach (object obj in this.FileList.Items)
                {
                    this.EncryptFile(obj.ToString(), obj.ToString() + ".encr", this.sSecretKey);
                    progress1.Value++;
                }
                gcHandle.Free();

            }
        }
        public void EncryptFile(string sInputFilename, string sOutputFilename, AesCryptoServiceProvider sKey)
        {
            FileStream fileStream1 = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fileStream2 = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider();
            cryptoServiceProvider.Key = sKey.Key;
            cryptoServiceProvider.IV = sKey.IV;
            ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream((Stream)fileStream2, encryptor, CryptoStreamMode.Write);
            byte[] buffer = new byte[fileStream1.Length];
            fileStream1.Read(buffer, 0, buffer.Length);
            byte[] bytes = Encoding.ASCII.GetBytes(this.textBox1.Text);
            cryptoStream.Write(bytes, 0, bytes.Length);
            byte[] array = ((IEnumerable<byte>)bytes).Concat<byte>((IEnumerable<byte>)buffer).ToArray<byte>();
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.Close();
            fileStream1.Close();
            fileStream2.Close();
        }
        public AesCryptoServiceProvider GenerateKey()
        {
            byte[] bytes1 = Encoding.ASCII.GetBytes("~HJmYC6SLClGR06Wk%wfj~4#1k|hfZy?");
            byte[] bytes2 = Encoding.ASCII.GetBytes(this.textBox1.Text);
            AesCryptoServiceProvider cryptoServiceProvider = (AesCryptoServiceProvider)Aes.Create();
            cryptoServiceProvider.Key = bytes1;
            cryptoServiceProvider.IV = bytes2;
            return cryptoServiceProvider;
        }
        public bool DecryptFile(string sInputFilename, string sOutputFilename, AesCryptoServiceProvider sKey, bool isNotify)
        {
            AesCryptoServiceProvider cryptoServiceProvider = new AesCryptoServiceProvider();
            cryptoServiceProvider.Key = sKey.Key;
            cryptoServiceProvider.IV = sKey.IV;
            CryptoStream cryptoStream = new CryptoStream((Stream)new FileStream(sInputFilename, FileMode.Open, FileAccess.Read), cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read);
            FileStream fileStream = new FileStream(sOutputFilename, FileMode.Create);
            byte[] numArray = new byte[1024];
            int num1 = 0;
            int count;
            do
            {
                ++num1;
                count = cryptoStream.Read(numArray, 0, 1024);
                if (num1 == 1)
                {
                    if (Encoding.Default.GetString(numArray).Substring(16, 16) != this.textBox1.Text)
                    {
                        if (isNotify) MetroMessageBox.Show(this, "Введен неверный открытый ключ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fileStream.Flush();
                        fileStream.Close();
                        File.Delete(sOutputFilename);
                        return false;
                    }
                    fileStream.Write(numArray, 32, count - 32);
                }
                else
                    fileStream.Write(numArray, 0, count);
            }
            while (count == 1024);
            fileStream.Flush();
            fileStream.Close();
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                int num1 = (int)MetroMessageBox.Show(this, "Введите ключ шифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (FileList.Items.Count == 0)
            {
                int num2 = (int)MessageBox.Show("Выберете файлы!");
            }
            else if (textBox1.Text.Length != 16)
            {
                int num3 = (int)MetroMessageBox.Show(this, "Количество символов открытого ключа должно равнятся 16!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var newKeyD = new CryptKey { CryptyKey = textBox1.Text, NameTu = textBox2.Text };
                progress1.Value = 0;
                progress1.Maximum = FileList.Items.Count;
                this.sSecretKey = this.GenerateKey();
                foreach (object obj in this.FileList.Items)
                {
                    int length = obj.ToString().Length;
                    if (DecryptFile(obj.ToString(), obj.ToString().Substring(0, length - 5), this.sSecretKey, true))
                        if (!comboBox1.Items.Contains(newKeyD.NameTu + ": " + newKeyD.CryptyKey))
                        {
                            JsonWorker.CryKeys.Add(newKeyD);
                            JsonWorker.CreateJsnFile(JsonWorker.CryKeys, JsonWorker.DirCry + "jsnCry.json");
                        }
                    progress1.Value++;
                }
            }
        }
        DialogResult TryToDecrupt()
        {
            if (JsonWorker.CryKeys.Any())
            {
                sSecretKey = GenerateKey();
                foreach (object obj in FileList.Items)
                {
                    int length = obj.ToString().Length;
                    for (int i2 = 0; i2 < JsonWorker.CryKeys.Count; i2++)
                    {
                        comboBox1.SelectedIndex = i2;
                        if (DecryptFile(obj.ToString(), obj.ToString().Substring(0, length - 5), sSecretKey, false))
                            return DialogResult.OK;
                    }
                }
            }
            return DialogResult.Cancel;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                    FileList.Items.Add(file);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileList.Items.Clear();
        }
        void SetEnable()
        {
            if (iniFile.KeyExists("IndexLast", "Settings"))
            {
                var index1 = int.Parse(iniFile.ReadINI("Settings", "IndexLast"));
                comboBox1.SelectedIndex = comboBox1.Items.Count - 1 >= index1 ? index1 : 0;
            }
            if (iniFile.KeyExists("ThemeLast", "Settings"))
                metroToggle1.Checked = bool.Parse(iniFile.ReadINI("Settings", "ThemeLast"));
            if (iniFile.KeyExists("isAutoDecr", "Settings"))
            {
                metroToggle2.Checked = bool.Parse(iniFile.ReadINI("Settings", "isAutoDecr"));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (JsonWorker.CryKeys.Count != 0)
            {
                foreach (CryptKey cryptKey in JsonWorker.CryKeys)
                {
                    comboBox1.Items.Add(cryptKey.NameTu + ": " + cryptKey.CryptyKey);
                }
                //  comboBox1.SelectedIndex = 0;
            }
            else comboBox1.Text = "Нет сохраненных ключей";
            this.StyleManager = mSM;
            SetEnable();
            if (metroToggle2.Checked==true)
            if (FileList.Items.Count>0)
            {
                if (TryToDecrupt() == DialogResult.OK)
                    Application.Exit();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fil = (string[])e.Data.GetData(DataFormats.FileDrop);
            JsonWorker.FilesTo.AddRange(fil);
            foreach (string fileP in fil)
                FileList.Items.Add(fileP);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            iniFile.Write("Settings", "ThemeLast", metroToggle1.Checked.ToString());
            if (metroToggle1.Checked == true)
            {
                mSM.Theme = MetroFramework.MetroThemeStyle.Dark;
                FileList.BackColor = Color.Black;
                FileList.ForeColor = Color.White;

            }
            else
            {
                mSM.Theme = MetroFramework.MetroThemeStyle.Light;
                FileList.BackColor = Color.White;
                FileList.ForeColor = Color.Black;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                textBox1.Text = JsonWorker.CryKeys[comboBox1.SelectedIndex].CryptyKey;
                textBox2.Text = JsonWorker.CryKeys[comboBox1.SelectedIndex].NameTu;
                iniFile.Write("Settings", "IndexLast", comboBox1.SelectedIndex.ToString());
            }
        }

        private void FileList_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void FileList_KeyUp(object sender, KeyEventArgs e)
        {
            if (FileList.SelectedIndex > -1)
                if (e.KeyCode == Keys.Delete)
                {
                    FileList.Items.RemoveAt(FileList.SelectedIndex);
                }
        }
        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            iniFile.Write("Settings", "isAutoDecr", metroToggle2.Checked.ToString());

        }
    }
}

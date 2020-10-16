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

namespace CryptoUtilPro
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public string DirCry
        {
            get
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CryptCache\";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        private AesCryptoServiceProvider sSecretKey;
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
                FileList.Items.Add(args[0]);
        }
        private List<String> filesTO;
        public List<String> FilesTo
        {
            get
            {
                if (filesTO != null)
                {
                    return filesTO;
                }
                filesTO = new List<String> { };
                return filesTO;
            }
            set { filesTO = value; }
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
                this.sSecretKey = this.GenerateKey();
                GCHandle gcHandle = GCHandle.Alloc((object)this.sSecretKey.Key, GCHandleType.Pinned);
                foreach (object obj in this.FileList.Items)
                    this.EncryptFile(obj.ToString(), obj.ToString() + ".encr", this.sSecretKey);
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
        public bool DecryptFile(string sInputFilename, string sOutputFilename, AesCryptoServiceProvider sKey)
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
                        int num2 = (int)MetroMessageBox.Show(this, "Введен неверный открытый ключ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                this.sSecretKey = this.GenerateKey();
                foreach (object obj in this.FileList.Items)
                {
                    int length = obj.ToString().Length;
                    if (DecryptFile(obj.ToString(), obj.ToString().Substring(0, length - 5), this.sSecretKey))
                        if (!CryKeys.Contains(newKeyD))
                        {
                            CryKeys.Add(newKeyD);
                            CreateJsnFile(CryKeys, DirCry + "jsnCry.json");
                        }
                }

            }
        }
        private List<CryptKey> cryKeys;
        public List<CryptKey> CryKeys
        {
            get
            {
                if (cryKeys == null)
                {
                    string path = DirCry + "jsnCry.json";
                    if (File.Exists(path))
                        cryKeys = ReadJsnFile(path);
                    else cryKeys = new List<CryptKey> { };
                }
                return cryKeys;
            }
        }
        public class CryptKey
        {
            public string NameTu { get; set; }
            public string CryptyKey { get; set; }
        }
        public List<CryptKey> ReadJsnFile(string path)
        {
            List<CryptKey> stations = new List<CryptKey> { };
            using (StreamReader jsReader = new StreamReader(path))
            {
                CryptKey station = new CryptKey();

                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var favoriteList = jsonSerializer.Deserialize<List<CryptKey>>(json);
                return favoriteList;
            }
        }
        public void CreateJsnFile(List<CryptKey> listkeys, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                JsonWriter jsonWriter = new JsonTextWriter(sw);
                JsonSerializer jsnS = new JsonSerializer();
                jsnS.Serialize(jsonWriter, listkeys);
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CryKeys.Count != 0)
            {
                foreach (CryptKey cryptKey in CryKeys)
                {
                    comboBox1.Items.Add(cryptKey.NameTu + ": " + cryptKey.CryptyKey);
                }
                comboBox1.SelectedIndex = 0;
            }
            else comboBox1.Text = "Нет сохраненных ключей";
            this.StyleManager = mSM;
            if (File.Exists(DirCry + "setts.json"))
            {
                var set = ReadJsnFile(DirCry + "setts.json");
                metroToggle1.Checked = bool.Parse(set[0].CryptyKey);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fil = (string[])e.Data.GetData(DataFormats.FileDrop);
            FilesTo.AddRange(fil);
            foreach (string fileP in fil)
                FileList.Items.Add(fileP);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            List<CryptKey> ds = new List<CryptKey> { };
            ds.Add(new CryptKey { CryptyKey = metroToggle1.Checked.ToString(), NameTu = "Theme" });
            CreateJsnFile(ds, DirCry + "setts.json");
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
                textBox1.Text = CryKeys[comboBox1.SelectedIndex].CryptyKey;
                textBox2.Text = CryKeys[comboBox1.SelectedIndex].NameTu;
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
    }
}

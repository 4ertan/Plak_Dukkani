using MaratonEfCodeFirst.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace MaratonEfCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string ShaHash(string parola)
        {
            SHA256 sHA256 = SHA256.Create();

            byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(parola));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString());
            }
            return sb.ToString();
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
           string pass= ShaHash(txtSifre.Text);
            var UserBul = db.Users.Where(x => x.UserName == txtKullaniciAdi.Text && x.Password == pass).Count();
            if (UserBul>0)
            {
                Form3 form3 = new Form3();
             
                form3.ShowDialog();

            }
            else
            {
                DialogResult dr = MessageBox.Show("Kayıt olmak ister misiniz ?", "Kayıt", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                   
                }
            }
        }
    }
}

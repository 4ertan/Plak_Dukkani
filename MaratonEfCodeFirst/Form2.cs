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

namespace MaratonEfCodeFirst
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

          RegularEx("^(?=.*?[A-Z])(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[a-z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])(?=.*?[#?!@$%^&*-]).{8,}$", txtSifre, label4);
        }

        private void txtSifreTekrar_TextChanged(object sender, EventArgs e)
        {
            RegularEx("^(?=.*?[A-Z])(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[a-z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])(?=.*?[#?!@$%^&*-]).{8,}$", txtSifre, label5);

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

        public void RegularEx(string rgx, TextBox txtb, Label lbl)
        {
            Regex regex = new Regex(rgx);
            Match match = regex.Match(txtb.Text);

            if (match.Success)
            {
                lbl.BackColor = Color.Green;
                lbl.Text = "Succsessful";
            }
            else
            {
                lbl.BackColor = Color.Red;
                lbl.Text = "Unsuccsessful";
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Model1 db=new Model1();
           var kntrl= db.Users.Where(x => x.UserName == txtKullaniciAdi.Text).Count();
            if (kntrl>0)
            {
                MessageBox.Show("Lütfen Farklı kullanıcı giriniz.");
            }
            else
            {
            
                if (label4.BackColor == Color.Green && label5.BackColor == Color.Green && txtSifre.Text == txtSifreTekrar.Text)
                {
                    string Pass = ShaHash(txtSifreTekrar.Text);
                    User userK = new User();
                    userK.UserName = txtKullaniciAdi.Text;
                    userK.Password = Pass;
                    db.Users.Add(userK);
                    db.SaveChanges();
                    MessageBox.Show("Yeni kullanıcı Oluşturuldu.");
                }
                else
                {
                    MessageBox.Show("Lütfen şifrelerinizi aynı giriniz.");
                }
            }
            
        }

      
    }
}

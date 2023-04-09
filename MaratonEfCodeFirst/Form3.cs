using MaratonEfCodeFirst.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaratonEfCodeFirst
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Model1 db = new Model1();
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Albums.ToList();

            dataGridView2.DataSource = db.Albums.Where(x => x.SatisDurum == true).ToList();
            dataGridView3.DataSource = db.Albums.Where(x => x.SatisDurum == false).ToList();
          
        //    dataGridView3.DataSource = db.Albums.OrderByDescending(x=>x.AlbumID).Take(10);

            dataGridView4.DataSource = db.Albums.OrderByDescending(x=>x.IndirimOrani).ToList();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null&&textBox2.Text!=null&&textBox4.Text!=null)
            {
                Album newAlbum =new Album();
                newAlbum.Title=textBox1.Text;
                newAlbum.Sanatci=textBox2.Text;
                newAlbum.CikisT = dateTimePicker1.Value;
                newAlbum.SatisDurum =radioButton1.Checked==true?true:false;
                newAlbum.IndirimOrani = (int)numericUpDown1.Value;
                int fiyat;
                bool _suc=int.TryParse(textBox4.Text,out fiyat);
                if (_suc == true)
                {
                    newAlbum.Fiyat = fiyat;
                    db.Albums.Add(newAlbum);
                    db.SaveChanges();

                }
                else
                    MessageBox.Show("Lutfen doğru Fiyat girin");
            
              
                dataGridView1.DataSource=db.Albums.ToList();
            }

            else
            {
                MessageBox.Show("Lütfen eksik alanları doldurunuz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        db.Albums.Remove((Album)row.DataBoundItem);
                    }
                    db.SaveChanges();
                }
                dataGridView1.DataSource = db.Albums.ToList();
            }
            else
            {
                Console.WriteLine("Silme işlemi başarısız");
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            db.SaveChanges();
            
            
        }
    }
}

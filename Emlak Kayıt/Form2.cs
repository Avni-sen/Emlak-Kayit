using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Emlak_Kayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-704QU67;Initial Catalog=siteler;Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From sitebilgi", baglantı);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());

                listView1.Items.Add(ekle);
            }
            baglantı.Close();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Zambak Sitesi ") {
                BtnZambak.BackColor = Color.Red;

                BtnGul.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;


            }
            if (comboBox1.Text == "Papatya Sitesi ")
            {
                BtnPapatya.BackColor = Color.Red;

                BtnGul.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Gray;
                BtnZambak.BackColor = Color.Gray;


            }
            if (comboBox1.Text == "Menekşe Sitesi ")
            {
                BtnMenekse.BackColor = Color.Red;

                BtnGul.BackColor = Color.Gray;
                BtnZambak.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;


            }
            if (comboBox1.Text == "Gül Sitesi ")
            {
                BtnGul.BackColor = Color.Red;

                BtnZambak.BackColor = Color.Gray;
                BtnMenekse.BackColor = Color.Gray;
                BtnPapatya.BackColor = Color.Gray;
            }

        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {

            verilerigoster();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into sitebilgi (id , site , satkira , oda , metre , fiyat , blok , no , adsoyad , telefon , notlar)" +
                "                            values ('" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString()+ "','" + comboBox2.Text.ToString() + "','"
                                            + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() 
                                            + "','"+ comboBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString()+ "')" , baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigoster();
        }


        int id = 0;
        private void BtnSil_Click(object sender, EventArgs e)
        {
           
        }
        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Delete from sitebilgi where id =(" + id + ")", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigoster();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id ='" +textBox3.Text.ToString() + "',site= '" + comboBox1.Text.ToString()+ "',satkira='" + comboBox2.Text.ToString() + "',oda= '"
                                            + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString()
                                            + "',no ='" + comboBox5.Text.ToString() + "',adsoyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() + "',notlar='" + textBox6.Text.ToString() +"'where id="+id+"" , baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verilerigoster();
        }
    }

}

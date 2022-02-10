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
using System.IO;

namespace ETUT_TEST
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial Catalog=EtutTest;Integrated Security=True");
        void derslistele()
        {
            SqlDataAdapter dt = new SqlDataAdapter("select * from TBLBRANS", con);
            DataTable da = new DataTable();
            dt.Fill(da);
            cmbders.ValueMember = "BRANSID";
            cmbders.DisplayMember = "BRANSAD";
            cmbders.DataSource = da;
            cmbders.Text = " ";


           }
        void derslistele2()
        {
            SqlDataAdapter dt = new SqlDataAdapter("select * from TBLBRANS", con);
            DataTable da = new DataTable();
            dt.Fill(da);
            comboBoxBRANŞ.ValueMember = "BRANSID";
            comboBoxBRANŞ.DisplayMember = "BRANSAD";
            comboBoxBRANŞ.DataSource = da;
            comboBoxBRANŞ.Text = " ";
        }
        void etut()
        {
            SqlDataAdapter dt = new SqlDataAdapter("execute ETUTMERKEZ", con);
            DataTable da = new DataTable();
            dt.Fill(da);
            dataGridView1.DataSource = da;
        }
        void OGRETMEN()
        {
            SqlDataAdapter dt1 = new SqlDataAdapter("SELECT * FROM TBLOGRETMEN", con);
            DataTable da1 = new DataTable();
            dt1.Fill(da1);
            dataGridView2.DataSource = da1;
        }
        void OGRENCİ()
        {
         SqlDataAdapter dt2 = new SqlDataAdapter("SELECT * FROM TBLOGRENCİ", con);
            DataTable da2 = new DataTable();
            dt2.Fill(da2);
            dataGridView3.DataSource = da2;
        }
        void BRANS()
        {
            SqlDataAdapter dt2 = new SqlDataAdapter("SELECT * FROM TBLBRANS", con);
            DataTable da2 = new DataTable();
            dt2.Fill(da2);
            dataGridView4.DataSource = da2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxETÜTOL.Visible = true;
            groupBoxBRANSEKLE.Visible = false;
            groupBoxÖGETÜTVER.Visible = false;
            groupBoxÖGRETMENEKLE.Visible = false;
            groupBoxÖGETÜTVER.Visible = false;
            groupBox1.Visible = true;
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxETÜTLİST.Visible = true;
            groupBoxÖĞRENCİLİST.Visible = false;
            groupBoxBRANSLİST.Visible = false;
            groupBoxÖGRETMENLİST.Visible = false;
            
            

            


            derslistele();
           derslistele2();
            etut();
            OGRETMEN();
           OGRENCİ();
            BRANS();
            
        }
     
        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  SqlDataAdapter dt2 = new SqlDataAdapter("select *from TBLOGRETMEN WHERE BRANSID="+cmbders.SelectedValue, con);
            SqlDataAdapter dt3 = new SqlDataAdapter("select OGRETMENID,(AD+' '+SOYAD)AS 'AD'from TBLOGRETMEN WHERE BRANSID=" + cmbders.SelectedValue, con);
            DataTable da3 = new DataTable();
            dt3.Fill(da3);
             cmbogretm.ValueMember = "OGRETMENID";
           cmbogretm.DisplayMember = "AD";
            cmbogretm.DataSource = da3;
            cmbogretm.Text = " ";
  }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLETUT (BRANSID,OGRETMENID,TARİH,SAAT) values (@p1,@p2,@p3,@p4)", con);
            kmt.Parameters.AddWithValue("@p1", cmbders.SelectedValue);
            kmt.Parameters.AddWithValue("@p2", cmbogretm.SelectedValue);
             kmt.Parameters.AddWithValue("@p3", msktarih.Text);
            kmt.Parameters.AddWithValue("@p4",msksaat.Text);
            kmt.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ETÜT EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            etut();
        
      }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand kmt = new SqlCommand("update TBLETUT SET OGRENCIID=@P1,DURUM=@P2 WHERE ID=@P3", con);
            kmt.Parameters.AddWithValue("@p1", textBoxogr.Text);
            kmt.Parameters.AddWithValue("@p2", "true");
            kmt.Parameters.AddWithValue("@p3", textBoxıd.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("ETÜT ÖĞRENCİYE VERİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            etut();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox11.ImageLocation = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLOGRENCİ (AD,SOYAD,FOTOGRAF,SINIF,TELEFON,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", con);
            kmt.Parameters.AddWithValue("@p1", textBoxad.Text);
            kmt.Parameters.AddWithValue("@p2", textBoxsoyad.Text);
            kmt.Parameters.AddWithValue("@p3", pictureBox11.ImageLocation);
            kmt.Parameters.AddWithValue("@p4", textBoxsınıf.Text);
            kmt.Parameters.AddWithValue("@p5", msktel.Text);
            kmt.Parameters.AddWithValue("@p6", textBoxmail.Text);
            kmt.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ÖĞRENCİ KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OGRENCİ();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            derslistele();
        }
        
        public string SORGU;
        bool durum;
        private void button5_Click(object sender, EventArgs e)
        {
           
            con.Open();
            
            SqlCommand kmt1 = new SqlCommand("select * from TBLBRANS  ", con);
            SqlDataReader dr1 = kmt1.ExecuteReader();
            while (dr1.Read())
            {
                SORGU = dr1[1].ToString();
                if(SORGU== txtbranş.Text)
                {
                    durum = false;
                }
                else
                {
                    durum = true;
                }
               
            }
            con.Close();
            
            if (durum == false)
            {
                con.Open();
                SqlCommand kmt = new SqlCommand("insert into TBLBRANS (BRANSAD) values (@p1)", con);
                kmt.Parameters.AddWithValue("@p1", txtbranş.Text);
                kmt.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DERS EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("BU DERS KAYDI MEVCUTTUR", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
            }
          


            
            BRANS();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLOGRETMEN (AD,SOYAD,BRANSID) values (@p1,@p2,@p3)", con);
            kmt.Parameters.AddWithValue("@p1", textBoxOGRMAD.Text);
            kmt.Parameters.AddWithValue("@P2", TXTOGRMSOYAD.Text);
            kmt.Parameters.AddWithValue("@p3", comboBoxBRANŞ.SelectedValue);
            
            kmt.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ÖĞRETMEN KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OGRETMEN();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxÖGETÜTVER.Visible = true;
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxBRANSEKLE.Visible = false;
            groupBoxÖGRETMENEKLE.Visible = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxÖGRENCİEKLE.Visible = true;
            groupBoxETÜTOL.Visible = false;
            groupBoxBRANSEKLE.Visible = false;
            groupBoxÖGETÜTVER.Visible = false;
            groupBoxÖGRETMENEKLE.Visible = false;
            //groupBoxÖGETÜTVER.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxETÜTOL.Visible = true;
            groupBoxBRANSEKLE.Visible = false;
            groupBoxÖGRETMENEKLE.Visible = true;
            groupBoxÖGETÜTVER.Visible = false;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxETÜTOL.Visible = true;
            groupBoxBRANSEKLE.Visible = true;
            groupBoxÖGRETMENEKLE.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //öğrenci
            groupBoxETÜTLİST.Visible = false;
            groupBoxÖĞRENCİLİST.Visible = true;
            groupBoxBRANSLİST.Visible = false;
            groupBoxÖGRETMENLİST.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            //öğretmen
            groupBoxETÜTLİST.Visible = false;
            groupBoxÖĞRENCİLİST.Visible = false;
            groupBoxBRANSLİST.Visible = false;
            groupBoxÖGRETMENLİST.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //brans
            groupBoxETÜTLİST.Visible = false;
            groupBoxÖĞRENCİLİST.Visible = false;
            groupBoxBRANSLİST.Visible = true;
            groupBoxÖGRETMENLİST.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //etüt
            groupBoxETÜTLİST.Visible = true;
            groupBoxÖĞRENCİLİST.Visible = false;
            groupBoxBRANSLİST.Visible = false;
            groupBoxÖGRETMENLİST.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBoxÖGRENCİEKLE.Visible = false;
            groupBoxETÜTOL.Visible = true;
            groupBoxBRANSEKLE.Visible = false;
            groupBoxÖGETÜTVER.Visible = false;
            groupBoxÖGRETMENEKLE.Visible = false;
        }
    }
}

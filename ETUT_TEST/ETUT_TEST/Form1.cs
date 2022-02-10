using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETUT_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxkullanıncı.Text=="user" && textBoxşifre.Text == "password")
            {
                Form2 fr = new Form2();
                fr.Show();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
            }
        }
    }
}

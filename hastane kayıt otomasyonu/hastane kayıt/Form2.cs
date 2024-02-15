using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_kayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string Tc
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string Ad
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Soyad
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string Kan
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public string Tel
        {
            get { return maskedTextBox1.Text; }
            set { maskedTextBox1.Text = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void eskirenk(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(26, 115, 232);
        }

        private void yenirenk(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(27, 102, 202);
        }
        private void eskirenk1(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(249,249,249);
        }

        private void yenirenk1(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(246, 250, 254);
        }
        private string TcDogrula(string tcNo)
        {
            string durum = "";
            try
            {
                if (tcNo != "")
                {
                    if (tcNo.Length == 11)
                    {
                        char[] rakamlar = tcNo.ToCharArray();
                        int kural1 = 0, hane11 = rakamlar[10], hane10 = rakamlar[9];

                        for (int i = 0; i < 10; i++)
                        {
                            kural1 += Convert.ToInt32(rakamlar[i].ToString());
                        }
                        char[] birlerbasamagikural1 = kural1.ToString().ToCharArray();

                        int kural2tek = 0, kural2cift = 0;

                        for (int i = 0; i < 10; i += 2)
                        {
                            kural2tek += Convert.ToInt32(rakamlar[i].ToString());
                        }
                        for (int i = 1; i < 9; i += 2)
                        {
                            kural2cift += Convert.ToInt32(rakamlar[i].ToString());
                        }
                        char[] birlerbasamagikural2 = ((7 * kural2tek) + (9 * kural2cift)).ToString().ToCharArray();

                        int kural3 = 0;

                        for (int i = 0; i < 10; i += 2)
                        {
                            kural3 += Convert.ToInt32(rakamlar[i].ToString());
                        }
                        char[] birlerbasamagikural3 = (8 * kural3).ToString().ToCharArray();

                        if ((birlerbasamagikural1[birlerbasamagikural1.Length - 1] == hane11) && (birlerbasamagikural2[birlerbasamagikural2.Length - 1] == hane10) && (birlerbasamagikural3[birlerbasamagikural3.Length - 1] == hane11))
                        {
                            durum = "Kimlik Numarası Geçerli";
                        }
                        else
                        {
                            durum = "Kimlik Numarası Geçerli Değildir Lütfen Kontrol Ediniz!!!";
                        }
                    }
                    else
                    {
                        durum = "TC Kimlik Numaranızı Eksik Girdiniz Lütfen Kontrol Ediniz!!!";
                    }
                }
                else
                {
                    durum = "Lütfen TC Kimlik Numaranızı Giriniz!!!";
                }
            }
            catch (Exception ex)
            {
                durum = ex.Message;
            }
            return durum;
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            string a = (TcDogrula(textBox1.Text));
            MessageBox.Show(a);
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("A- Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("A+ Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("B- Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                MessageBox.Show("B+ Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                MessageBox.Show("AB- Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                MessageBox.Show("AB+ Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                MessageBox.Show("0- Kan Gurubunu Seçtiniz");
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                MessageBox.Show("0+ Kan Gurubunu Seçtiniz");
            }
            else
            {
                MessageBox.Show("Lütfen Bir Kan Grubu Seçiniz!!!");
            }
        }
    }
}

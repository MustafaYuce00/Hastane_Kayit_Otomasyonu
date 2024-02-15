using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace hastane_kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string bilgisayarAdi = Dns.GetHostName();
            label9.Text = "Bilgisayar Adı: " + bilgisayarAdi;
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            label10.Text = "Ip Adresi: " + ipAdresi;

        }
        private void button8_Click(object sender, EventArgs e)
        {       
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange =
                    (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView1.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Range myRange =
                            (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        myRange.Select();
                    }
                    catch
                    {
                        ;
                    }
                }
            }
        }
        public void button1_Click1(object sender, EventArgs e)
        {
            Form2 yenihasta = new Form2();
            DialogResult result = yenihasta.ShowDialog();

            if (result==DialogResult.OK)
            {
                dataGridView1.Rows.Add(yenihasta.Tc, yenihasta.Ad, yenihasta.Soyad,yenihasta.Kan,yenihasta.Tel);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView2.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange =
                    (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView2.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Range myRange =
                            (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dataGridView2[j, i].Value == null ? "" : dataGridView2[j, i].Value;
                        myRange.Select();
                    }
                    catch
                    {
                        ;
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        { 
            Form3 yenidoktor = new Form3();
            DialogResult result = yenidoktor.ShowDialog();

            if (result == DialogResult.OK)
            {
                dataGridView2.Rows.Add(yenidoktor.Tc,yenidoktor.Ad,yenidoktor.Soyad,yenidoktor.Bölüm,yenidoktor.Tel);
            }
        }
        private void eskirenk(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(26, 115, 232);
        }
        private void yenirenk(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(27, 102, 202);
        }
        private void eskirenk1(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(26, 115, 232);
        }
        private void yenirenk1(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(27, 102, 202);
        }
        private void eskirenk2(object sender, EventArgs e)
        {
            button2.BackColor = Color.Goldenrod;
        }
        private void yenirenk2(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(253, 184,61);
        }
        private void eskirenk3(object sender, EventArgs e)
        {
            button1.BackColor = Color.Goldenrod;
        }
        private void yenirenk3(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(253, 184, 61);
        }
        
        int saniye = 0;
        int dakika = 0;
        int saat = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }


            if (dakika == 60)
            {
                dakika = 0;
                saat++;
            }

            label6.Text = saniye.ToString();
            label5.Text = dakika.ToString();
            label4.Text = saat.ToString();

            label7.Text = DateTime.Now.ToLongDateString();
            label8.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label11.Left > -2000)
            {
                label11.Left -= 8;
            }
            else
            {
                label11.Left = 800;
            }
        }

     
    }
}

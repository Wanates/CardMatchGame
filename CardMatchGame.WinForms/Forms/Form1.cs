using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CardMatchGame.WinForms
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "u","d","z","p","b","7","t","5","k",".","a","g","h","j",
            "u","d","z","p","b","7","t","5","k",".","a","g","h","j"
        };

        Random rnd = new Random();
        //int randomindex;
        Button first, second;

        int skor1 = 0, skor2 = 0, sayac, tiksayac, hamle = 0;
        int saniye1 = 0;
        int saniye2 = 13;

        public Form1()
        {
            // 1) HER ŞEYDEN ÖNCE
            InitializeComponent();

            // 2) Açılış görünümleri
            oyuncu2NameTextBox.Visible = false;
            oyuncu1NameTextBox.Visible = false;
            oyuncu1Name.Visible = false;
            oyuncu2Name.Visible = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            label3.Visible = false;
            label4.Visible = false;

            // 3) Olay bağlama (gerekliyse)
            timer1.Tick += Timer1_Tick;
            timer2.Tick += Timer2_Tick;
            timer3.Tick += timer3_Tick_1;
            timer4.Tick += timer4_Tick;
        }


        private void panel2_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Lütfen oyuncu sayısını seçiniz.");
                return;
            }
            if (radioButton1.Checked && string.IsNullOrWhiteSpace(oyuncu1NameTextBox.Text))
            {
                MessageBox.Show("Lütfen oyuncunun adını doldurun.");
                return;
            }
            if (radioButton2.Checked && (string.IsNullOrWhiteSpace(oyuncu1NameTextBox.Text) || string.IsNullOrWhiteSpace(oyuncu2NameTextBox.Text)))
            {
                MessageBox.Show("Lütfen her iki oyuncunun da adını doldurun.");
                return;
            }
            if (radioButton1.Checked && !checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Lütfen bir süre seçiniz.");
                return;
            }

            show();
            panel2.Enabled = false;
            groupBox1.Enabled = false;

            timer1.Interval = 3000; // 3 sn açık göster
            timer1.Start();

            if (radioButton1.Checked)
            {
                timer3.Interval = 1000; // tek oyuncu toplam süre
                timer3.Start();
            }
            else
            {
                saniye2 = 10;          // çift oyuncu tur süresi
                sure.Text = saniye2.ToString();
                timer4.Interval = 1000;
                timer4.Start();
            }

            oyuncu2NameTextBox.Visible = false;
            oyuncu1NameTextBox.Visible = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            oyuncu1.Visible = true;
            puan1.Visible = true;
            oyuncu2.Visible = false;
            puan2.Visible = false;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            label3.Visible = true;
            label4.Visible = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            oyuncu1.Visible = true;
            puan1.Visible = true;
            oyuncu2.Visible = true;   // DÜZELTME: eskiden false idi
            puan2.Visible = true;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked) return;

            saniye1--;
            sure.Text = Convert.ToString(saniye1);
            if (saniye1 <= 0)
            {
                timer3.Stop();
                MessageBox.Show("Süre doldu!");
                Close();
                return;
            }

            // Görünürlük eşiği
            if (checkBox1.Checked) sure.Visible = saniye1 <= 60;
            if (checkBox2.Checked) sure.Visible = saniye1 <= 120;
            if (checkBox3.Checked) sure.Visible = saniye1 <= 180;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (!radioButton2.Checked) return;

            saniye2--;
            sure.Text = Convert.ToString(saniye2);
            if (saniye2 <= 0)
            {
                timer4.Stop();
                MessageBox.Show("Sıra karşı tarafa geçti");
                oyuncu1.Visible = !oyuncu1.Visible;
                oyuncu2.Visible = !oyuncu2.Visible;

                saniye2 = 10;
                sure.Text = Convert.ToString(saniye2);
                timer4.Start();
            }

            sure.Visible = saniye2 <= 10;
        }

        private void show()
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                int idx = rnd.Next(icons.Count);
                btn.Text = icons[idx];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(idx);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (Button item in Controls.OfType<Button>())
                item.ForeColor = item.BackColor; // kapat
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                saniye1 = 123;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                saniye1 = 63;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                saniye1 = 183;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bool two = radioButton2.Checked;
            oyuncu2Name.Visible = two;
            oyuncu1Name.Visible = two || radioButton1.Checked;
            oyuncu2NameTextBox.Visible = two;
            oyuncu1NameTextBox.Visible = two || radioButton1.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool one = radioButton1.Checked;
            oyuncu2Name.Visible = false;
            oyuncu1Name.Visible = one;
            oyuncu2NameTextBox.Visible = false;
            oyuncu1NameTextBox.Visible = one;
        }

        private void oyuncu1NameTextBox_TextChanged(object sender, EventArgs e)
            => oyuncu1Name.Text = oyuncu1NameTextBox.Text;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void oyuncu2NameTextBox_TextChanged(object sender, EventArgs e)
            => oyuncu2Name.Text = oyuncu2NameTextBox.Text;

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            if (first != null) first.ForeColor = first.BackColor;
            if (second != null) second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private Button lastClickedButton = null;
        private string lastClickedText = "";

        private void Buton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == lastClickedButton) return;

            tiksayac++;

            if (lastClickedButton != null && lastClickedText == btn.Text)
            {
                lastClickedButton.Enabled = false;
                btn.Enabled = false;
                lastClickedButton = null;
                lastClickedText = "";
            }
            else
            {
                lastClickedText = btn.Text;
                lastClickedButton = btn;
            }

            if (tiksayac % 2 == 0 && radioButton2.Checked)
            {
                oyuncu1.Visible = !oyuncu1.Visible;
                oyuncu2.Visible = !oyuncu2.Visible;
                oyuncu2Name.Text = oyuncu2NameTextBox.Text;
                oyuncu1Name.Text = oyuncu1NameTextBox.Text;
                saniye2 = 10;
                sure.Text = Convert.ToString(saniye2);
                timer4.Start();
            }

            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }

            second = btn;
            second.ForeColor = Color.Black;

            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;

                if (radioButton1.Checked)
                {
                    hamle++;
                    label4.Text = hamle.ToString();
                    skor1++;
                }

                if (oyuncu2.Visible) skor1++; else skor2++;

                puan1.Text = skor1.ToString();
                puan2.Text = skor2.ToString();

                sayac++;
                if (sayac == 14)
                {
                    if (radioButton2.Checked)
                    {
                        timer4.Stop();
                        if (skor1 > skor2) MessageBox.Show(oyuncu1Name.Text + " Kazandı!");
                        else if (skor2 > skor1) MessageBox.Show(oyuncu2Name.Text + " Kazandı!");
                        else MessageBox.Show("Berabere");
                        Close();
                    }
                    else
                    {
                        timer3.Stop();
                        MessageBox.Show("Tebrikler Oyunu Bitirdiniz!  Hamle Sayınız: " + hamle);
                        Close();
                    }
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    hamle++;
                    label4.Text = hamle.ToString();
                }
                timer2.Interval = 300;
                timer2.Start();
            }
        }
        private void puan2_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void oyuncu2Name_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void oyuncu1_Click(object sender, EventArgs e) { }
        private void oyuncu2_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void puan1_Click(object sender, EventArgs e) { }


    }
}

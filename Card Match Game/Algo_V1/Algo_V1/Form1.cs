using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algo_V1
{
    public partial class Form1 : Form
    {
        private const int MaxHamleSayisi = 14;
        private const int TekOyuncuSaniye1 = 63;
        private const int TekOyuncuSaniye2 = 123;
        private const int TekOyuncuSaniye3 = 183;
        private const int CiftOyuncuSaniye = 10;

        private List<string> _icons = new List<string>()
        {
          "u","d","z","p","b","7","t","5","k",".","a","g","h","j",
          "u","d","z","p","b","7","t","5","k",".","a","g","h","j"
        };
        private Random _rnd = new Random();
        private Button _first, _second;
        private int _skor1 = 0, _skor2 = 0, _sayac = 0, _tikSayac = 0, _hamle = 0;
        private int _saniye1 = 0;
        private int _saniye2 = 13;

        public Form1()
        {
            InitializeComponent();
            oyuncu2NameTextBox.Visible = false;
            oyuncu1NameTextBox.Visible = false;
            oyuncu1Name.Visible = false;
            oyuncu2Name.Visible = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void panel2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Lütfen oyuncu sayısını seçiniz.");
            }
            else if (radioButton1.Checked && (string.IsNullOrWhiteSpace(oyuncu1NameTextBox.Text))) { MessageBox.Show("Lütfen Oyuncunun adını doldurun."); }
            else if (radioButton2.Checked && (string.IsNullOrWhiteSpace(oyuncu1NameTextBox.Text) || string.IsNullOrWhiteSpace(oyuncu2NameTextBox.Text)))
            {
                MessageBox.Show("Lütfen her iki oyuncunun da adını doldurun.");
            }
            else if (radioButton1.Checked && (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked))
            {
                MessageBox.Show("Lütfen bir süre seçiniz.");
            }
            else
            {
                ShowIconsOnButtons();
                panel2.Enabled = false;
                groupBox1.Enabled = false;

                timer1.Tick += Timer1_Tick;
                timer1.Start();
                timer1.Interval = 3000;
                timer2.Tick += Timer2_Tick;
                timer2.Interval = 1000;

                timer3.Interval = 1000;
                timer3.Start();
                timer4.Interval = 1000;
                timer4.Start();
                oyuncu2NameTextBox.Visible = false;
                oyuncu1NameTextBox.Visible = false;
            }

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
            oyuncu2.Visible = false;
            puan2.Visible = true;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            label3.Visible = false;
            label4.Visible = false;

        }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {

                _saniye1--;
                UpdateSureLabel(_saniye1);
                if (_saniye1 == 0)
                {
                    timer3.Stop();
                    MessageBox.Show("Süre doldu!");
                    this.Close();
                }
                if (checkBox1.Checked)
                {
                    if (_saniye1 > 60)
                    {
                        sure.Visible = false;
                    }
                    else { sure.Visible = true; }

                }
                if (checkBox2.Checked)
                {
                    if (_saniye1 > 120)
                    {
                        sure.Visible = false;
                    }
                    else { sure.Visible = true; }

                }
                if (checkBox3.Checked)
                {
                    if (_saniye1 > 180)
                    {
                        sure.Visible = false;
                    }
                    else { sure.Visible = true; }

                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                _saniye2--;
                UpdateSureLabel(_saniye2);
                if (_saniye2 == 0)
                {
                    timer4.Stop();
                    MessageBox.Show("Sıra Karşı Tarafa Geçti");
                    TogglePlayers();
                }
                if (_saniye2 > 10)
                {
                    sure.Visible = false;
                }
                else
                {
                    sure.Visible = true;
                }

            }
        }

        private void puan2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (Button item in Controls.OfType<Button>())
            {
                item.ForeColor = item.BackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                _saniye1 = TekOyuncuSaniye2;
                checkBox1.Checked = false;
                checkBox3.Checked = false;

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _saniye1 = TekOyuncuSaniye1;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                _saniye1 = TekOyuncuSaniye3;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                oyuncu2Name.Visible = true;
                oyuncu1Name.Visible = true;
                oyuncu2NameTextBox.Visible = true;
                oyuncu1NameTextBox.Visible = true;
            }
            else
            {
                oyuncu2Name.Visible = false;
                oyuncu1Name.Visible = false;
                oyuncu2NameTextBox.Visible = false;
                oyuncu1NameTextBox.Visible = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                oyuncu2Name.Visible = false;
                oyuncu1Name.Visible = true;
                oyuncu2NameTextBox.Visible = false;
                oyuncu1NameTextBox.Visible = true;

            }
            else
            {
                oyuncu2Name.Visible = false;
                oyuncu1Name.Visible = false;
                oyuncu2NameTextBox.Visible = false;
                oyuncu1NameTextBox.Visible = false;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void oyuncu1NameTextBox_TextChanged(object sender, EventArgs e)
        {
            oyuncu1Name.Text = oyuncu1NameTextBox.Text;
        }

        private void oyuncu2NameTextBox_TextChanged(object sender, EventArgs e)
        {
            oyuncu2Name.Text = oyuncu2NameTextBox.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void oyuncu1_Click(object sender, EventArgs e)
        {

        }

        private void oyuncu2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void puan1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /*private void panel3_Click(object sender, EventArgs e)
        {

        }*/

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 300;
            timer2.Start();
            timer2.Stop();
            _first.ForeColor = _first.BackColor;
            _second.ForeColor = _second.BackColor;
            _first = null;
            _second = null;
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == _first) return; // Aynı butona tıklanırsa çık

            _tikSayac++;

            if (_first == null)
            {
                _first = btn;
                _first.ForeColor = Color.Black;
                return;
            }
            _second = btn;
            _second.ForeColor = Color.Black;

            bool isMatch = _first.Text == _second.Text;
            if (isMatch)
            {
                _first.Enabled = false;
                _second.Enabled = false;
                _first = null;
                _second = null;
            }
            else
            {
                timer2.Start();
                timer2.Interval = 300;
            }

            UpdateScores(isMatch);

            if (isMatch)
                _sayac++;

            if (_tikSayac % 2 == 0 && radioButton2.Checked)
                TogglePlayers();

            if (_sayac == MaxHamleSayisi)
                EndGame();
        }

        private void UpdateSureLabel(int saniye)
        {
            sure.Text = saniye.ToString();
            sure.Visible = saniye <= 60;
        }

        private void ShowIconsOnButtons()
        {
            var iconsCopy = new List<string>(_icons); // Orijinali bozmamak için kopya
            foreach (Button btn in Controls.OfType<Button>())
            {
                if (iconsCopy.Count == 0) break;
                int index = _rnd.Next(iconsCopy.Count);
                btn.Text = iconsCopy[index];
                btn.ForeColor = Color.Black;
                iconsCopy.RemoveAt(index);
            }
        }

        private void ResetGame()
        {
            _skor1 = 0;
            _skor2 = 0;
            _sayac = 0;
            _hamle = 0;
            // Diğer gerekli sıfırlamalar
        }

        // İki butonun eşleşip eşleşmediğini kontrol eder
        private void CheckButtonMatch(Button btn)
        {
            // ...
        }

        private void TogglePlayers()
        {
            oyuncu1.Visible = !oyuncu1.Visible;
            oyuncu2.Visible = !oyuncu2.Visible;
            oyuncu2Name.Text = oyuncu2NameTextBox.Text;
            oyuncu1Name.Text = oyuncu1NameTextBox.Text;
            _saniye2 = CiftOyuncuSaniye;
            UpdateSureLabel(_saniye2);
            timer4.Start();
        }

        private void UpdateScores(bool isMatch)
        {
            if (radioButton1.Checked)
            {
                _hamle++;
                label4.Text = _hamle.ToString();
                if (isMatch) _skor1++;
            }
            else
            {
                if (oyuncu2.Visible)
                    _skor1 += isMatch ? 1 : 0;
                else
                    _skor2 += isMatch ? 1 : 0;
            }
            puan1.Text = _skor1.ToString();
            puan2.Text = _skor2.ToString();
        }

        private void EndGame()
        {
            if (radioButton2.Checked)
            {
                timer4.Stop();
                if (_skor1 > _skor2)
                    MessageBox.Show(oyuncu1Name.Text + " Kazandı!");
                else if (_skor1 < _skor2)
                    MessageBox.Show(oyuncu2Name.Text + " Kazandı!");
                else
                    MessageBox.Show("Berabere");
                Close();
            }
            else if (radioButton1.Checked)
            {
                timer3.Stop();
                MessageBox.Show("Tebrikler Oyunu Bitirdiniz!  Hamle Sayınız: " + _hamle);
                Close();
            }
        }
    }
}

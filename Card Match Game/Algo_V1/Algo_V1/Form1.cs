    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    //using System.String;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Algo_V1
    {
        public partial class Form1 : Form
        {
            List<string> icons = new List<string>()
            {
              "u","d","z","p","b","7","t","5","k",".","a","g","h","j",
              "u","d","z","p","b","7","t","5","k",".","a","g","h","j"
            };
            Random rnd = new Random();
            int randomindex;
            Button first, second;
            Timer t1 = new Timer();
            Timer t2 = new Timer();
            Timer t3 = new Timer();
            int skor1=0, skor2=0, sayac, tiksayac, hamle=0;
            int saniye1 = 0;
            int saniye2 = 13;
        


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
            
                if (radioButton1.Checked ==false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Lütfen oyuncu sayısını seçiniz.");
                }
                else if (radioButton1.Checked && (string.IsNullOrWhiteSpace(oyuncu1NameTextBox.Text))){ MessageBox.Show("Lütfen Oyuncunun adını doldurun."); }
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
                    show();
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

            private void groupBox1_Enter(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

        private void timer3_Tick_1(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {

                saniye1--;
                sure.Text = Convert.ToString(saniye1);
                if (saniye1 == 0)
                {
                    timer3.Stop();
                    MessageBox.Show("Süre doldu!");
                    this.Close();
                }
                if (checkBox1.Checked)
                {
                    if (saniye1 > 60)
                    {
                        sure.Visible = false;
                    }
                    else { sure.Visible = true; }

                }
                if (checkBox2.Checked)
                {
                    if (saniye1 > 120)
                    {
                        sure.Visible = false;
                    }
                    else { sure.Visible = true; }

                }
                if (checkBox3.Checked)
                {
                    if (saniye1 > 180)
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
                    saniye2--;
                    sure.Text = Convert.ToString(saniye2);
                    if (saniye2 == 0)
                    {
                    timer4.Stop();
                    MessageBox.Show("Sıra Karşı Tarafa Geçti");
                    oyuncu1.Visible = !oyuncu1.Visible; 
                    oyuncu2.Visible = !oyuncu2.Visible; 
                   
                    
                    saniye2 = 10; 
                    sure.Text = Convert.ToString(saniye2); 
                    timer4.Start();
                   
                }
                if (saniye2 > 10)
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

        private void show()
            {
                Button btn;
                foreach (Button item in Controls.OfType<Button>())
                {
                    { btn = item as Button;
                        randomindex = rnd.Next(icons.Count);
                        btn.Text = icons[randomindex];
                    
                    btn.ForeColor = Color.Black;
                        icons.RemoveAt(randomindex);
                    }
                }

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

                timer2.Stop();
                first.ForeColor = first.BackColor;
                second.ForeColor = second.BackColor;
                first = null;
                second = null;
            }
        private Button lastClickedButton = null;
        private string lastClickedText = "";

        
        private void Buton_Click(object sender, EventArgs e)
            {
            
            Button btn = sender as Button;

            if (btn == lastClickedButton)
            {
                return;
            }
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
            };
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
                    if (radioButton1.Checked==true)
                    {
                    hamle++;
                    label4.Text = Convert.ToString(hamle);
                    skor1++;
                    }
                   if (oyuncu2.Visible == true)
                    {
                    skor1++;
                    }
                   else { skor2++; }
                puan1.Text = Convert.ToString(skor1);
                puan2.Text = Convert.ToString(skor2);
                sayac++;
                    if (sayac==14)
                    {
                       if(radioButton2.Checked==true) { 
                        timer4.Stop();
                        if (skor1 > skor2) { 
                        MessageBox.Show(oyuncu1Name.Text + " Kazandı!");
                        Close();
                    }
                    else if (skor1 < skor2)
                    {
                        MessageBox.Show(oyuncu2Name.Text + " Kazandı!");
                        Close();
                    }
                     else
                    {
                        MessageBox.Show("Berabere");
                        Close();
                    }
                    }
                      else if (radioButton1.Checked == true) 
                    {
                        timer3.Stop();
                        MessageBox.Show("Tebrikler Oyunu Bitirdiniz!"  + "  Hamle Sayınız: " + hamle);
                        this.Close();
                    }
                     
                }

                }
                else
                {
                if (radioButton1.Checked == true)
                {
                    hamle++;
                    label4.Text = Convert.ToString(hamle);
                }
                
                    timer2.Start();
                    timer2.Interval = 300;
                    
                }
           
            }
        }
    }

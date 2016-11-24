using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batAlgorithm
{
    public partial class greedyCoin : Form
    {
        public greedyCoin()
        {
            InitializeComponent();
        }
        //Max is number of iteration is 100 in this problem
        double[] frequency;
        double[] distances;
        private void button1_Click(object sender, EventArgs e)
        {
            //Distances
            //x1(15cm) x2(15cm)	x3(50cm)	x4(80cm)	x5(40cm)	x6(40cm)	x7(500cm	x8(500cm)	x9(400cm)	x10(150cm) 
            distances = new double[10];
            distances[0] = 15; distances[1] = 15; distances[2] = 50; distances[3] = 80; distances[4] = 40; distances[5] = 40; distances[6] = 500; distances[7] = 500; distances[8] = 400; distances[9] = 150;
        
            //////////////

            double amount = 0;
            int cents = 0;
            int count = 0;
            int amount_left = 0;

            amount = 0.3;

            cents = (int)Math.Round(amount * 100);

           MessageBox.Show("%d\n"+ cents);

            amount_left = cents;

            while (amount_left >= 25)
            {
                count++;
                amount_left -= 25;
            }
            while (amount_left >= 10)
            {
                count++;
                amount_left -= 10;
            }
            while (amount_left >= 5)
            {
                count++;
                amount_left -= 5;
            }
            while (amount_left >= 1)
            {
                count = count + 1;
                amount_left -= 1;
            }
           MessageBox.Show("You get %d coins\n"+ count);


        }

        private void greedyCoin_Load(object sender, EventArgs e)
        {
            

        }
        
        int i = 0; int deger = 1000;
  
        private void button2_Click(object sender, EventArgs e)
        {
        
            timer1.Start();
          
       
            
        }
        Random yeni; int a;
        public void kontrol()
        {
            if (i == 1)
            {
                //Yeni process
                this.newPictureBox.Image = global::batAlgorithm.Properties.Resources.new2;
                //this.newPictureBox.BackColor = Color.Red;
            }

            if (i == 2)
            {
                label1.Text = "Kabul edildi";
              
                //Hazır
                this.admittedPictureBox.Image = global::batAlgorithm.Properties.Resources.admitted;
            }
            if (i == 3)
            {
                //******
                this.readyPictureBox.Image = global::batAlgorithm.Properties.Resources.ready;

            }
            if (i == 4)
            {
                label1.Text = "Planlama yapıldı";
                //******
                this.schedularPictureBox.Image = global::batAlgorithm.Properties.Resources.schedular;
            }
            if (i == 5)
            {
                label1.Text = "Calisiyor";
                //******
                this.runningPictureBox.Image = global::batAlgorithm.Properties.Resources.running;
            }
            if (i == 5)
            {
                 yeni = new Random();
                a=yeni.Next(1, 5);
                if (a == 2)
                {
                    label1.Text = "Kesme";
                    this.interruptPictureBox.Image = global::batAlgorithm.Properties.Resources.interrupt;

                }
                else if (a == 3)
                {
                    label1.Text = "I/O Bekleme";
                    this.waitingPictureBox.Image = global::batAlgorithm.Properties.Resources.waiting;

                }
                else {
                    label1.Text = "Exit";
                    this.exitPictureBox.Image = global::batAlgorithm.Properties.Resources.exit;
                    this.terminatedPictureBox.Image = global::batAlgorithm.Properties.Resources.terminated;

                }
            }
            if (i == 6) {
                this.newPictureBox.Image = null;
                this.admittedPictureBox.Image = null;
                this.readyPictureBox.Image = null;
                this.schedularPictureBox.Image = null;
                this.runningPictureBox.Image = null;
                this.interruptPictureBox.Image = null;
                this.waitingPictureBox.Image = null;
                this.exitPictureBox.Image = null;
                this.terminatedPictureBox.Image = null;
                i = 0;
            }
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            kontrol();
        }
   
        //public void saat(Stopwatch a)
        //{
           
        //     a = new Stopwatch();
        //    a.Start();

        //    while (a.ElapsedMilliseconds < deger)
        //    {
        //        i++;
        //    }
        //    a.Stop();
            
        //}
    }
}

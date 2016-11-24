using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Max is number of iteration is 100 in this problem
        double[] frequency;
        double[] distances;
        private void button1_Click(object sender, EventArgs e)
        {
            // written for observing test results
            string lines = "";

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\pc\Desktop\review.txt");
         
            //We will deploy bat-inspired algorithm through test case execution times and its triggered faults
            //t1(1.5ms)	t2(1.5ms)	t3(0.5ms)	t4(0.8ms)	t5(0.4ms)	t6(0.4ms)	t7(5ms	t8(5ms)	t9(4ms)	t10(1.5ms)
           //t6t9t7(2 faults, others one) Ai is high in these test cases
            //we have one velocity because of one bat
            double lambda, velocity,randCompare,increase,decrease;
            int indis,compare=0,found;
            int[] searchForIndex=new int[9];
            string position = "x1";
            lambda = 1;
            velocity = 5;
            
            //var myData = new List<Tuple<string, double, double>>();

            //myData.Add(new Tuple<string, double, double>(position, lambda, velocity));
            //MessageBox.Show("" + myData[0].Item1);
                
                //////////////////////////////////////////////////////
            //Distances
            //x1(15cm) x2(15cm)	x3(50cm)	x4(80cm)	x5(40cm)	x6(40cm)	x7(500cm	x8(500cm)	x9(400cm)	x10(150cm) 
           distances = new double[10];
            //Change distances according to your test case spaces
           distances[0] = 15; distances[1] = 15; distances[2] = 50; distances[3] = 80; distances[4] = 40; distances[5] = 40; distances[6] = 500; distances[7] = 500; distances[8] = 400; distances[9] = 150;
               frequency = new double[10];
            //Using inverse ratio, all the frequencies are determined
               frequency[0] = 80; frequency[1] = 80; frequency[2] = 24; frequency[3] = 15; frequency[4] = 30; frequency[5] = 30; frequency[6] = 3; frequency[7] = 3; frequency[8] = 4; frequency[9] = 8;

            //ra
               rA = new List<Tuple<double, double,int>>();
            //ınitialize population xi and vi after distances determination
            initializePop();
            //assign ri and ai by looking the frequencies and faultness (a is 10 for one fault, a is 20 for two faults)
               for (int j = 0; j < frequency.Length; j++)
               {
                   //these test cases have two faults.
                   if (j == 5 || j == 6||j==8)
                   rA.Add(new Tuple<double, double,int>(pulseEmission(frequency[j]/100),20,j));
                   else
                   rA.Add(new Tuple<double, double,int>(pulseEmission(frequency[j] /100), 10,j));
                   //MessageBox.Show("proxi=" + frequency[j] / 100 +","+ "emission-" + j + "=" + rA[j].Item1);
                   //lines+= "proxi=" + frequency[j] / 100 + "," + "emission-" + j + "=" + rA[j].Item1;
                   //lines += Environment.NewLine;
                   

                 
               }
           
            int t=0;
            List<Tuple<int, int>> kucukBuyuk = fMinMax(frequency);
            //MessageBox.Show("min and max" + frequency[kucukBuyuk[0].Item1] + "    " + frequency[kucukBuyuk[0].Item2]);
            //Find local optimum solution by ordering ri and ai
            List<Tuple<double, double,int>> rANew = xStar(rA);
           
                while (t < 20)
                {
                    //fi=fmin+(fmax-fmin)Beta(2), vi=vi+(xi-x*)fi(3)
                    //generate new solutions by adjusting frequency
                    for (int j = 0; j < frequency.Length; j++)
                    {
                       
                    
                        frequency[j] = frequency[kucukBuyuk[0].Item1] + (frequency[kucukBuyuk[0].Item2] - frequency[kucukBuyuk[0].Item1]) * generateBeta();
                        velocity = velocity + (pop[j].Item1 - rANew[0].Item1);
                          randCompare = rand();
                          if (progressBar1.Value < 100)
                              progressBar1.Value += 5;
                          //if (rand > ri)
                              if (randCompare > rANew[j].Item1)
                              {
                                  //generate new solution by flying randomly
                                  rANew = xStar(rANew);

                              }
                              else
                              {
                                  //increase ri reduce ai
                                  increase = rANew[j].Item1;
                                  decrease = rANew[j].Item2;
                                  increase += 0.1;
                                  decrease -= 1;
                                  indis = rANew[j].Item3;

                                  rANew.RemoveAt(j);

                                  rANew.Add(new Tuple<double, double, int>(increase, decrease, indis));
                              }
                     }

                    for (int k = 0; k < 10; k++)
                    {
                        riListBox.Items.Add(rANew[k].Item1);
                        aiListBox.Items.Add(rANew[k].Item2);
                        indexListBox.Items.Add(rANew[k].Item3);
                    }
                    riListBox.Items.Add("*");
                    aiListBox.Items.Add("*");
                    indexListBox.Items.Add("*");

                    for (int j = 0; j < rANew.Count; j++)
                    {
                        if (j == rANew.Count - 1)
                        {
                            lines += "T" + rANew[j].Item3.ToString();
                        }

                        else{
                            lines += "T" + rANew[j].Item3.ToString() + ",";
                        }



                    }
                    lines += Environment.NewLine;

                    //fmin and fmax find


                    t++;
                }
              
        
             
                file.WriteLine(lines);
                file.Close();

        }
        //rand function to compare if(rand>ri)
        public double rand()
        {
            double sonuc;
            int a = (int)System.DateTime.Now.Ticks;
            System.Random random = new System.Random(a);
            Thread.Sleep(1);

            sonuc = random.NextDouble();

            return sonuc;
        }
        //find best solution x* ordering operations
        public List<Tuple<double, double,int>> xStar(List<Tuple<double, double,int>> taken)
        {
           //first order by pulseEmission then loudness(faults)
          var sonuc= taken.OrderBy(x => x.Item1).ThenBy(x => x.Item2);
          List<Tuple<double, double, int>> sonuc1 = sonuc.ToList();
            return sonuc1;
        }
        ///////////////////////////RANDOM ORDERINGII////////////////////////////////
        public void randomOrdering2()
        {
            int number=0; int flag = 0;
            Random random = new Random();
            int[] dizi = new int[10];
     
            for (int j = 0; j < 10; j++)
            {
             
                while (dizi.Contains(number))
                {
                    number = random.Next(0, 9);
                    dizi[j]=number;
                }

                if (flag == 0)
                {
                    number = random.Next(0, 9);
                    dizi[j]=number;
                } flag++;
            }
       
            for (int j = 0; j < 10; j++)            
                MessageBox.Show("" + dizi[j]);
            
        }
          
        
        ///////////////////////////RANDOM ORDERING////////////////////////////////
        public List<Tuple<double, double, int>> randomOrdering(List<Tuple<double, double, int>> taken)
        {
            Random deger = new Random();
            int indis=0; double items1, items2; int flag = 0;
            List<int> generated = new List<int>();
            List<Tuple<double, double, int>> sonuc1 = taken.ToList();
            List<Tuple<double, double, int>> sonuc2 = new List<Tuple<double, double, int>>();
            for (int j = 0; j < sonuc1.Count;j++ )
            {
                items1 = sonuc1[j].Item1;
                items2 = sonuc1[j].Item2;
                if (flag == 0)
                {
                    indis = deger.Next(0, 9);
                    generated.Add(indis);
                    MessageBox.Show("1. eklenen=" + indis);
                }
                if (flag != 0)
                {
                    indis = deger.Next(0, 9);
                    while (generated.Contains(indis) == true)
                    {
                        indis = deger.Next(0, 9);
                    
                    }

                    MessageBox.Show(j+". eklenen=" + indis);
                }
            
                flag++;
                    sonuc2.Add(new Tuple<double, double, int>(items1, items2, indis));

            }
            return sonuc2;
        }

        // Function to  //fmin and fmax find
        public List<Tuple<int, int>> fMinMax(double[] a)
        {
            double fmin = a[0], fmax=a[0];
            List<Tuple<int, int>> sonuc = new List<Tuple<int, int>>();
            int indis1=0, indis2=0;
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] > fmax)
                {
                    fmax = a[j];
                    indis1 = j;
                }

            }
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] < fmin)
                {
                    fmin = a[j];
                    indis2 = j;
                }
            }
            sonuc.Add(new Tuple<int, int>(indis1, indis2));
            return sonuc;
        }


        //fmin=0, fmax=100
        //Distances
        //x1(15cm) x2(15cm)	x3(50cm)	x4(80cm)	x5(40cm)	x6(40cm)	x7(500cm	x8(500cm)	x9(400cm)	x10(150cm) 
        //xi and vi 
        List<Tuple< double, double>> pop;
        //ri ai
        List<Tuple<double, double,int>> rA;
        public void initializePop()
        {
            pop = new List<Tuple<double, double>>();
            //Start with an arbitrary Vi for Xi
            for (int i = 0; i < distances.Length;i++)
                pop.Add(new Tuple<double, double>(distances[i], 5));

        }
        //Generate beta
    
        public double generateBeta()
        {
            double sonuc ;
            int a = (int)System.DateTime.Now.Ticks;
            System.Random random = new System.Random(a);
            Thread.Sleep(1);
           
                    sonuc = random.NextDouble();
          
            return sonuc;
        }
        //Generate the value depending on the promximity of target of bat
        //r pulse emission is assigned according to proxi
        public double pulseEmission(double proxi)
        {
            double sonuc=0;
            int a = (int)System.DateTime.Now.Ticks;
            System.Random random = new System.Random(a);
            Thread.Sleep(1);
            if (proxi > 0.5)
            {
                sonuc = random.NextDouble();
                while (sonuc < 0.5)
                    sonuc = random.NextDouble();
            }
            else
            {
                sonuc = random.NextDouble();
                while (sonuc > 0.5)
                sonuc = random.NextDouble();
            }
            return sonuc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // double increase, decrease; int indis;
           // var myData = new List<Tuple< double, double,int>>();

           // myData.Add(new Tuple< double, double,int>(0.4,10,0));
           // myData.Add(new Tuple<double, double, int>(0.6, 10, 1));
           // myData.Add(new Tuple<double, double, int>(0.12, 10, 2));
           // myData.Add(new Tuple<double, double, int>(0.7, 10, 3));
           // myData.Add(new Tuple<double, double, int>(0.8, 10, 4));
           // myData.Add(new Tuple<double, double, int>(0.9, 10, 5));
           // myData.Add(new Tuple<double, double, int>(0.2, 10, 6));
           // myData.Add(new Tuple<double, double, int>(0.32, 10, 7));
           // myData.Add(new Tuple<double, double, int>(0.41, 10, 8));
           // myData.Add(new Tuple<double, double, int>(0.82, 10, 9));

           // //increase ri reduce ai
           // increase = myData[4].Item1;
           // decrease = myData[4].Item2;
           // increase += 0.01;
           // decrease -= 0.01;
           // indis = myData[4].Item3;

           // myData.RemoveAt(4);

           // myData.Add(new Tuple<double, double, int>(increase, decrease, indis));

           //for (int j = 0; j < 10; j++)
           //         {
           //             riListBox.Items.Add(myData[j].Item1);
           //             aiListBox.Items.Add(myData[j].Item2);
           //             indexListBox.Items.Add(myData[j].Item3);
           //         }
            // written for observing test results
            string write1 = "";

            // Write the string to a file.
           System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\pc\Desktop\review1.txt");

            //first calculation
            double[] a1=new double[10]{3,0,2,8,1,9,5,6,4,7};
            //while computing APFD, b1 is static that include the list of the order of faults (f1,...,fn) and shows their triggers (Tx,..Ty)
            double[] b1=new double[7]{1,3,4,5,6,7,9};
            apfd yeni = new apfd(a1, b1, 7, 10);
          
          
           string[] lines = File.ReadAllLines(@"C:\Users\pc\Desktop\review.txt", Encoding.UTF8);
           //!!!!!!!!!!!!!!Delete "," from the file by splitting          
            for (int j = 0; j < lines.Length; j++)
           {
          
               var fields = lines[j].Split(',');
             
               for (int k = 0; k < 10; k++)
               {
                   //MessageBox.Show("" + fields[k].ToString());
                   a1[k] = Convert.ToDouble(fields[k]);
                
               }
            

               yeni = new apfd(a1, b1, 7, 10);
       
               write1 += yeni.APFD().ToString();
               write1 += Environment.NewLine;
             
                  
           }
            file.WriteLine(write1);
            file.Close();
           
        }
        public static double[] aktarilan;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //// written for observing test results
            //string lines = "";

            //// Write the string to a file.
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\pc\Desktop\review.txt");

            ////We will deploy bat-inspired algorithm through test case execution times and its triggered faults
            ////t1(1.5ms)	t2(1.5ms)	t3(0.5ms)	t4(0.8ms)	t5(0.4ms)	t6(0.4ms)	t7(5ms	t8(5ms)	t9(4ms)	t10(1.5ms)
            ////t6t9t7(2 faults, others one) Ai is high in these test cases
            ////we have one velocity because of one bat
            //double lambda, velocity, randCompare, increase, decrease;
            //int indis, compare = 0, found;
            //int[] searchForIndex = new int[9];
            //string position = "x1";
            //lambda = 1;
            //velocity = 5;

            ////var myData = new List<Tuple<string, double, double>>();

            ////myData.Add(new Tuple<string, double, double>(position, lambda, velocity));
            ////MessageBox.Show("" + myData[0].Item1);

            ////////////////////////////////////////////////////////
            ////Distances
            ////x1(15cm) x2(15cm)	x3(50cm)	x4(80cm)	x5(40cm)	x6(40cm)	x7(500cm	x8(500cm)	x9(400cm)	x10(150cm) 
            //distances = new double[10];
            //distances[0] = 15; distances[1] = 15; distances[2] = 50; distances[3] = 80; distances[4] = 40; distances[5] = 40; distances[6] = 500; distances[7] = 500; distances[8] = 400; distances[9] = 150;
            //frequency = new double[10];
            ////Using inverse ratio, all the frequencies are determined
            //frequency[0] = 80; frequency[1] = 80; frequency[2] = 24; frequency[3] = 15; frequency[4] = 30; frequency[5] = 30; frequency[6] = 3; frequency[7] = 3; frequency[8] = 4; frequency[9] = 8;

            ////ra
            //rA = new List<Tuple<double, double, int>>();
            ////ınitialize population xi and vi after distances determination
            //initializePop();
            ////assign ri and ai by looking the frequencies and faultness (a is 10 for one fault, a is 20 for two faults)
            //for (int j = 0; j < frequency.Length; j++)
            //{
            //    //these test cases have two faults.
            //    if (j == 5 || j == 6 || j == 8)
            //        rA.Add(new Tuple<double, double, int>(pulseEmission(frequency[j] / 100), 20, j));
            //    else
            //        rA.Add(new Tuple<double, double, int>(pulseEmission(frequency[j] / 100), 10, j));
            // }

            //List<Tuple<double, double, int>> rANew;
            //int t=0,k=0;
            //while (t < 1)
            //{
            //    rANew = randomOrdering(rA);
            //    t++;
            //    for (int j = 0; j < rANew.Count; j++)
            //    {
            //        if (j == rANew.Count - 1)
            //        {
            //            lines += "T" + rANew[j].Item3.ToString();
            //        }

            //        else
            //        {
            //            lines += "T" + rANew[j].Item3.ToString() + ",";
            //        }



            //    }
            //    lines += Environment.NewLine;
            //}
            //file.Write(lines);
            //file.Close();
             randomOrdering2();
            MessageBox.Show("islem bitti");
        }
    }
}

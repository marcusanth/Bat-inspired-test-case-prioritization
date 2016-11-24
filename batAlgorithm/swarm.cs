using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batAlgorithm
{
    public partial class swarm : Form
    {
        public swarm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 77, y = 30;
            Label[] particles = new Label[10];
            for (int i = 0; i < 10; i++)
            {
                particles[i] = new System.Windows.Forms.Label();
                particles[i].Location = new System.Drawing.Point(x, y);
                x += 12;
                y += 1;
                particles[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                particles[i].Name = "labels" + i;
                particles[i].Size = new System.Drawing.Size(16, 20);
                particles[i].Text = "*";
                this.Controls.Add(particles[i]);
            }
          
             
        }
        int dim = 2; // problem dimensions
        int numParticles = 10;
        int maxEpochs = 1000;
        double exitError = 0.0; // exit early if reach this error
        double minX = -10.0; // problem-dependent
        double maxX = 10.0;
        private void swarm_Load(object sender, EventArgs e)
        {
            dimTextBox.Text = dim.ToString();
            numTextBox.Text = numParticles.ToString();
            epochTextBox.Text = maxEpochs.ToString();
            exitTextBox.Text = exitError.ToString("F4");
            minTextBox.Text = minX.ToString("F1") + " " + maxX.ToString("F1");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            double[] bestPosition; double bestError;int j=0;
        
            //while (j < 20)
            //{
                bestPosition = Solve(dim, numParticles, minX, maxX, maxEpochs, exitError);
                bestError = Error(bestPosition);
                for (int i = 0; i < bestPosition.Length; ++i)
                {
                    solutionTextBox.Text += "x" + i + " = ";
                    solutionTextBox.Text += bestPosition[i].ToString("F6") + " ";
                   // MessageBox.Show("x" + i + " = " + bestPosition[i].ToString("F6") + " ");
                }
            //}
            MessageBox.Show("Bitti");
          
        }
        static double Error(double[] x)
        {
            // 0.42888194248035300000 when x0 = -sqrt(2), x1 = 0
            double trueMin = -0.42888194; // true min for z = x * exp(-(x^2 + y^2))
            double z = x[0] * Math.Exp(-((x[0] * x[0]) + (x[1] * x[1])));
            return (z - trueMin) * (z - trueMin); // squared diff
        }
        //Used in bat, also in swarm for random number generation
        public double pulseEmission(double proxi)
        {
            double sonuc = 0;
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
        static double[] Solve(int dim, int numParticles, double minX, double maxX, int maxEpochs, double exitError)
        {
            System.IO.StreamWriter file1; string lines="";
            file1 = new System.IO.StreamWriter(@"C:\Users\pc\Desktop\review1.txt");
            ////x1(15cm) x2(15cm)	x3(50cm)	x4(80cm)	x5(40cm)	x6(40cm)	x7(500cm	x8(500cm)	x9(400cm)	x10(150cm) 
            double[] distances = new double[10];
            distances[0] = 15; distances[1] = 15; distances[2] = 50; distances[3] = 80; distances[4] = 40; distances[5] = 40; distances[6] = 500; distances[7] = 500; distances[8] = 400; distances[9] = 150;

            // assumes existence of an accessible Error function and a Particle class
            Random rnd = new Random(0);

            Particle[] swarm = new Particle[numParticles];
            double[] bestGlobalPosition = new double[dim]; // best solution found by any particle in the swarm
            double bestGlobalError = double.MaxValue; // smaller values better
            double gecici=0;
            swarm yeni = new swarm();
            // swarm initialization
            for (int i = 0; i < swarm.Length; ++i)
            {
                //MODIFICATION 1 according to the excution times by random number
                double[] randomPosition = new double[dim];
                for (int j = 0; j < randomPosition.Length; ++j)
                {
                    gecici=yeni.pulseEmission(distances[j] / 100);
                    randomPosition[j] = (maxX - minX) * (gecici) + minX; // 
                 //   MessageBox.Show("deneme" + randomPosition[j]);
                }

                double error = Error(randomPosition);
                double[] randomVelocity = new double[dim];
               
               
               
                for (int j = 0; j < randomVelocity.Length; ++j)
                {
                    double lo = minX * 0.1;
                    double hi = maxX * 0.1;
                    //MODIFICATION II according to the fault numbers
                    if (j == 5 || j == 6 || j == 8)
                    {
                        randomVelocity[j] = (hi - lo) * yeni.pulseEmission(0.9) + lo;
                    }
                    else
                    {
                        randomVelocity[j] = (hi - lo) * rnd.NextDouble() + lo;
                    }
                    lines += "velocity="+randomVelocity[j];
                    MessageBox.Show("velocities"+randomVelocity[j]);
                }
             
                lines += Environment.NewLine;
                swarm[i] = new Particle(randomPosition, error, randomVelocity, randomPosition, error);

                // does current Particle have global best position/solution?
                if (swarm[i].error < bestGlobalError)
                {
                    bestGlobalError = swarm[i].error;
                    swarm[i].position.CopyTo(bestGlobalPosition, 0);
                }
             
            } // initialization

            // prepare
            double w = 0.729; // inertia weight. see http://ieeexplore.ieee.org/stamp/stamp.jsp?arnumber=00870279
            double c1 = 1.49445; // cognitive/local weight
            double c2 = 1.49445; // social/global weight
            double r1, r2; // cognitive and social randomizations
            double probDeath = 0.01;
            int epoch = 0;

            double[] newVelocity = new double[dim];
            double[] newPosition = new double[dim];
            double newError;

            // main loop
            while (epoch < maxEpochs)
            {
                for (int i = 0; i < swarm.Length; ++i) // each Particle
                {
                    Particle currP = swarm[i]; // for clarity

                    // new velocity
                    for (int j = 0; j < currP.velocity.Length; ++j) // each component of the velocity
                    {
                        r1 = rnd.NextDouble();
                        r2 = rnd.NextDouble();

                        newVelocity[j] = (w * currP.velocity[j]) +
                          (c1 * r1 * (currP.bestPosition[j] - currP.position[j])) +
                          (c2 * r2 * (bestGlobalPosition[j] - currP.position[j]));
                    }
                    newVelocity.CopyTo(currP.velocity, 0);

                    // new position
                    for (int j = 0; j < currP.position.Length; ++j)
                    {
                        newPosition[j] = currP.position[j] + newVelocity[j];
                        if (newPosition[j] < minX)
                            newPosition[j] = minX;
                        else if (newPosition[j] > maxX)
                            newPosition[j] = maxX;
                    }
                    newPosition.CopyTo(currP.position, 0);

                    newError = Error(newPosition);
                    currP.error = newError;

                    if (newError < currP.bestError)
                    {
                        newPosition.CopyTo(currP.bestPosition, 0);
                        currP.bestError = newError;
                    }

                    if (newError < bestGlobalError)
                    {
                        newPosition.CopyTo(bestGlobalPosition, 0);
                        bestGlobalError = newError;
                    }

                    // death?
                    double die = rnd.NextDouble();
                    if (die < probDeath)
                    {
                        // new position, leave velocity, update error
                        for (int j = 0; j < currP.position.Length; ++j)
                            currP.position[j] = (maxX - minX) * rnd.NextDouble() + minX;
                        currP.error = Error(currP.position);
                        currP.position.CopyTo(currP.bestPosition, 0);
                        currP.bestError = currP.error;

                        if (currP.error < bestGlobalError) // global best by chance?
                        {
                            bestGlobalError = currP.error;
                            currP.position.CopyTo(bestGlobalPosition, 0);
                        }
                    }

                } // each Particle
                ++epoch;
            } // while

            // show final swarm
            Console.WriteLine("\nProcessing complete");
            Console.WriteLine("\nFinal swarm:\n");
            for (int i = 0; i < swarm.Length; ++i)
            {
                lines += swarm[i].ToString();
                lines += Environment.NewLine;
                MessageBox.Show(swarm[i].ToString());
            }
            file1.Write(lines);      
      
            file1.Close();
         
            double[] result = new double[dim];
            bestGlobalPosition.CopyTo(result, 0);
            return result;

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void swarm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Black))
            using (GraphicsPath capPath = new GraphicsPath())
            {
                // A triangle
                capPath.AddLine(-20, 0, 20, 0);
                capPath.AddLine(-20, 0, 0, 20);
                capPath.AddLine(0, 20, 20, 0);

                p.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);

                e.Graphics.DrawLine(p, 0, 50, 100, 50);
            }
        } // Solve
    }
    public class Particle
    {
        public double[] position;
        public double error;
        public double[] velocity;
        public double[] bestPosition;
        public double bestError;

        public Particle(double[] pos, double err, double[] vel, double[] bestPos, double bestErr)
        {
            this.position = new double[pos.Length];
            pos.CopyTo(this.position, 0);
            this.error = err;
            this.velocity = new double[vel.Length];
            vel.CopyTo(this.velocity, 0);
            this.bestPosition = new double[bestPos.Length];
            bestPos.CopyTo(this.bestPosition, 0);
            this.bestError = bestErr;
        }

        public override string ToString()
        {
            string s = "";
            s += "==========================\n";
            s += "Position: ";
            for (int i = 0; i < this.position.Length; ++i)
                           s += this.position[i].ToString("F4") + " ";
             
            
            s += "\n";
            s += "Error = " + this.error.ToString("F4") + "\n";
            s += "Velocity: ";
            for (int i = 0; i < this.velocity.Length; ++i)
                s += this.velocity[i].ToString("F4") + " ";
            s += "\n";
            s += "Best Position: ";
            for (int i = 0; i < this.bestPosition.Length; ++i)
                            s += this.bestPosition[i].ToString("F4") + " ";
         
          
            s += "\n";
            s += "Best Error = " + this.bestError.ToString("F4") + "\n";
            s += "==========================\n";
            for (int i = 0; i < this.position.Length; ++i)
                s += "differece=" + Convert.ToString(this.position[i] + this.bestPosition[i]);
            return s;
        }

    } // Particle
}

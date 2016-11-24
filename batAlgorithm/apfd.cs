using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace batAlgorithm
{
    public class apfd:Form
    {
        double[] testSuiteOrder;
        double[] faultsTriggerOrder;
        int m, n;
        public apfd(double[] a, double[]  b,int m1,int n2)
        {

            testSuiteOrder = a;
            faultsTriggerOrder=b;
            m = m1;
            n = n2;
        }
        public double APFD()
        {
            double value1, value2, result;
           
            List<int> forSum = new List<int>();
            for (int i = 0; i < faultsTriggerOrder.Length; i++)
            {
                for (int j = 0; j < testSuiteOrder.Length; j++)
                {
                    if (testSuiteOrder[j]==faultsTriggerOrder[i])
                    {
                        forSum.Add(j+1);
                       
                    }
                } 
            }
            
            value1 = forSum.Sum();
            value1 = value1 / (m * n);
            value2 = 1 / Convert.ToDouble(2*n);
            result = 1 - value1 + value2;
            //MessageBox.Show(""+value1+"  "+value2);
                return result;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // apfd
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "apfd";
            this.Load += new System.EventHandler(this.apfd_Load);
            this.ResumeLayout(false);

        }

        private void apfd_Load(object sender, EventArgs e)
        {

        }
    }
}

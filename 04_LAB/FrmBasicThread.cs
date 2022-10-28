using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_LAB_EXERCISE_ESCALONA
{
    public partial class FrmBasicThread : Form
    {
        public FrmBasicThread()
        {
            InitializeComponent();
        }

        private void FrmBasicThread_Load(object sender, EventArgs e)
        {

        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            label1.Text = "-Running...-";
            ThreadStart threadStart = new ThreadStart(MyThreadClass.Thread1);
            Console.WriteLine("-Before starting thread-");
            Thread ThreadA = new Thread(threadStart);
            Thread ThreadB = new Thread(threadStart);
            
            ThreadA.Name = "Thread A Process";
            ThreadB.Name = "Thread B Process";

            ThreadA.Start();
            ThreadB.Start();
            
            ThreadA.Join();
            ThreadB.Join();

            if (!ThreadA.IsAlive && !ThreadB.IsAlive)
            {
                label1.Text = "-End of Thread-";
                Console.WriteLine("-End of Thread-");
            }
                
        }
    }
}

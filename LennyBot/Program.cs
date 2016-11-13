using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LennyBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread threadForm = new Thread(new ThreadStart(FormThread));
                threadForm.Start();
                MyBot MyBot = new MyBot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error starting bot!");
                Console.Write(e);
                Console.ReadLine();
            }
        }

        [STAThread]
        static void FormThread()
        {
            mainForm mainForm = new mainForm();
                Application.EnableVisualStyles();
                Application.Run(mainForm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FChan.Library;
namespace LennyBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyBot bot = new MyBot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error starting bot!");
                Console.Write(e);
                Console.ReadLine();
            }


        }
    }
}

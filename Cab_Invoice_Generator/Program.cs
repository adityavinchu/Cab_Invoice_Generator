using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();

            float distance, time;
            Console.WriteLine("Enter Distance:");
            distance= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Time");
            time= Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Single Ride Fare:" + cabInvoiceGenerator.TotalFare(distance, time));
            Console.ReadLine();
        }
    }
}

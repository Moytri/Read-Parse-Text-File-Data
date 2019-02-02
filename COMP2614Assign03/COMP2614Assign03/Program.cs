using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Cannot find Text file. Please correct command line arguments.");
                return;
            }

            //Obtain file name via command line argument
            Execute(args[0]);
        }

        public static void Execute(String path)
        {
            //parse the file to obtain a list of invoice 
            List<Invoice> invoices = Parser.GetInvoices(path);

            Console.Title = "COMP2614 - Assignment 3 - A01062206";
            Console.WriteLine("Invoice Listing");

            //print invoice
            InvoicePrinter.DisplayInvoice(invoices);
        }
    }
}

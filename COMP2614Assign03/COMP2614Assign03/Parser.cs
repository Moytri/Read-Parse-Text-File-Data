using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COMP2614Assign03
{
    class Parser
    {
        static StreamReader streamReader = null;
        static string lineData;

        public static List<Invoice> GetInvoices(String path)
        {
            streamReader = new StreamReader(path);

            while ((lineData = streamReader.ReadLine()) != null)
            {
                String[] tokens = lineData.Split('|');
                List<Invoice> invoices = new List<Invoice>();

                Invoice invoice = ParseInvoice(tokens[0], tokens);
              
                
            }
            return null;
        }

        private static Invoice ParseInvoice(string invoice, string[] tokens)
        {
            Console.WriteLine(invoice);
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class InvoicePrinter
    {
        static readonly string divider = new string('-', 80);

        public static void DisplayInvoice(List<Invoice> invoices)
        {
            foreach(Invoice invoice in invoices)
            {
                Console.WriteLine(divider);
                Console.WriteLine($"\n{"Invoice Number:",-18}{invoice.InvoiceNumber,8}");
                Console.WriteLine($"{"Invoice Date:",-18} {invoice.InvoiceDate,-6}");
                Console.WriteLine($"{"Discount Date:", -18} {invoice.DiscountDate,-8}");
                Console.WriteLine($"{"Terms:", -18} {invoice.ParseTerm()[0],2:N2}% {invoice.ParseTerm()[1]} days ADI");

                Console.WriteLine(divider);
                DisplayInvoiceDetails(invoice.InvoiceDetails);
            }           
        }

        private static void DisplayInvoiceDetails(List<InvoiceDetails> InvoiceDetails)
        {
            Console.WriteLine("{0, -3}  {1, -1}  {2, 20}  {3, 24} {4,3} {5,15}", "Qty", "SKU", "Description", "Price", "PST", "Ext");
            foreach(InvoiceDetails detail in InvoiceDetails)
            {

            }
        }

    }
}

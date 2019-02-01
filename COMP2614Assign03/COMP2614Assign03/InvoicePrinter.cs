using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class InvoicePrinter
    {
        static readonly string divider = new string('-', 85);

        public static void DisplayInvoice(List<Invoice> invoices)
        {
            foreach(Invoice invoice in invoices)
            {
                Console.WriteLine(divider);
                Console.WriteLine($"\n{"Invoice Number:",-18}{invoice.InvoiceNumber,8}");
                Console.WriteLine($"{"Invoice Date:",-18} {invoice.InvoiceDate,-4}");
                Console.WriteLine($"{"Discount Date:", -18} {invoice.DiscountDate,-6}");
                Console.WriteLine($"{"Terms:", -18} {invoice.ParseTerm()[0],2:N2}% {invoice.ParseTerm()[1]} days ADI");

                Console.WriteLine(divider);
                DisplayInvoiceDetails(invoice.InvoiceDetails);
            }
            Console.WriteLine(divider);
            DisplayCalculation();
        }

        private static void DisplayInvoiceDetails(List<InvoiceDetails> InvoiceDetails)
        {
            Console.WriteLine($"{"Qty",-3}{" "}{"SKU",-14}{"Description",-22}{"Price",25}{"  "}{"PST",5}{"EXT",13}");
            Console.WriteLine(divider);
            foreach (InvoiceDetails detail in InvoiceDetails)
            {
                Console.WriteLine($"{detail.Quantity,3}{" "}{detail.SKU,-14}{detail.Description,-22}{detail.Price,25}{"  "}{(detail.IsTaxable ? "Y" : "N"), 4}{detail.ExtendedPrice,13:N}");
            }
        }

        private static void DisplayCalculation()
        {

        }

    }
}

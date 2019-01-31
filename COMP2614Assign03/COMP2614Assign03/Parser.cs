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
            List<Invoice> invoices = new List<Invoice>();

            while ((lineData = streamReader.ReadLine()) != null)
            {
                string [] tokens = lineData.Split('|');
                List<InvoiceDetails> invoiceDetails = ParseInvoiceDetail(tokens);

                Invoice invoice = ParseInvoice(tokens[0], invoiceDetails);
                invoices.Add(invoice);
            }
            return invoices;
        }

        private static Invoice ParseInvoice(string invoice, List<InvoiceDetails> invoiceDetails)
        {
            string[] subTokens = invoice.Split(':');

            return new Invoice
            {
                InvoiceNumber = int.Parse(subTokens[0]),
                InvoiceDate = DateTime.Parse(subTokens[1]),
                Term = int.Parse(subTokens[2]),
                InvoiceDetails = invoiceDetails
            };
        }

        private static List<InvoiceDetails> ParseInvoiceDetail(string[] tokens)
        {
            List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();
            for(int i = 1; i < tokens.Length; i++)
            {
                string[] subTokens = tokens[i].Split(':');

                invoiceDetails.Add(new InvoiceDetails
                {
                    Quantity = int.Parse(subTokens[0]), //could use bool temp = int.TryParse(value, out myValue);
                    SKU = subTokens[1],
                    Description = subTokens[2],
                    Price = Decimal.Parse(subTokens[3]), //could use bool temp = int.TryParse(value, out myValue);
                    IsTaxable = ToBoolean(subTokens[4])
                });

            }
            return invoiceDetails;
        }

        private static bool ToBoolean(string value)
        {
            switch (value.ToLower())
            {
                case "y":
                    return true;
                case "t":
                    return true;
                case "1":
                    return true;
                case "n":
                    return false;
                case "f":
                    return false;
                case "0":
                    return false;
                default:
                    throw new InvalidCastException("You can't cast that value to a bool!");
            }
        }
    }
}

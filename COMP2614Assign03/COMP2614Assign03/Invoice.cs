using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Assign03
{
    class Invoice
    {
        private const int PST_RATE = 7;
        private const int GST_RATE = 5;

        public int InvoiceNumber { get; set; }
        public DateTime InvcDate { get; set; }
        public int Term { get; set; }
        public List<InvoiceDetails> InvoiceDetails { get; set; }

        public decimal TaxPrices
        {
            get
            {
                decimal taxPrices = 0.0m;
                foreach (InvoiceDetails details in InvoiceDetails)
                {
                    if(details.IsTaxable)
                    {
                        taxPrices += details.ExtendedPrice;
                    }                
                }
                return taxPrices;
            }
        }

        public decimal TotalPrice
        {
            get {
                decimal totalPrice = 0.0m;
                foreach(InvoiceDetails details in InvoiceDetails)
                {
                   
                    totalPrice += details.ExtendedPrice;
                }
                return totalPrice;
            }
        }

        public decimal GST => TotalPrice * GST_RATE / 100.00m;

        public decimal PST => TaxPrices * PST_RATE / 100.00m;

        public decimal Discount => ParseTerm()[0] * TotalPrice / 100.00m;

        public int[] ParseTerm()
        {
            int [] intArray = Term.ToString().Select(c => Convert.ToInt32(c.ToString())).ToArray();
            var results = new int[2];

            results[0] = intArray[0];
            results[1] = int.Parse(intArray[1].ToString() + intArray[2].ToString());
            return results;
        }

        public string InvoiceDate => InvcDate.ToString("MMM d, yyyy");
        public string DiscountDate => InvcDate.AddDays(ParseTerm()[1]).ToString("MMM d, yyyy");
    }
}

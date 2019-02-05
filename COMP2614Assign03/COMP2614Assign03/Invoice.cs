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
        public List<InvoiceDetailLine> InvoiceDetails { get; set; }

        //Calculate price of taxable items
        public decimal TaxPrices
        {
            get
            {
                decimal taxPrices = 0.0m;
                foreach (InvoiceDetailLine details in InvoiceDetails)
                {
                    if(details.IsTaxable)
                    {
                        taxPrices += details.ExtendedPrice;
                    }                
                }
                return Math.Round(taxPrices,2);
            }
        }

        //calculate price of all items of the invoice (both taxable and non-taxable item)
        public decimal SubTotalPrice
        {
            get {
                decimal subTotalPrice = 0.0m;
                foreach(InvoiceDetailLine details in InvoiceDetails)
                {
                    subTotalPrice += details.ExtendedPrice;
                }
                return Math.Round(subTotalPrice, 2);
            }
        }

        public decimal GST => Math.Round(SubTotalPrice * GST_RATE / 100.00m,2);

        public decimal PST => Math.Round(TaxPrices * PST_RATE / 100.00m,2);

        //TotalPrice = SubTotalPrice + GST + PST
        public decimal TotalPrice => Math.Round(SubTotalPrice + GST + PST, 2);

        public decimal Discount => Math.Round(ParseTerm()[0] * TotalPrice / 100.00m,2);

        //parse Term. e.g: parse 115 as arr[0] = 1, arr[1] = 15
        public int[] ParseTerm()
        {
            //convert numeric string into int array
            int[] intArray = Term.ToString().Select(c => Convert.ToInt32(c.ToString())).ToArray();
            var results = new int[2];

            results[0] = intArray[0];
            results[1] = int.Parse(intArray[1].ToString() + intArray[2].ToString());
            return results;
        }

        //Format invoice date 
        public string InvoiceDate => InvcDate.ToString("MMM d, yyyy");

        //calculate and format discount date using invoice date and term
        public string DiscountDate => InvcDate.AddDays(ParseTerm()[1]).ToString("MMM d, yyyy");
    }
}

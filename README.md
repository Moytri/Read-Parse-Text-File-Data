# Read-Parse-Text-File-Data
Read and Parse Text File Data

## Application Objective
This is my BCIT course assignment. The purpose of this assignment is to read and parse text file data, store this data in a data structure and print it to the console.

## Details
Write a console application that:
1) reads a file containing invoice data
2) stores the data in a collection of data classes
3) displays the data from the collection to the console The program must do just these three things and then exit—that is all.

Obtain the filename via a command line argument. The program must not prompt for a filename or contain a hard coded filename.
The program must be able to handle amounts up to 999, 999.99.

The program must also be able to handle 2 taxes, GST and PST. Since we are a reseller, we have a PST license and are exempt from paying PST. (We will always pay GST) Occasionally, we will purchase items for internal use and pay the PST to the vendor. This will be indicated by a flag in each detail line.

The tax rates are GST 5% and PST 7%.
The format of the file is described below. To keep the assignment from getting too large, your program can assume that the file is always formatted correctly.

Header Elements:
InvoiceNumber:InvoiceDate:Terms
3221409:2016/01/07:215
InvoiceNumber: AlphaNumeric 8 character max
InvoiceDate: YYYY/MM/DD
Terms: three digits, first digit is discount percentage (maximum 9)
second and third digit is discount period (minimum 10 days)
110 means 1% discount 10 day period

Line Item Elements:
Quantity:Sku:Description:Price:Taxable
10:WD2002:2TB Hard Drive:121.66:N
Quantity: 999 maximum value
Sku: 8 characters maximum
Description: 20 characters maximum
Price: 2decimal places
Taxable: Y or N to indicate that PST is payable on this line item

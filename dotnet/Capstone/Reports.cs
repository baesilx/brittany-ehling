using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Capstone
{
    public class Reports
    {
        string localDate = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");
        
        public void AuditLine(List<string> recordActivityList)
        {
            //string.Format("{MM-dd-yyyy hh-mm-ss}", localDate);
            string outputDirectory = Environment.CurrentDirectory;
            string outputLog = "Log.txt";
            string fullyQualifiedPathAndFile = Path.Combine(outputDirectory, outputLog);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullyQualifiedPathAndFile, true))
                {
                    foreach (string item in recordActivityList)
                    {
                        sw.WriteLine($"{DateTime.Now} {item}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid File Path.");
            }
        }
        public void SalesReport(decimal grossSales, List<VendingMachineItem> vendingMachineStockList)
        {
            string outputDirectory = Environment.CurrentDirectory;
            string outputAuditLog = localDate + " SalesReport.txt";
            string fullyQualifiedPathAndFile = Path.Combine(outputDirectory, outputAuditLog);
            try
            {
                using (StreamWriter sw = new StreamWriter(fullyQualifiedPathAndFile))
                {
                    foreach(VendingMachineItem item in vendingMachineStockList)
                    {
                        const int startingItemQuantity = 5;
                        int currentQuantity = item.Quantity;
                        int quantitySold = startingItemQuantity - currentQuantity;
                        sw.WriteLine($"{item.ItemName}|{quantitySold}");
                    }
                    sw.WriteLine("");
                    sw.WriteLine("** TOTAL SALES * * $" + grossSales);
                    Console.WriteLine("");
                    Console.WriteLine("** TOTAL SALES * * $" + grossSales);
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid File Path.");
            }
        }
        public List<string> RecordActivity(string activity, decimal startingBalance, decimal endingBalance)
        {
            List<string> recordedActivityList = new List<string>();
            string startingBalanceString = startingBalance.ToString("C2");
            string endingBalanceString = endingBalance.ToString("C2");
            recordedActivityList.Add($"{activity} {startingBalanceString} {endingBalanceString}");
            return recordedActivityList;
        }
    }
}

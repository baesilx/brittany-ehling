using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachineRun
    {
        public void VendingMachine()
        {
            string itemName = "";
            decimal price = 0m;
            string type = "";
            int quantity = 0;
            string slot = "";
            decimal grossSales = 0m;
            VendingMachineItem vendingMachineItem = new VendingMachineItem(itemName, price, type, quantity, slot);
            List<VendingMachineItem> vendingMachineStockList = vendingMachineItem.GetVendingMachineItems();
            Reports reports = new Reports();
            List<string> recordActivityList = new List<string>();

            //Makes sure the program loops
            bool stillOpen = true;
            while (stillOpen)
            {
                string secondSelection = "";
                decimal moneyEntered = 0m;
                decimal balance = 0m;
                MoneyTransactions moneyTransactions = new MoneyTransactions(moneyEntered, balance, price);
                string purchaseItemName = "";
                Purchase_Order purchaseOrder = new Purchase_Order(purchaseItemName);
                decimal balanceRemaining = 0m;
                ExceptionChecks exceptionChecks = new ExceptionChecks();
                decimal moneyInMachine = 0m;

                //main menu
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");

                string firstSelection = Console.ReadLine();
                if (firstSelection == "1")
                {
                    for (int i = 0; i < vendingMachineStockList.Count; i++)
                    {
                        Console.Write($"Slot: {vendingMachineStockList[i].Slot}   ");
                        Console.Write($"Price: {vendingMachineStockList[i].Price}   ");
                        Console.Write($"Item: {vendingMachineStockList[i].ItemName}   ");
                        //check quantity
                        if (vendingMachineStockList[i].Quantity == 0)
                        {
                            Console.Write("SOLD OUT");
                        }
                        Console.WriteLine();
                    }
                }
                else if (firstSelection == "2")
                {
                    while (secondSelection != "3")
                    {
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        secondSelection = Console.ReadLine();
                        if (secondSelection == "1")
                        {
                            string activity = "Feed Money";
                            Console.WriteLine("Please feed money in whole dollar amounts ex: (1, 2, 5, 10)");
                            string dollarAmountFed = Console.ReadLine();
                            if (dollarAmountFed == "1" || dollarAmountFed == "2" || dollarAmountFed == "5" || dollarAmountFed == "10")
                            {
                                //handles all cases where user input is invalid
                                moneyInMachine = moneyTransactions.CountEnteredMoney(dollarAmountFed);
                                Console.WriteLine($"Balance: ${moneyInMachine}");
                                decimal amountFed = decimal.Parse(dollarAmountFed);
                                recordActivityList = reports.RecordActivity(activity, amountFed, moneyInMachine);
                                reports.AuditLine(recordActivityList);
                            }
                            else
                            {
                                Console.WriteLine("Error: Please feed money in whole dollar amounts ex: (1, 2, 5, 10)");
                            }
                        }
                        else if (secondSelection == "2")
                        {
                            Console.WriteLine("Please select Item slot you wish to Purchase");
                            for (int i = 0; i < vendingMachineStockList.Count; i++)
                            {
                                Console.Write($"Slot: {vendingMachineStockList[i].Slot}   ");
                                Console.Write($"Price: {vendingMachineStockList[i].Price}   ");
                                Console.Write($"Item: {vendingMachineStockList[i].ItemName}   ");
                                if (vendingMachineStockList[i].Quantity == 0)
                                {
                                    Console.Write("SOLD OUT");
                                }
                                Console.WriteLine();
                            }
                            string customerSelection = Console.ReadLine();
                            bool isSlotValid = exceptionChecks.CheckIfSlotIsValid(customerSelection, vendingMachineStockList);
                            if (!isSlotValid)
                            {
                                Console.WriteLine("Error: Invalid Selection");
                            }
                            else
                            {
                                string itemPurchased = purchaseOrder.GetItemPurchaseName(customerSelection, vendingMachineStockList);
                                decimal itemPrice = moneyTransactions.GetItemPrice(customerSelection, vendingMachineStockList);

                                bool isItemInStock = exceptionChecks.CheckIfItemInStock(customerSelection, vendingMachineStockList);
                                decimal currentBalance = moneyTransactions.GetCurrentBalance();
                                bool canBalanceCoverPrice = exceptionChecks.CheckIfBalanceCanCoverPrice(itemPrice, currentBalance);

                                if (!canBalanceCoverPrice)
                                {
                                    Console.WriteLine("Error: Not Enough Money");
                                }
                                else if (!isItemInStock)
                                {
                                    Console.WriteLine("Error: Item Is Sold Out");
                                }
                                else
                                {
                                    //handles updating balanceRemaining, getting item price, getting item putchased
                                    balanceRemaining = moneyTransactions.GetBalanceAfterPurchase(customerSelection, vendingMachineStockList);
                                    //adds to Reports for grossSales
                                    grossSales = moneyTransactions.GrossSales(customerSelection, vendingMachineStockList);
                                    //updates the user
                                    Console.WriteLine($"Item: {itemPurchased} Cost: {itemPrice} Balance Remaining: {balanceRemaining}");
                                    //prints special type message
                                    vendingMachineItem.CheckTypePrintMessage(customerSelection, vendingMachineStockList);
                                    //updates stock
                                    vendingMachineStockList = purchaseOrder.UpdateVendingMachineStock(customerSelection, vendingMachineStockList);

                                    string itemNameSlot = $"{itemPurchased} {customerSelection}";
                                    recordActivityList = reports.RecordActivity(itemNameSlot, itemPrice, balanceRemaining);
                                    reports.AuditLine(recordActivityList);
                                }
                            }
                        }
                        else if (secondSelection == "3")
                        {
                            string activity = "Give Change";
                            List<int> change = moneyTransactions.Change();
                            decimal endingBalance = change[3];

                            Console.WriteLine($"quarters: {change[0]} dimes: {change[1]} nickels: {change[2]}");
                            recordActivityList = reports.RecordActivity(activity, balanceRemaining, endingBalance);
                            reports.AuditLine(recordActivityList);
                        }
                        else
                        {
                            //handles 2nd menu selections
                            Console.WriteLine("Error: Must enter a valid selcetion");
                        }
                    }
                }
                else if (firstSelection == "3")
                {
                    //closes program
                    stillOpen = false;
                }
                else if (firstSelection == "4")
                {
                    //hidden main menu option
                    reports.SalesReport(grossSales, vendingMachineStockList);
                }
                else
                {
                    //handles main menu selections
                    Console.WriteLine("Error: Must enter a valid selcetion");
                }
            }
        }
    }
}

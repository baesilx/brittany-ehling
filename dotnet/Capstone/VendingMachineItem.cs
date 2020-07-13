using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Capstone
{
    public class VendingMachineItem
    {
        public string ItemName { get; }
        public decimal Price { get; }
        public string Type { get; }
        public int Quantity { get; set; }
        public string Slot { get; }

        public VendingMachineItem(string itemName, decimal price, string type, int quantity, string slot)
        {
            ItemName = itemName;
            Price = price;
            Type = type;
            Quantity = quantity;
            Slot = slot;
        }

        public List<VendingMachineItem> vendingMachineStockList = new List<VendingMachineItem>();
        public List<string> slotList = new List<string>();
        public List<VendingMachineItem> GetVendingMachineItems()
        {
            string currentDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\..");
            string vendingMachineFile = "vendingmachine.csv";
            string pathToVendingMachineFile = Path.Combine(currentDirectory, vendingMachineFile);
            try
            {
                using (StreamReader sr = new StreamReader(pathToVendingMachineFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split('|');
                        string slot = lineArray[0];
                        string itemName = lineArray[1];
                        decimal price = decimal.Parse(lineArray[2]);
                        string type = lineArray[3];
                        int quantity = 5;
                        VendingMachineItem vendingMachineItem = new VendingMachineItem(itemName, price, type, quantity, slot);
                        vendingMachineStockList.Add(vendingMachineItem);
                        slotList.Add(slot);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid file path - Cannot Stock Vending Machine");
            }
            return vendingMachineStockList;
        }
        
        public void CheckTypePrintMessage(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    if (item.Type == "Chip")
                    {
                        Console.WriteLine("Crunch Crunch, Yum!");
                    }
                    if (item.Type == "Candy")
                    {
                        Console.WriteLine("Munch Munch, Yum!");
                    }
                    if (item.Type == "Drink")
                    {
                        Console.WriteLine("Glug Glug, Yum!");
                    }
                    if (item.Type == "Gum")
                    {
                       Console.WriteLine("Chew Chew, Yum!");
                    }
                }
            }
        }
    }
}

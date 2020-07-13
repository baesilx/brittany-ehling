using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Capstone
{
    public class MoneyTransactions
    {
        public decimal MoneyEntered { get; }
        public decimal Balance { get; }
        public decimal Price { get; }
        public MoneyTransactions(decimal moneyEntered, decimal balance, decimal price)
        {
            MoneyEntered = moneyEntered;
            Balance = balance;
            Price = price;
        }
        decimal balance = 0m;
        public decimal CountEnteredMoney(string dollarAmount)
        {
            decimal dollarAmountEntered = decimal.Parse(dollarAmount);
            balance += dollarAmountEntered;
            return balance;
        }
        public decimal GetBalanceAfterPurchase(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    decimal price = item.Price;
                    balance -= price;
                }
            }
            return balance;
        }
        decimal price = 0m;
        public decimal GetItemPrice(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    price = item.Price;
                }
            }
            return price;
        }
        public List<int> Change()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            if (balance >= .25m)
            {
                quarters = (int)(balance / .25m);
                balance -= quarters * .25m;
            }
            if (balance >= .10m)
            {
                dimes = (int)(balance / .10m);
                balance -= dimes * .25m;
            }
            if (balance >= .05m)
            {
                nickels = (int)(balance / .05m);
                balance -= nickels * .05m;
            }
            List<int> change = new List<int> { quarters, dimes, nickels, (int)balance };
            return change;
        }
        decimal grossSales = 0m;
        public decimal GrossSales(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    decimal price = item.Price;
                    grossSales += price;
                }
            }
            return grossSales;
        }
        public decimal GetCurrentBalance()
        {
            return balance;
        }
    }
}

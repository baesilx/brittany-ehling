using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Purchase_Order
    {
        public string PurchaseItemName { get; }

        public Purchase_Order(string purchasItemName)
        {
            PurchaseItemName = purchasItemName;
        }

        string purchaseItemName = "";
        public string GetItemPurchaseName(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    purchaseItemName = item.ItemName;
                }
            }
            return purchaseItemName;
        }

        public List<VendingMachineItem> UpdateVendingMachineStock(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelection == item.Slot)
                {
                    if (item.Quantity > 0)
                    {
                        item.Quantity -= 1;
                    }
                }
            }
            return vendingMachineStockList;
        }
    }
}
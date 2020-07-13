using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class ExceptionChecks
    {
        public bool CheckIfSlotIsValid(string customerSelection, List<VendingMachineItem> vendingMachineStockList)
        {
            bool isSlotValid = false;
            List<string> slotList = new List<string>();
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                slotList.Add(item.Slot);
            }
            if (slotList.Contains(customerSelection))
            {
                isSlotValid = true;
            }
            return isSlotValid;
        }

        public bool CheckIfBalanceCanCoverPrice(decimal itemPrice, decimal currentBalance)
        {
            bool canBalanceCoverPrice = false;

            if (currentBalance >= itemPrice)
            {
                canBalanceCoverPrice = true;
            }
            return canBalanceCoverPrice;
        }

        public bool CheckIfItemInStock(string customerSelecion, List<VendingMachineItem> vendingMachineStockList)
        {
            bool isItemInStock = false;
            foreach (VendingMachineItem item in vendingMachineStockList)
            {
                if (customerSelecion == item.Slot)
                {
                    int itemQuantity = item.Quantity;
                    if (itemQuantity > 0)
                    {
                        isItemInStock = true;
                    }
                }
            }
            return isItemInStock;
        }
    }
}

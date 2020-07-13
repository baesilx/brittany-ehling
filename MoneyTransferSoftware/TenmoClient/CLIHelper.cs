using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient
{
    public static class CLIHelper
    {
        public static int GetNumberInList(List<int> list)
        {
            string userInput = String.Empty;
            int intValue = 0;
            bool gettingNumberInList = true;

            do
            {
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out intValue))
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }
                else
                {
                    if (list.Contains(intValue))
                    {
                        gettingNumberInList = false;
                    }
                    else
                    {
                        Console.WriteLine($"Number you entered is not a valid transaction ID. Try again.");
                    }
                }
                
            }
            while (gettingNumberInList);

            return intValue;
        }
        public static int GetNumberInRange(int min, int max)
        {
            string userInput = String.Empty;
            int intValue = 0;
            bool gettingNumberInRange = true;

            do
            {
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out intValue))
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }
                else
                {
                    if (min <= intValue && intValue <= max)
                    {
                        gettingNumberInRange = false;
                    }
                    else
                    {
                        Console.WriteLine($"Number you entered is not between {min} and {max}. Try again.");
                    }
                }
            }
            while (gettingNumberInRange);

            return intValue;
        }
        public static decimal GetAmount()
        {
            string userInput = String.Empty;
            decimal decimalValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!decimal.TryParse(userInput, out decimalValue));

            return decimalValue;
        }
    }
}

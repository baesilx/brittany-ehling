using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@" __     __             _             __  __       _   _          _    ___   ___");
            Console.WriteLine(@" \ \   / /__ _ __ __  | | ___       |  \/  | __ _| |_(_) ___    (_)  / _ \ / _ \ ");
            Console.WriteLine(@"  \ \ / / _ \ '_ \ / _` |/ _ \ _____| |\/| |/ _` | __| |/ __|  / _ \| | | | | | |");
            Console.WriteLine(@"   \ V /  __/ | | | (_| | (_) |_____| |  | | (_| | |_| | (__  | (_) | |_| | |_| |");
            Console.WriteLine(@"    \_/ \___|_| |_|\__,_|\___/      |_|  |_|\__,_|\__|_|\___|  \___/ \___/ \___/ ");
            Console.WriteLine(@"     Brought to you by Umbrella Corp.(R)");
            Console.WriteLine("");

            //runs VendingMachineRun class
            VendingMachineRun vendingMachineRun = new VendingMachineRun();
            vendingMachineRun.VendingMachine();

        }
    }
  

}


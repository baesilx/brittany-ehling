using System;
using System.Collections.Generic;


namespace ConsoleSideProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"            .--.                   .---.");
            Console.WriteLine(@"        .---|__|           .-.     |~~~|");
            Console.WriteLine(@"     .--|===|--|_          |_|     |~~~|--.");
            Console.WriteLine(@"     |  |===|  |'\     .---!~|  .--|   |--|");
            Console.WriteLine(@"     |%%|   |  |.'\    |===| |--|%%|   |  |");
            Console.WriteLine(@"     |%%|   |  |\.'\   |   | |__|  |   |  |");
            Console.WriteLine(@"     |  |   |  | \  \  |===| |==|  |   |  |");
            Console.WriteLine(@"     |  |   |__|  \.'\ |   |_|__|  |~~~|__|");
            Console.WriteLine(@"     |  |===|--|   \.'\|===|~|--|%%|~~~|--|");
            Console.WriteLine(@"     ^--^---'--^    `-'`---^-^--^--^---'--'");
            Console.WriteLine(@"  ╔╗ ┬─┐┬┌┬┐┌┬┐┌─┐┌┐┌┬ ┬┌─┐  ╦  ┬┌┐ ┬─┐┌─┐┬─┐┬ ┬");
            Console.WriteLine(@"  ╠╩╗├┬┘│ │  │ ├─┤│││└┬┘└─┐  ║  │├┴┐├┬┘├─┤├┬┘└┬┘");
            Console.WriteLine(@"  ╚═╝┴└─┴ ┴  ┴ ┴ ┴┘└┘ ┴ └─┘  ╩═╝┴└─┘┴└─┴ ┴┴└─ ┴ ");
            Console.WriteLine(@"                                                  ");
            Console.WriteLine("\"X\" to exit application.");
            bool running = true;
            while (running)
            {
                running = BrittanysLibrary();
            }

        }
        static bool BrittanysLibrary()
        {
            //options
            Console.WriteLine("Enter Option: \"Search\", \"Add\", \"Remove\", \"List\", \"Lent\", \"Lend\".");
            //enter option
            Console.Write("Enter Option: ");
            string userInput = Console.ReadLine();
            userInput = userInput.Trim();
            //exit
            if (userInput.ToUpper() == "X")
            {
                return false;
            }

            Dictionary<string, string> dictionaryOfHardbackBooks = new Dictionary<string, string>();

            //search
            if (userInput.ToLower() == "search")
            {
                Console.Write("Search by Author or Title? ");
                string userSelectAuthorOrTitle = Console.ReadLine();

            }
            //add
            if (userInput.ToLower() == "add")
            {
                Console.WriteLine("Type of book (Enter \"Physical\" \"Digial\" or \"Audio\"): ");
                string type = Console.ReadLine();

                if (type.ToLower() == "physical")
                {
                    Console.WriteLine("Is this Hardback or Paperback? ");
                    string hardbackOrPaperback = Console.ReadLine();
                    if (hardbackOrPaperback.ToLower() == "hardback")
                    {

                    }
                }
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Is this book signed or a special edition? (Enter \"signed\" or \"special\") \"NO\" if not.");
                string isSpecialOrSigned = Console.ReadLine();

                if (isSpecialOrSigned.ToLower() == "no")
                {

                }
                if (isSpecialOrSigned.ToLower() == "signed")
                {

                }
                if (isSpecialOrSigned.ToLower() == "special")
                {

                }
            }
            //remove
            if (userInput.ToLower() == "remove")
            {
                Console.Write("Enter Title of book to remove:");
                string bookToRemove = Console.ReadLine();

            }
            //list 
            if (userInput.ToLower() == "list")
            {
                Console.Write("Search by Author or Title?");
                string userSelectAuthorOrTitle = Console.ReadLine();

            }
            //lent 
            if (userInput.ToLower() == "lent")
            {
                Console.Write("list of books currently lent out");
                string userSelectAuthorOrTitle = Console.ReadLine();

            }
            //lend
            if (userInput.ToLower() == "lend")
            {
                Console.Write("Enter Title of book to lend out:");
                string userSelectAuthorOrTitle = Console.ReadLine();
                Console.Write("Who are you lending to?");
                string bookLentTo = Console.ReadLine();
            }




            return true;
        }
    }
}

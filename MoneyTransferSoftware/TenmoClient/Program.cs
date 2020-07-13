using System;
using System.Collections.Generic;
using System.ComponentModel;
using TenmoClient.Data;

namespace TenmoClient
{
    class Program
    {
        private static readonly ConsoleService consoleService = new ConsoleService();
        private static readonly AuthService authService = new AuthService();
        private static readonly APIService apiService = new APIService();

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            int loginRegister = -1;
            while (loginRegister != 1 && loginRegister != 2)
            {
                Console.WriteLine("Welcome to TEnmo!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out loginRegister))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (loginRegister == 1)
                {
                    while (!UserService.IsLoggedIn()) //will keep looping until user is logged in
                    {
                        LoginUser loginUser = consoleService.PromptForLogin();
                        API_User user = authService.Login(loginUser);
                        if (user != null)
                        {
                            UserService.SetLogin(user);
                            apiService.SetToken(user.Token);
                        }
                    }
                }
                else if (loginRegister == 2)
                {
                    bool isRegistered = false;
                    while (!isRegistered) //will keep looping until user is registered
                    {
                        LoginUser registerUser = consoleService.PromptForLogin();
                        isRegistered = authService.Register(registerUser);
                        if (isRegistered)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registration successful. You can now log in.");
                            loginRegister = -1; //reset outer loop to allow choice for login
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }

            MenuSelection();
        }

        private static void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers");
                Console.WriteLine("3: View your pending requests");
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                menuSelection = CLIHelper.GetNumberInRange(0, 6);
                
                if (menuSelection == 1)
                {
                    Account account = apiService.GetAccount();
                    if (account != null)
                    {
                        Console.WriteLine($"Your current account balance is: {account.Balance.ToString("C2")}");
                    }
                }
                else if (menuSelection == 2)
                {
                    List<TransferWithDetails> transferHistory = apiService.GetTransferHistory();
                    var allTransferIDs = new List<int>();
                    allTransferIDs.Add(0);
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Transfer IDs         From/To         Amount");
                    Console.WriteLine("-------------------------------------------");
                    foreach (var item in transferHistory)
                    {
                        if (item.TransferId < 10)
                        {
                            if (item.FromUser == UserService.GetUsername())
                            {
                                Console.WriteLine($"0{item.TransferId}              To: {item.ToUser}             {item.Amount}");
                            }
                            else
                            {
                                Console.WriteLine($"0{item.TransferId}              From: {item.FromUser}             {item.Amount}");
                            }
                        }
                        else
                        {
                            if (item.FromUser == UserService.GetUsername())
                            {
                                Console.WriteLine($"{item.TransferId}              To: {item.ToUser}             {item.Amount}");
                            }
                            else
                            {
                                Console.WriteLine($"{item.TransferId}              From: {item.FromUser}             {item.Amount}");
                            }
                        }

                        allTransferIDs.Add(item.TransferId);
                    }
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Please enter transfer ID to view details (0 to cancel):");
                    int transferId = CLIHelper.GetNumberInList(allTransferIDs);

                    if (transferId != 0)
                    {
                        TransferWithDetails transfer = apiService.GetTransferById(transferId);

                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Transfer details");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine($"ID: {transfer.TransferId}");
                        Console.WriteLine($"From: {transfer.FromUser}");
                        Console.WriteLine($"To: {transfer.ToUser}");
                        Console.WriteLine($"Type: {transfer.TransferType}");
                        Console.WriteLine($"Status: {transfer.TransferStatus}");
                        Console.WriteLine($"Amount: {transfer.Amount}");
                    }
                    else
                    {
                        Console.WriteLine("Returning to the main menu.");
                    }
                }
                else if (menuSelection == 3)
                {

                }
                else if (menuSelection == 4)
                {
                    List<API_User> users = apiService.ListUsers(); // list users to select from 
                    var allUserIDs = new List<int>(); // puts all users in list
                    int currentUserId = UserService.GetUserId(); // gets current user id
                    users.RemoveAt(currentUserId - 1); // remove current user from list

                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("User IDs     Names");
                    Console.WriteLine("-------------------------------------------");
                    foreach (var item in users) // display users
                    {
                        Console.WriteLine($"{item.UserId}           {item.Username}");
                        allUserIDs.Add(item.UserId);
                    }
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Enter the ID of user you are sending to (0 to cancel):");
                    int receiverId = CLIHelper.GetNumberInList(allUserIDs); // make sure selection is in range

                    if (receiverId != 0)
                    {
                        Console.WriteLine("Enter amount to send:");
                        decimal amount = CLIHelper.GetAmount(); // in range method
                        TransferWithDetails result = apiService.SendMoney(receiverId, amount); // getting details from sendmoney & storing in "result"

                        if (result != null)
                        { // displaying transfer details
                            Console.WriteLine("Transfer successful! :)");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Transfer Details");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine($"ID: {result.TransferId}");
                            Console.WriteLine($"From: {result.FromUser}");
                            Console.WriteLine($"To: {result.ToUser}");
                            Console.WriteLine($"Type: {result.TransferType}");
                            Console.WriteLine($"Status: {result.TransferStatus}");
                            Console.WriteLine($"Amount: {result.Amount}");
                        }
                        else
                        {
                            Console.WriteLine("Transfer not completed");
                        }
                    }
                }
                else if (menuSelection == 5)
                {
                    Console.WriteLine("Feature unavailable. Returning to main menu."); // not implemented
                }
                else if (menuSelection == 6)
                {
                    Console.WriteLine("");
                    UserService.SetLogin(new API_User()); //wipe out previous login info
                    Run(); //return to entry point
                }
                else
                {
                    Console.WriteLine("Thank you for using TEnmo. Goodbye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}

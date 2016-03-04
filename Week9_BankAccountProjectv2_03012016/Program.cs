using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Week9_BankAccountProjectv2_03012016
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.AccountNumber = client.GetAcctNumber();
            Account account = new Account(client.ClientName, client.AccountNumber);
            CheckingAccount checkAccount = new CheckingAccount(client.ClientName, client.AccountNumber);
            ReserveAccount reserveAccount = new ReserveAccount(client.ClientName, client.AccountNumber);
            SavingsAccount savingsAccount= new SavingsAccount(client.ClientName, client.AccountNumber);

            bool exit = false;

            do
            {
                int menuOption = Menu();
                switch (menuOption)
                {
                    case 1:
                        {
                            ScreenHeader();
                            account.ViewAcctInfo(client.ClientName, client.AccountNumber, account.Balance);
                            PressKey();
                            break;
                        }
                    case 2:
                        {
                            ScreenHeader();
                            Console.WriteLine("BALANCE INFORMATION");
                            Console.WriteLine();
                            account.ViewAcctBalance(checkAccount.AccountType, checkAccount.Balance);
                            account.ViewAcctBalance(reserveAccount.AccountType, reserveAccount.Balance);
                            account.ViewAcctBalance(savingsAccount.AccountType, savingsAccount.Balance);
                            PressKey();
                            break;
                        }
                    case 3:
                        {
                            string action = "Deposit to";
                            account.DepositFunds();
                            int choice = AccountMenu(action);
                            switch(choice)
                            {
                                case 1:
                                    {
                                        checkAccount.DepositFundsChecking();
                                        checkAccount.UpdateAcctFileChecking();
                                        break;
                                    }
                                case 2:
                                    {
                                        reserveAccount.DepositFundsReserve();
                                        reserveAccount.UpdateAcctFileReserve();
                                        break;
                                    }
                                case 3:
                                    {
                                        savingsAccount.DepositFundsSavings();
                                        savingsAccount.UpdateAcctFileSavings();
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 4:
                        {
                            string action = "Withdraw from";
                            account.WithdrawFunds();
                            int choice = AccountMenu(action);
                            switch (choice)
                            {
                                case 1:
                                    {
                                        checkAccount.WithdrawFundsChecking();
                                        checkAccount.UpdateAcctFileChecking();
                                        break;
                                    }
                                case 2:
                                    {
                                        reserveAccount.WithdrawFundsReserve();
                                        reserveAccount.UpdateAcctFileReserve();
                                        break;
                                    }
                                case 3:
                                    {
                                        savingsAccount.WithdrawFundsSavings();
                                        savingsAccount.UpdateAcctFileSavings();
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Thanks for banking with us.");
                            Console.WriteLine("Good bye!");
                            Console.WriteLine();
                            Console.ReadKey();
                            exit = true;
                            break;
                        }
                    default: break;
                }
            } while (!exit);
        }

        static void ScreenHeader()
        {
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
        }

        static void PressKey()
        {
            Console.WriteLine();
            Console.Write("Press a key to return to the menu...");
            Console.ReadKey();
        }

        static int Menu()
        {
            bool validChoice = true;
            int choice = 0;
            ScreenHeader();
            Console.WriteLine("BANKING MENU");
            Console.WriteLine();
            Console.WriteLine("\t1. View Client Information");
            Console.WriteLine("\t2. View Account Balance");
            Console.WriteLine("\t3. Deposit Funds");
            Console.WriteLine("\t4. Withdrawal Funds");
            Console.WriteLine("\t5. Exit");
            Console.WriteLine();
            do
            {
                Console.Write("What would you like to do? (enter number of choice) ");
                validChoice = int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();
                if (choice < 1 || choice > 5)
                    validChoice = false;
                if (!validChoice)
                {
                    Console.WriteLine("INVALID ENTRY:  Please enter a number between 1-5.");
                }
            } while (!validChoice);
            return choice;
        }

        static int AccountMenu(string action)
        {
            bool validChoice = true;
            int choice = 0;
            Console.WriteLine("\t1. Checking Account");
            Console.WriteLine("\t2. Reserve Account");
            Console.WriteLine("\t3. Savings Account");
            Console.WriteLine();
            do
            {
                Console.Write("{0} which account? (enter number of choice) ", action);
                validChoice = int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();
                if (choice < 1 || choice > 3)
                    validChoice = false;
                if (!validChoice)
                {
                    Console.WriteLine("INVALID ENTRY:  Please enter a number between 1-3.");
                }
            } while (!validChoice);
            return choice;
        }
    }
}

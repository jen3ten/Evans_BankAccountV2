using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Week9_BankAccountProjectv2_03012016
{
    class Account
    {
        //Fields
        protected string transInput = "";
        static protected string sign = " ";
        protected StringBuilder transLine = new StringBuilder();
        List<string> transList = new List<string>();
        protected bool validInput = false;
        protected bool firstLine = true;

        //Properties
        public double Balance { get; set; }
        public string AccountNumber { get; set; }
        public string ClientName { get; set; }

        //Constructor
        public Account(string name, string account)
        {
            this.Balance = 100.00;
            this.AccountNumber = account;
            this.ClientName = name;
        }

        //Methods
        //View Account information
        public void ViewAcctInfo(string name, string number, double balance)
        {
            Console.WriteLine("CLIENT INFORMATION");
            Console.WriteLine();
            Console.WriteLine("Account Holder: \t{0}", name);
            Console.WriteLine("Account Number: \t{0}", number);
        }

        //View Account Balance
        public void ViewAcctBalance(string type, double balance)
        {
            Console.WriteLine("{0} Account Balance: \t${1:f2}", type, balance);
        }

        //Deposit funds method
        public void DepositFunds()
        {
            sign = "+";
            validInput = false;
            transLine.Clear();
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.WriteLine("DEPOSIT FUNDS");
            Console.WriteLine();
        }

        //Validate currency amount method
        public string ValidateAmount()
        {
            do
            {
                transInput = Console.ReadLine();
                if (!Regex.IsMatch(transInput, @"^[0-9]*\.[0-9]{2}$"))
                {
                    Console.WriteLine("INVALID ENTRY: Please enter a number in decimal format <0.00>");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            return transInput;
        }

        //Withdraw funds method
        public void WithdrawFunds()
        {
            sign = "-";
            validInput = false;
            transLine.Clear();
            Console.Clear();
            Console.WriteLine("*******************************");
            Console.WriteLine("FIRST THIRD BANKING APPLICATION");
            Console.WriteLine("*******************************");
            Console.WriteLine();
            Console.WriteLine("WITHDRAW FUNDS");
            Console.WriteLine();
        }

        //Add to transaction list method
        public void AddTransToList()
        {
            transLine = transLine.Append(DateTime.Now);
            transLine = transLine.Append("\t\t");
            transLine = transLine.Append(sign);
            if (!firstLine)
            {
                transLine = transLine.Append("   $");
                transLine = transLine.Append(transInput);
            }
            else
                transLine = transLine.Append("\t");
            transLine = transLine.Append("\t$");
            transLine = transLine.Append(this.Balance.ToString("F2"));
            transList.Add(transLine.ToString());
        }

        //Update text file method
        public void UpdateAcctFile()
        {
            StreamWriter accountFile = new StreamWriter("AccountSummary.txt");
            accountFile.WriteLine("***************************");
            accountFile.WriteLine("FIRST THIRD ACCOUNT SUMMARY");
            accountFile.WriteLine("***************************");
            accountFile.WriteLine();
            accountFile.WriteLine("Account Holder: \t{0}", ClientName);
            accountFile.WriteLine("Account Number: \t{0}", AccountNumber);
            accountFile.WriteLine("Account Balance: \t${0:f2}", Balance);
            accountFile.WriteLine();
            accountFile.WriteLine("TRANSACTION HISTORY");
            accountFile.WriteLine("Date\t\t\t\tTransaction\tBalance");
            foreach (string line in transList)
            {
                accountFile.WriteLine(line);
            }
            accountFile.Close();
        }
    }
}

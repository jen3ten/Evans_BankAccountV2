using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week9_BankAccountProjectv2_03012016
{
    class CheckingAccount : Account
    {
        //fields
        private string acctType = "Checking";
        private double startBalance = 200.00;
        List<string> transList = new List<string>();

        //properties
        public string AccountType { get; set; }

        //constructor
        public CheckingAccount(string name, string account) : base(name, account)
        { 
            firstLine = true;
            this.AccountType = acctType;
            this.Balance = startBalance;
            transList.Clear();
            AddTransToListChecking();
            firstLine = false;
        }

        //Deposit method
        public void DepositFundsChecking()
        {
            transLine.Clear();
            Console.Write("Enter the amount to deposit in Checking Account: + $");
            string transInput = ValidateAmount();
            this.Balance = this.Balance + (double.Parse(transInput));
            AddTransToListChecking();
        }

        //Withdrawal method
        public void WithdrawFundsChecking()
        {
            transLine.Clear();
            Console.Write("Enter the amount to withdraw from Checking Account: - $");
            string transInput = ValidateAmount();
            this.Balance = this.Balance - (double.Parse(transInput));
            AddTransToListChecking();
        }

        //Add to transaction list method
        public void AddTransToListChecking()
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
        public void UpdateAcctFileChecking()
        {
            StreamWriter accountFile = new StreamWriter("AccountSummaryChecking.txt");
            accountFile.WriteLine("************************************");
            accountFile.WriteLine("FIRST THIRD CHECKING ACCOUNT SUMMARY");
            accountFile.WriteLine("************************************");
            accountFile.WriteLine();
            accountFile.WriteLine("Account Holder: \t{0}", this.ClientName);
            accountFile.WriteLine("Account Number: \t{0}", this.AccountNumber);
            accountFile.WriteLine("Checking Account Balance: \t${0:f2}", this.Balance);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week9_BankAccountProjectv2_03012016
{
    class ReserveAccount : Account
    {
        //fields
        private string acctType = "Reserve";
        private double startBalance = 300.00;
        List<string> transList = new List<string>();

        //properties
        public string AccountType { get; set; }

        //constructor
        public ReserveAccount(string name, string account) : base (name, account)
        {
            firstLine = true;
            this.AccountType = acctType;
            this.Balance = startBalance;
            transList.Clear();
            AddTransToListReserve();
            firstLine = false;
        }

        //Deposit method
        public void DepositFundsReserve()
        {
            //sign = "+";
            transLine.Clear();
            Console.Write("Enter the amount to deposit in Reserve Account: + $");
            string transInput = ValidateAmount();
            this.Balance = this.Balance + (double.Parse(transInput));
            AddTransToListReserve();
        }

        //Withdrawal method
        public void WithdrawFundsReserve()
        {
            //sign = "-";
            transLine.Clear();
            Console.Write("Enter the amount to withdraw from Reserve Account: - $");
            string transInput = ValidateAmount();
            this.Balance = this.Balance - (double.Parse(transInput));
            AddTransToListReserve();
        }


        //Add to transaction list method
        public void AddTransToListReserve()
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
        public void UpdateAcctFileReserve()
        {
            StreamWriter accountFile = new StreamWriter("AccountSummaryReserve.txt");
            accountFile.WriteLine("************************************");
            accountFile.WriteLine("FIRST THIRD RESERVE ACCOUNT SUMMARY");
            accountFile.WriteLine("************************************");
            accountFile.WriteLine();
            accountFile.WriteLine("Account Holder: \t{0}", this.ClientName);
            accountFile.WriteLine("Account Number: \t{0}", this.AccountNumber);
            accountFile.WriteLine("Reserve Account Balance: \t${0:f2}", this.Balance);
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

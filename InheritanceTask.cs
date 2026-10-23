using System;
using System.Collections.Generic;

namespace BankTask
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            
            Balance += amount;
            return true;
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[Account: {Name}: {Balance}]";
        }
    }

    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            InterestRate = interestRate;
        }

        public override string ToString()
        {
            return $"[SavingsAccount: {Name}: {Balance}, Interest Rate: {InterestRate}%]";
        }
    }

    public class CheckingAccount : Account
    {
        private const double Fee = 1.50;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
            : base(name, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            double totalAmount = amount + Fee;
            return base.Withdraw(totalAmount);
        }

        public override string ToString()
        {
            return $"[CheckingAccount: {Name}: {Balance}]";
        }
    }

    public class TrustAccount : SavingsAccount
    {
        private int withdrawalsThisYear = 0;
        private const int MaxWithdrawals = 3;
        private const double MaxWithdrawPercent = 0.20;

        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance, interestRate)
        {
        }

        public override bool Deposit(double amount)
        {
            if (amount >= 5000)
            {
                return base.Deposit(amount + 50);
            }
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawalsThisYear >= MaxWithdrawals || amount > (Balance * MaxWithdrawPercent))
            {
                return false;
            }

            if (base.Withdraw(amount))
            {
                withdrawalsThisYear++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[TrustAccount: {Name}: {Balance}, Interest Rate: {InterestRate}%, Withdrawals: {withdrawalsThisYear}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var acc = new Account("Marium", 1000);
            acc.Deposit(500);
            Console.WriteLine(acc);

            var savings = new SavingsAccount("Savings", 2000, 3.0);
            Console.WriteLine(savings);

            Console.WriteLine("Inheritance Task is Working Successfully!");
        }
    }
}

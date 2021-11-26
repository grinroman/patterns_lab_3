using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace patterns_lab_3
{
    class Account
    {
        public string AccountOwner { get; set; }
        public int Balance { get; set; }

        public Account(string accountOwner, int balance)
        {
            this.Balance = balance;
            this.AccountOwner = accountOwner;
        }

        public void Info() => WriteLine($"{AccountOwner}: ${Balance}");

    }

    interface IOperation
    {
        void Execute();
        public bool IsComplete { get; }
    }

    class Deposit : IOperation
    {
        private readonly Account account;
        private readonly int money;
        private bool isComplete;
        public bool IsComplete { get => isComplete; }

        public Deposit(Account account, int money)
        {
            this.account = account;
            this.money = money;
            isComplete = false;
        }

        public void Execute()
        {
            account.Balance += money;
            isComplete = true;
        }
    }



    class Withdraw : IOperation
    {
        private readonly Account account;
        private readonly int money;
        private bool isComplete;
        public bool IsComplete { get => isComplete; }

        public Withdraw(Account account, int money)
        {
            this.account = account;
            this.money = money;
            isComplete = false;
        }

        public void Execute()
        {
            if (account.Balance - money < 0) return;
            account.Balance -= money;
            isComplete = true;
        }
    }
}

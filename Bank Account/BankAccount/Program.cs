using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        private string m_accountHolder = "";
        private double m_balance;
        public BankAccount(string accountHolder)
        {
            this.m_balance = 0;
            this.m_accountHolder = accountHolder;
            return;
        }
        private double RoundDownValue(double value)
        {
            double newvalue = Math.Floor(value * 100) / 100;
            Console.WriteLine($"{value} = {newvalue}");
            return newvalue;
        }
        public double GetBalance()
        {
            Console.WriteLine($"Your balance is {m_balance}");
            return m_balance;
        }

        public void DepositMoney(double depositValue)
        {
            m_balance += depositValue;
            m_balance = RoundDownValue(m_balance);
            Console.WriteLine($"Deposited {depositValue}. Your balance is {m_balance}.");
            return;
        }

        public void WithdrawMoney(double withdrawAmount)
        {
            if (withdrawAmount <= 0)
            {
                Console.WriteLine($"Error: You cannot withdraw a negative amount");
                return;
            }
            if (withdrawAmount <= m_balance)
            {
                withdrawAmount = RoundDownValue(withdrawAmount);
                m_balance = m_balance - withdrawAmount;
                m_balance = RoundDownValue(m_balance);
                Console.WriteLine($"You have withdrawn {withdrawAmount}. Remaining balance: {m_balance}");
            }
            else
            {
                withdrawAmount = RoundDownValue(withdrawAmount);
                Console.WriteLine($"You cannot afford to withdraw {withdrawAmount}. Remaining balance: {m_balance}");
            }
            return;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Charles");
            double balance = ba.GetBalance();
            ba.DepositMoney(5000.2);
            ba.WithdrawMoney(7000.294);
            ba.WithdrawMoney(2000);
            ba.WithdrawMoney(-20000);
        }
    }
}

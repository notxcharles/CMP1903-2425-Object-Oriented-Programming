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
        private int m_balance;
        public BankAccount(string accountHolder)
        {

            this.m_balance = 0;
            this.m_accountHolder = accountHolder;
        }

        public int GetBalance()
        {
            Console.WriteLine($"Your balance is {m_balance}");
            return m_balance;
        }

        public void DepositMoney(int depositValue)
        {
            m_balance += depositValue;
            Console.WriteLine($"Deposited {depositValue}. Your balance is {m_balance}.");
        }

        public void WithdrawMoney(int withdrawAmount)
        {
            if (withdrawAmount <= m_balance)
            {
                m_balance = m_balance - withdrawAmount;
                Console.WriteLine($"You have withdrawn {withdrawAmount}. Remaining balance: {m_balance}");
            }
            else
            {
                Console.WriteLine($"You cannot afford to withdraw {withdrawAmount}. Remaining balance: {m_balance}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Charles");
            int balance = ba.GetBalance();
            ba.DepositMoney(5000);
            ba.WithdrawMoney(7000);
            ba.WithdrawMoney(2000);
        }
    }
}

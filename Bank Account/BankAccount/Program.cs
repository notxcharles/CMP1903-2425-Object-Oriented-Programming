using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Person
    {
        private string m_firstName;
        private string m_lastName;
        private string m_email;
        private int m_phone;
        private string m_address;
        private int m_age;

        public Person(string firstName, string lastName, string email, int phone, string address, int age)
        {
            m_firstName = firstName;
            m_lastName = lastName;
            m_email = email;
            m_phone = phone;
            m_address = address;
            m_age = age;
        }
        public string FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }
        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }
        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }
        public int Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        public int Age
        {
            get { return m_age; }
            set { m_age = value; }
        }
    }
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
            return newvalue;
        }
        private string DisplayValue(double value)
        {
            string valueString = value.ToString("0.00");
            return valueString;
        }
        public double GetBalance()
        {
            Console.WriteLine($"Your balance is £{DisplayValue(m_balance)}");
            return m_balance;
        }

        public void DepositMoney(double depositValue)
        {
            m_balance += depositValue;
            m_balance = RoundDownValue(m_balance);
            Console.WriteLine($"Deposited £{DisplayValue(depositValue)}. Your balance is £{DisplayValue(m_balance)}.");
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
                Console.WriteLine($"You have withdrawn £{DisplayValue(withdrawAmount)}. Remaining balance: £{DisplayValue(m_balance)}");
            }
            else
            {
                withdrawAmount = RoundDownValue(withdrawAmount);
                Console.WriteLine($"You cannot afford to withdraw £{DisplayValue(withdrawAmount)}. Remaining balance: £{DisplayValue(m_balance)}");
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

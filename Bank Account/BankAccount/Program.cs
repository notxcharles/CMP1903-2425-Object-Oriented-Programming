using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Policy;
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

        public Person(string firstName, string lastName, string address, int age, string email = "Person has not got an email", int phone = -1)
        {
            // Let's assume that every person has a first and last name, an address and an age
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
    public class Account
    {
        private Person m_accountPerson;
        private string m_accountHolderName = "";
        private string m_address;
        private string m_accountType;
        private string m_email;
        private int m_phone;
        private int m_age;
        private Random m_random;

        private string m_sortCode;
        private int m_accountNumber;

        public Account(Person accountHolderPerson, string accountHolderName, string address, string accountType, string email = "No email was provided for this account", int phone = -1, int age = -1)
        {
            m_accountPerson = accountHolderPerson;
            m_accountHolderName = accountHolderName;
            m_address = address;
            m_email = email;
            m_phone = phone;
            m_age = age;
            m_random = new Random();
            
            m_sortCode = CreateSortCode();
            m_accountNumber = CreateAccountNumber();
        }
        public Account(Person accountHolderPerson) 
        {
            m_accountPerson = accountHolderPerson;
            m_accountHolderName = String.Concat(accountHolderPerson.FirstName, accountHolderPerson.LastName);
            m_address = accountHolderPerson.Address;
            m_email = accountHolderPerson.Email;
            m_phone = accountHolderPerson.Phone;
            m_age = accountHolderPerson.Age;
            m_random = new Random();

            m_sortCode = CreateSortCode();
            m_accountNumber = CreateAccountNumber();
        }

        private string CreateSortCode()
        {
            // sort code format: 00-00-00
            string sortCode = $"{m_random.Next(0, 9)}{m_random.Next(0, 9)}-{m_random.Next(0, 9)}{m_random.Next(0, 9)}-{m_random.Next(0, 9)}{m_random.Next(0, 9)}";
            Console.WriteLine(sortCode);
            return sortCode;
        }
        private int CreateAccountNumber()
        {
            int accountNumber = 0;
            accountNumber = m_random.Next(00000000, 99999999);
            return accountNumber;
        }
        public string SortCode
        {
            get { return m_sortCode; }
        }
        public int AccountNumber
        {
            get { return m_accountNumber; }
        }
        public Person AccountHolderPerson
        {
            get { return m_accountPerson; }
        }
        public string AccountHolderName
        {
            get { return m_accountHolderName; }
            set { m_accountHolderName = value; }
        }
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
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

            Person p = new Person("charles", "harrison", "c@email.com", 9285728, "house, street, town, postcode", 10);
            string pFullName = String.Concat(p.FirstName, p.LastName);
            Account acc = new Account(p, pFullName, p.Address, "current", p.Email, p.Phone, p.Age);
        }
    }
}

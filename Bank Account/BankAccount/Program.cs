using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        public string FullName
        {
            get { return String.Concat(m_firstName, " ", m_lastName); }
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
        private string m_accountType;
        private double m_balance = 0;

        private Random m_random;

        private string m_sortCode;
        private int m_accountNumber;
        // Account history will store all transaction history and when the account was set up
        private List<string> m_accountHistory = new List<string>();

        public Account(Person accountHolderPerson, string accountType) 
        {
            m_accountPerson = accountHolderPerson;
            m_accountType = accountType;
            m_accountHistory.Add($"Account created with {m_accountPerson.FullName}");
            m_random = new Random();
            m_sortCode = CreateSortCode();
            m_accountNumber = CreateAccountNumber();
            m_accountHistory.Add($"Sort Code and Account Number created: {m_sortCode} {m_accountNumber}");
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
            get { return m_accountPerson.FullName; }
        }
        public string Address
        {
            get { return m_accountPerson.Address; }
        }
        public string Email
        {
            get { return m_accountPerson.Email; }
        }
        public int Age
        {
            get { return m_accountPerson.Age; }
        }
        public int PhoneNumber
        {
            get { return m_accountPerson.Phone; }
        }
        public string AccountType
        {
            get { return m_accountType; }
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
            Console.WriteLine(accountNumber);
            return accountNumber;
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
            string message = ($"Deposited £{DisplayValue(depositValue)}. Your balance is £{DisplayValue(m_balance)}.");
            Console.WriteLine(message);
            m_accountHistory.Add(message);
            return;
        }

        public void WithdrawMoney(double withdrawAmount)
        {
            string message;
            if (withdrawAmount <= 0)
            {
                Console.WriteLine($"Error: You cannot withdraw a negative amount");
            }
            else if (withdrawAmount <= m_balance)
            {
                withdrawAmount = RoundDownValue(withdrawAmount);
                m_balance = m_balance - withdrawAmount;
                m_balance = RoundDownValue(m_balance);
                message = ($"You have withdrawn £{DisplayValue(withdrawAmount)}. Remaining balance: £{DisplayValue(m_balance)}");
                Console.WriteLine(message);
                m_accountHistory.Add(message);
            }
            else
            {
                withdrawAmount = RoundDownValue(withdrawAmount);
                message = ($"You cannot afford to withdraw £{DisplayValue(withdrawAmount)}. Remaining balance: £{DisplayValue(m_balance)}");
                Console.WriteLine(message);
                m_accountHistory.Add(message);
            }
            return;
        }
        public void ShowAccountDetails()
        {
            Console.WriteLine($"Account holder: {m_accountPerson.FullName}");
            Console.WriteLine($"Account type: {m_accountType} | Balance: {m_balance}");
            Console.WriteLine($"Sort Code: {m_sortCode} | Account Number: {m_accountNumber}\n");
            return;
        }
        public void ShowAccountHistory()
        {
            Console.WriteLine($"\nAccount History:");
            for (int i = 0; i < m_accountHistory.Count; i++) 
            {
                Console.WriteLine(m_accountHistory[i]);
            }
            return;
        }
    }

    public class Bank
    {
        //Class bank should keep track of all accounts that are currently open
        private string m_name;
        private List<Account> m_accounts = new List<Account>();
        public Bank(string name)
        {
            m_name = name;
        }
        public string BankName
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public void AddAccount(Account account) 
        {
            m_accounts.Add(account);
        }
        public int GetNumberOfAccounts()
        {
            return m_accounts.Count;
        }
        public void ShowPreviewOfAccounts()
        {
            Console.WriteLine("\nAccounts opened:");
            for (int i = 0; i < m_accounts.Count; i++)
            {
                m_accounts[i].ShowAccountDetails();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("charles", "harrison", "c@email.com", 9285728, "house, street, town, postcode", 10);
            Thread.Sleep(20); // need some wait time for the pseudorandom to recalculate again
            Account acc2 = new Account(p, "current");
            acc2.DepositMoney(5000.2);
            acc2.WithdrawMoney(7000.294);
            acc2.WithdrawMoney(2000);
            acc2.WithdrawMoney(-20000);
            acc2.ShowAccountDetails();
            acc2.ShowAccountHistory();

            Bank b = new Bank("Charles Bank");
            Console.WriteLine($"\n{b.BankName}");
            b.AddAccount(acc2);
            Console.WriteLine($"Open accounts: {b.GetNumberOfAccounts()}");
            b.ShowPreviewOfAccounts();

        }
    }
}

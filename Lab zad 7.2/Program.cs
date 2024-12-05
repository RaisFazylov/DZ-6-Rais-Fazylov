using System;

namespace Lab_7_2
{
    // Задание 7.2
    // Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы
    // номер счета генерировался сам и был уникальным.Для этого надо создать в классе
    // статическую переменную и метод, который увеличивает значение этого переменной.
    public enum AccountType
    {
        Savings,
        Checking,
        Business,
        FixedDeposit
    }
    public class BankAccount
    {
        private static int accountNumberCounter = 0;
        private readonly string accountNumber;
        private decimal balance;
        private AccountType accountType; 
        public BankAccount(decimal initialBalance, AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = initialBalance;
            this.accountType = accountType;
        }
        private static string GenerateAccountNumber()
        {
            accountNumberCounter++;
            return "СЧЕТ" + accountNumberCounter.ToString("D8");
        }
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance:C}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Внесено: {amount:C}. Новый баланс: {balance:C}");
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= balance && amount > 0)
            {
                balance -= amount;
                Console.WriteLine($"Снято: {amount:C}. Остаток на счете: {balance:C}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или сумма снятия должна быть положительной.");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 7.2 Тумакова");
            BankAccount myAccount1 = new BankAccount(7777.00m, AccountType.Savings);
            BankAccount myAccount2 = new BankAccount(777.00m, AccountType.Checking);
            myAccount1.PrintAccountInfo();
            myAccount2.PrintAccountInfo();
            myAccount1.Deposit(777.00m);
            myAccount1.Withdraw(77.00m);
            myAccount2.Deposit(666.00m);
            myAccount2.Withdraw(555.00m);
            myAccount1.PrintAccountInfo();
            myAccount2.PrintAccountInfo();
        }
    }
}

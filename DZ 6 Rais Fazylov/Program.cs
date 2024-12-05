using System;

namespace Lab_7_1
{
    // Задание 7.1
    // Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип
    // банковского счета(использовать перечислимый тип из упр. 3.1). Предусмотреть методы для
    // доступа к данным – заполнения и чтения.Создать объект класса, заполнить его поля и
    // вывести информацию об объекте класса на печать.
    public enum AccountType
    {
        Savings,
        Checking,
        Business,
        FixedDeposit
    }
    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;
        public BankAccount(string accountNumber, decimal initialBalance, AccountType accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            this.accountType = accountType;
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
            Console.WriteLine("Задание 7.1 Тумакова");
            BankAccount myAccount = new BankAccount("66666", 6666.00m, AccountType.Savings);
            myAccount.PrintAccountInfo();
            myAccount.Deposit(666.00m);
            myAccount.Withdraw(66.00m);
            myAccount.PrintAccountInfo();
        }
    }
}

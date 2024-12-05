using System;

namespace Lab_7_3
{
    /* Задание 7.3
    Добавить в класс счет в банке два метода: снять со счета и положить на
    счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае
    положительного результата изменяет баланс.
     */
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
            if (amount > 0)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Снято: {amount:C}. Остаток на счете: {balance:C}");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете для снятия такой суммы.");
                }
            }
            else
            {
                Console.WriteLine("Сумма снятия должна быть положительной.");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 7.3 Тумакова");
            BankAccount myAccount1 = new BankAccount(1111.00m, AccountType.Savings);
            BankAccount myAccount2 = new BankAccount(2222.00m, AccountType.Checking);
            myAccount1.PrintAccountInfo();
            myAccount2.PrintAccountInfo();
            myAccount1.Deposit(333.00m);
            myAccount1.Withdraw(4444.00m);
            myAccount1.Withdraw(5555.00m);
            myAccount2.Deposit(666.00m);
            myAccount2.Withdraw(777.00m);
            myAccount2.Withdraw(8888.00m);
            myAccount1.PrintAccountInfo();
            myAccount2.PrintAccountInfo();
        }
    }
}
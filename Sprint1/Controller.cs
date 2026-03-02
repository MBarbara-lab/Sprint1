using SistemaBancario.BankAccounts;

namespace SistemaBancario
{
    public class Controller
    {
        public static void AccountType (Person client, List<BankAccount> bankAccounts)
        {
            int option = 1;
            Random rdn = new Random();
            int accountNumber;
            bool isAccountCreated = false;

            while (option != 0 && !isAccountCreated)
            {
                option = Menu.AccountType();
                switch (option)
                {
                    case 0:
                        Console.Clear();
                        break;

                    case 1:
                        Console.Clear();
                        accountNumber = rdn.Next(100000, 200000);

                        bankAccounts.Add(new Checking(accountNumber, client));
                        Console.WriteLine("Sua conta corrente foi criada!");
                        isAccountCreated = true;
                        break;

                    case 2:
                        Console.Clear();
                        accountNumber = rdn.Next(100000, 200000);

                        decimal businessMonthlyIncome = Validation.MonthlyIncome("Insira a renda mensal do seu negócio: ");

                        Console.Clear();
                        bankAccounts.Add(new Business(accountNumber, client, businessMonthlyIncome));
                        Console.WriteLine("Sua conta empresarial foi criada!");
                        isAccountCreated = true;
                        break;

                    case 3:
                        Console.Clear();
                        accountNumber = rdn.Next(100000, 200000);

                        bankAccounts.Add(new Saving(accountNumber, client));
                        Console.WriteLine("Sua conta poupança foi criada!");
                        isAccountCreated = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        public static void Transactions(BankAccount currentAccount)
        {
            int option = 1;
            while (option != 0)
            {
                option = Menu.Transactions(currentAccount);
                switch (option)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Saindo da conta...");
                        break;

                    case 1:
                        Console.Clear();
                        currentAccount.Deposit();
                        break;

                    case 2:
                        Console.Clear();
                        currentAccount.PayLoan();
                        break;

                    case 3:
                        Console.Clear();
                        currentAccount.Withdrawal(currentAccount.WithdrawalTax);
                        break;

                    case 4:
                        Console.Clear();
                        currentAccount.WithdrawLoan();
                        break;
                    
                    case 5:
                        Console.Clear();
                        currentAccount.Transfer();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }


    }
}

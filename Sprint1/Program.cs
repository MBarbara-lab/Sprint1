// tem mudar a política de cálculo de limite loan
// transferência de dinheiro função
// as operações precisam receber a conta como parâmetro
// fazer função de percorrer a lista e colocar na função de criar conta


using System.ComponentModel;

namespace SistemaBancario
{
    class Menu
    {
        public int Home()
        {
            string userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione uma opção a seguir: ");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Entrar na Conta");
                Console.WriteLine("3 - Modo DEV");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
            }

            return 0;
        }

        public int AccountType()
        {
            string userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione o tipo da conta: ");
                Console.WriteLine("1 - Corrente");
                Console.WriteLine("2 - Empresarial");
                Console.WriteLine("3 - Poupança");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else Console.WriteLine("Opção inválida!");
            }

            return 0;
        }

    }


    abstract class BankAccount {
        public decimal Number { get; protected set; }
        public string Owner { get; protected set; }
        public decimal Balance { get; protected set; } = 0;
        public decimal LoanLimit { get; protected set; }

        public BankAccount CreateAccount(int accountType)
        {
            Random rdn = new Random();
            string ownerName;
            int accountNumber = rdn.Next(100000, 200000);

            Console.WriteLine("Insira seu nome:");
            ownerName = Console.ReadLine();


            // verifique o nome, não pode nulo
            BankAccount account = null;
            
            switch (accountType)
            {
                case 1:
                    account = new SavingAccount(accountNumber, ownerName, 0);
                    break;

                case 2:
                    account = new CheckingAccount(accountNumber, ownerName, 0);
                    break;

                case 3:
                    account = new BusinessAccount(accountNumber, ownerName, 0);
                    break;

            }

            if(account == null)
            {
                Console.WriteLine("Não foi possível criar a conta. Tente novamente.");
                return CreateAccount(accountType);
            }

            Console.WriteLine("Sucesso! Sua conta foi criada.");
            return account;
        }

        public void Deposit()
        {
            string userInput;
            bool isValidInput;
            decimal depositValue;

            Console.WriteLine("Insira o valor do depósito:");
            userInput = Console.ReadLine();
            isValidInput = decimal.TryParse(userInput, out depositValue);

            while (!isValidInput || depositValue <= 0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Insira o valor do depósito:");
                userInput = Console.ReadLine();
                isValidInput = decimal.TryParse(userInput, out depositValue);
            }

            Balance += depositValue;
            Console.WriteLine("Depósito concluído com sucesso! Saldo atual: {0}", Balance);
        }

        abstract public void Withdrawal(decimal amount);

        public BankAccount (int number, string owner, decimal balance)
        {
            this.Number = number;
            this.Owner = owner;
            this.Balance = balance;
        }

        public void Loan(decimal value)
        {
            if (value > LoanLimit)
            {
                Console.WriteLine("Empréstimo excede o limite!");
                return;
            }

            LoanLimit -= value;
            Balance += value;
            Console.WriteLine("Empréstimo concedido! Saldo atual: {0}", Balance);
        }
    }
    class CheckingAccount : BankAccount
    {
        public CheckingAccount (int number, string owner, decimal balance) : base(number, owner, balance) {
            LoanLimit = (balance * 0.3m) + balance;
        }

        private decimal WithdrawalTax { get; set; } = 0.05m;

        public override void Withdrawal (decimal value)
        {
            decimal total = (value * WithdrawalTax) + value;
            if (total > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }

            Balance -= total;
            Console.WriteLine("Transação concluída com sucesso! Saldo atual: {0}", Balance);
        }
    }

    class SavingAccount : BankAccount
    {
        public SavingAccount(int number, string owner, decimal balance) : base(number, owner, balance)
        {
            LoanLimit = (balance * 0.3m) + balance;
        }

        private decimal Income { get; set; } = 0.005m;

        public override void Withdrawal (decimal value)
        {
            if (value > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }

            Balance -= value;
            Console.WriteLine("Transação concluída com sucesso! Saldo atual: {0}", Balance);
        }

        public void IncomeForecast()
        {
            string userInput;
            bool isValidInput;
            int range; 
            decimal amount;

            Console.WriteLine("Defina o alcance da sua previsão, em meses: ");
            userInput = Console.ReadLine();
            isValidInput = int.TryParse(userInput, out range);

            while (!isValidInput || range < 1)
            {
                Console.WriteLine("Alcance inválido!");
                Console.WriteLine("Defina o alcance da sua previsão, em meses: ");
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out range);
            }

            amount = Balance;
            for (int i = range; i > 0; i--) amount = (amount * Income) + amount;

            Console.WriteLine("Em {0} meses, seu saldo será de {1:n2}", range, amount);
        }
    }

    class BusinessAccount : BankAccount
    {
        public BusinessAccount(int number, string owner, decimal balance) : base(number, owner, balance)
        {
            LoanLimit = (balance * 0.5m) + balance;
        }

        public override void Withdrawal (decimal value)
        {
            if (value > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }

            Balance -= value;
            Console.WriteLine("Transação concluída com sucesso! Saldo atual: {0}", Balance);
        }
    }

    class Utils
    {

    }

    class Program
    {
        static void Main ()
        {
            List<CheckingAccount> checkingAccounts = new List<CheckingAccount>();
            List<SavingAccount> savingAccounts = new List<SavingAccount>();
            List<BusinessAccount> businessAccounts = new List<BusinessAccount>();

            Menu menus = new Menu();
            int option = menus.Home();

            switch (option)
            {
                case 1:
                    menus.AccountType();
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;

            }

            CheckingAccount conta1 = new CheckingAccount(001, "Bilu", 300);

        }
    }
}


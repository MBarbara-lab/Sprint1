// tem mudar a política de cálculo de limite loan
// 

namespace SistemaBancario
{
    abstract class BankAccount {
        public decimal Number { get; protected set; }
        public string Owner { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal LoanLimit { get; protected set; }

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

        abstract public void Withdrawal(decimal amount);

        public BankAccount (int number, string owner, decimal balance)
        {
            this.Number = number;
            this.Owner = owner;
            this.Balance = balance;
        }
    }
    class CheckingAccount : BankAccount
    {
        public CheckingAccount (int number, string owner, decimal balance) : base(number, owner, balance) {
            LoanLimit = (balance * 0.3m) + balance;
        }

        private decimal withdrawalTax = 0.05m;
        public decimal WithdrawalTax
        {
            get { return withdrawalTax; }
            set { withdrawalTax = value; }
        }

        public override void Withdrawal (decimal value)
        {
            decimal total = (value * withdrawalTax) + value;
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

        private decimal income = 0.005m;

        public decimal Income
        {
            get { return income; }
            set { income = value; }
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
            for (int i = range; i > 0; i--) amount = (amount * income) + amount;

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

    class atividade1
    {
        public decimal divida = 5000;
        public bool dividaQuitada;
        public string nome, userValor;
        public bool isInputValid;
        public decimal valor;

        public void pagarDivida ()
        {
            Console.WriteLine("Digite seu nome:");
            nome = Console.ReadLine();

            while (!isInputValid || !dividaQuitada)
            {
                Console.WriteLine("Digite o valor que deseja pagar:");
                userValor = Console.ReadLine();

                isInputValid = decimal.TryParse(userValor, out valor);

                if (!isInputValid || valor < 1)
                {
                    Console.WriteLine("Valor inválido!");
                    continue;
                }

                divida -= valor;

                if (valor < divida)
                {
                    decimal sobra = divida - valor;
                    Console.WriteLine("Você ainda deve R${0:n2}", sobra);
                    continue;
                }

                Console.WriteLine("Sua dívida foi quitada, {0}!", nome);
                dividaQuitada = true;
            }
            
        }
    }

    class Menu
    {
        public int Home()
        {
            string userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0 && option < 2)
            {
                Console.WriteLine("Selecione uma opção a seguir: ");
                Console.WriteLine("1 - Criar Conta");
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

            while (option > 0 && option < 4)
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

    class Program
    {
        static void Main ()
        {
            //atividade1 atividade = new atividade1();
            //atividade.pagarDivida();


        }
    }
}


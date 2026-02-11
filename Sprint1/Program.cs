// tem mudar a política de cálculo de limite loan
// transferência de dinheiro função
// as operações precisam receber a conta como parâmetro

using System.ComponentModel;

namespace SistemaBancario
{
    class Menu
    {
        public static int Home()
        {
            string? userInput;
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;                             // caso a conversão falhe, TryParse atribui 0 ao segundo parâmetro
                } 
            }

            return 0;
        }
        public static int User(Person Person)
        {
            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Olá, {0}! Selecione sua conta: ", Person.Name);
                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Empresarial");
                Console.WriteLine("3 - Poupança");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

        public static int AccountType()
        {
            string? userInput;
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

        public static int DevOptions ()
        {
            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione o que deseja fazer:");
                Console.WriteLine("1 - Listar todas as contas");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

    }

    class Person
    {
        public int Age { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }

        public Person (int age, string? cpf, string? name)
        {
            Age = age;
            Cpf = cpf;
            Name = name;
        }
    }
    abstract class BankAccount {
        public decimal Balance { get; protected set; } = 0;
        public decimal LoanLimit { get; protected set; }
        public decimal Number { get; protected set; }
        public Person Owner { get; protected set; }
        public string? Type { get; protected set; }

        abstract public void Withdrawal(decimal amount);

        public void Deposit()
        {
            string? userInput;
            bool isValidInput;
            decimal depositValue;

            do
            {
                Console.WriteLine("Insira o valor do depósito:");
                userInput = Console.ReadLine();
                isValidInput = decimal.TryParse(userInput, out depositValue);

                if (!isValidInput || depositValue <= 0) Console.WriteLine("Valor inválido");
            } while (!isValidInput || depositValue <= 0);    

            Balance += depositValue;
            Console.WriteLine("Depósito concluído com sucesso! Saldo atual: {0}", Balance);
        }

        //public void Transfer (BankAccount destination, decimal value)
        //{
        //    if (Balance < value)
        //    {
                
        //    }
        //}

        public BankAccount (int number, Person owner, decimal balance)
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
        public CheckingAccount (int number, Person owner, decimal balance) : base(number, owner, balance) {
            LoanLimit = (balance * 0.3m) + balance;
            Type = "Corrente";
        }

        private decimal WithdrawalTax { get; set; } = 0.05m;

        public override void Withdrawal (decimal value)
        {
            decimal total = (value * WithdrawalTax) + value;
            if (total > Balance || value >= 0)
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
        public SavingAccount(int number, Person owner, decimal balance) : base(number, owner, balance)
        {
            LoanLimit = (balance * 0.3m) + balance;
            Type = "Poupança";
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
            string? userInput;
            bool isValidInput;
            int range; 
            decimal amount;

            do
            {
                Console.WriteLine("Defina o alcance da sua previsão, em meses: ");
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out range);

                if(!isValidInput || range < 1) Console.WriteLine("Alcance inválido!");
            } while (!isValidInput || range < 1);

            amount = Balance;
            for (int i = range; i > 0; i--) amount *= (1 + Income);

            Console.WriteLine("Em {0} meses, seu saldo será de {1:n2}", range, amount);
        }
    }

    class BusinessAccount : BankAccount
    {
        public BusinessAccount(int number, Person owner, decimal balance) : base(number, owner, balance)
        {
            LoanLimit = (balance * 0.5m) + balance;
            Type = "Empresarial";
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
        public static void PrintAccounts<T>(List<T>list) where T : BankAccount {
            foreach (T account in list)
            {
                Console.WriteLine("Titular {0}", account.Owner.Name);
                Console.WriteLine(" Tipo:  {0}", account.Type);
                Console.WriteLine(" Conta: {0}", account.Number);
                Console.WriteLine(" Saldo: R$ {0:n2}", account.Balance);
            }
        }
    }

    class Program
    {
        static void Main ()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            int option = 1;
            while (option != 0)
            {
                option = Menu.Home();
                switch (option)
                {
                    case 0: 
                        Console.Clear();
                        break;

                    case 1:
                        Console.Clear();
                        Random rdn = new Random();
                        string? userInput;
                        bool isValidInput;
                        int accountNumber;
                        int ownerAge;
                        string? ownerCpf;
                        string? ownerName;

                        //validação nome
                        do
                        {
                            isValidInput = true;
                            Console.WriteLine("Insira seu nome:");
                            ownerName = Console.ReadLine();
                            ownerName = ownerName?.Trim() ?? "";
                            if (ownerName == "") Console.WriteLine("Seu nome não pode ser nulo! Tente novamente.");

                            foreach (char letter in ownerName)
                            {
                                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                                {
                                    Console.WriteLine("Seu nome deve conter apenas letras e espaços! Tente novamente.");
                                    isValidInput = false;
                                    break;
                                }
                            }
                        } while (ownerName == "" || !isValidInput);

                        //validação cpf
                        do
                        {
                            isValidInput = true;
                            Console.WriteLine("Insira seu CPF: (Apenas dígitos)");
                            ownerCpf = Console.ReadLine();
                            ownerCpf = ownerCpf?.Trim() ?? "";
                            if (ownerCpf == "")
                            {
                                Console.WriteLine("Seu CPF não pode ser nulo! Tente novamente.");
                                continue;
                            }

                            foreach (char digit in ownerCpf)
                            {
                                if (!char.IsDigit(digit))
                                {
                                    Console.WriteLine("Seu CPF deve conter apenas dígitos! Tente novamente.");
                                    isValidInput = false;
                                    break;
                                }
                            }

                        } while (ownerCpf == "" || !isValidInput);

                        //validação idade
                        do
                        {
                            Console.WriteLine("Insira sua idade:");
                            userInput = Console.ReadLine();
                            isValidInput = int.TryParse(userInput, out ownerAge);

                            if (!isValidInput || ownerAge <= 0) 
                            {
                                Console.WriteLine("Idade inválida");
                                continue;
                            }
                            
                            if (ownerAge < 18)
                            {
                                Console.WriteLine("Você não possui idade suficiente para abrir uma conta!");
                                isValidInput = false;
                            } 
                        } while (!isValidInput || ownerAge <= 0);

                        Person newClient = new Person(ownerAge, ownerCpf, ownerName);

                        int typeOption = 1;
                        while (typeOption != 0)
                        {
                            typeOption = Menu.AccountType();
                            switch (typeOption)
                            {
                                case 0: 
                                    Console.Clear();
                                    break;

                                case 1:
                                    Console.Clear();
                                    accountNumber = rdn.Next(100, 200); // valor ideal: 100000, 20000
                                    bankAccounts.Add(new CheckingAccount(accountNumber, newClient, 0));
                                    break;

                                case 2:
                                    Console.Clear();
                                    accountNumber = rdn.Next(100, 200);
                                    bankAccounts.Add(new BusinessAccount(accountNumber, newClient, 0));
                                    break;

                                case 3:
                                    Console.Clear();
                                    accountNumber = rdn.Next(100, 200);
                                    bankAccounts.Add(new SavingAccount(accountNumber, newClient, 0));
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção inválida! Tente novamente.");
                                    break;
                            }
                        }
                        break;

                    case 2:

                        break;

                    case 3:
                        Console.Clear();
                        int devOptions = 1;
                        while (devOptions != 0)
                        {
                            devOptions = Menu.DevOptions();
                            switch (devOptions)
                            {
                                case 0: 
                                    Console.Clear();
                                    break;

                                case 1:
                                    Console.Clear();
                                    Utils.PrintAccounts(bankAccounts);
                                    
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção inválida! Tente novamente.");
                                    break;
                            }
                        }
                    
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;

                }

            }

        }
    }
}


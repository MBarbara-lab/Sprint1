// transferência de dinheiro função
// centralizar validações em uma classe
// empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
// usar construtor primário
// refazer a lópgica de saquew, checkin

// funcionalidade de pagar empréstimo. se pagar parcelado, juros cumulativos

// dá p enxugar as validações de enrada, retirando a bool isValidInput

// EM PROPGRESSO:
// 1. limite de empréstimo baseado na renda mensal informada. poupança e corrente com a mesma renda. empresarial diferente
// 2. TRANSAÇÕES DEPOIUS DE SELECIONAR CONTA
using SistemaBancario.BankAccounts;

namespace SistemaBancario
{
    class Program
    {
        static void Main ()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            List<Person> owners = new List<Person>();

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
                        Person? client;
                        string? userInput;
                        bool isValidInput;
                        int accountNumber;
                        int ownerAge;
                        string? ownerCpf;
                        string? ownerName;

                        //validação cpf
                        do
                        {
                            isValidInput = true;
                            Console.WriteLine("Insira seu CPF: (Apenas dígitos)");
                            ownerCpf = Console.ReadLine();
                            ownerCpf = ownerCpf?.Trim() ?? "";
                            if (ownerCpf == "")
                            {
                                Console.Clear();
                                Console.WriteLine("Seu CPF não pode ser nulo! Tente novamente.");
                                continue;
                            }

                            foreach (char digit in ownerCpf)
                            {
                                if (!char.IsDigit(digit))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Seu CPF deve conter apenas dígitos! Tente novamente.");
                                    isValidInput = false;
                                    break;
                                }
                            }

                            if (!isValidInput) continue;

                            if (ownerCpf.Length != 11)
                            {
                                Console.Clear();
                                Console.WriteLine("Seu CPF deve conter 11 dígitos! Tente novamente.");
                                isValidInput = false;
                            }

                        } while (ownerCpf == "" || !isValidInput);

                        if (Utils.SearchOwner(owners, ownerCpf) == null)
                        {
                            Console.Clear();
                            //validação nome
                            do
                            {
                                isValidInput = true;
                                Console.WriteLine("Insira seu nome:");
                                ownerName = Console.ReadLine();
                                ownerName = ownerName?.Trim() ?? "";
                                if (ownerName == "") {
                                    Console.Clear();
                                    Console.WriteLine("Seu nome não pode ser nulo! Tente novamente.");
                                }

                                foreach (char letter in ownerName)
                                {
                                    if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Seu nome deve conter apenas letras e espaços! Tente novamente.");
                                        isValidInput = false;
                                        break;
                                    }
                                }
                            } while (ownerName == "" || !isValidInput);

                            Console.Clear();
                            //validação idade
                            do
                            {
                                Console.WriteLine("Insira sua idade:");
                                userInput = Console.ReadLine();
                                isValidInput = int.TryParse(userInput, out ownerAge);

                                if (!isValidInput || ownerAge <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Idade inválida");
                                    continue;
                                }

                                if (ownerAge < 18)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você não possui idade suficiente para abrir uma conta!");
                                    isValidInput = false;
                                }
                            } while (!isValidInput || ownerAge <= 0);

                            Console.Clear();
                            //validação renda mensal
                            decimal monthlyIncome;
                            do
                            {
                                Console.WriteLine("Insira sua renda mensal (em R$):");
                                userInput = Console.ReadLine();
                                isValidInput = decimal.TryParse(userInput, out monthlyIncome);

                                if (!isValidInput || monthlyIncome <= 0) {
                                    Console.Clear();
                                    Console.WriteLine("Valor inválido");
                                }
                            } while (!isValidInput || monthlyIncome <= 0);

                            client = new Person(ownerAge, ownerCpf, monthlyIncome, ownerName);
                            owners.Add(client);

                        }
                        else
                        {
                            client = Utils.SearchOwner(owners, ownerCpf);
                        }

                        Console.Clear();
                        int typeOption = 1;
                        bool isAccountCreated = false;
                        while (typeOption != 0 && !isAccountCreated)
                        {
                            typeOption = Menu.AccountType();
                            switch (typeOption)
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
                                    
                                    //validação renda mensal
                                    decimal monthlyIncome;
                                    do
                                    {
                                        Console.WriteLine("Insira a renda mensal do seu negócio:");
                                        userInput = Console.ReadLine();
                                        isValidInput = decimal.TryParse(userInput, out monthlyIncome);

                                        if (!isValidInput || monthlyIncome <= 0) Console.WriteLine("Valor inválido");
                                    } while (!isValidInput || monthlyIncome <= 0);
                                    Console.Clear();

                                    bankAccounts.Add(new Business(accountNumber, client, monthlyIncome));
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
                        break;

                    case 2:
                        do
                        {
                            isValidInput = true;
                            Console.Clear();
                            Console.WriteLine("Insira seu CPF: (Apenas dígitos)");
                            ownerCpf = Console.ReadLine();
                            ownerCpf = ownerCpf?.Trim() ?? "";
                            if (ownerCpf == "")
                            {
                                Console.Clear();
                                Console.WriteLine("Seu CPF não pode ser nulo! Tente novamente.");
                                continue;
                            }

                            foreach (char digit in ownerCpf)
                            {
                                if (!char.IsDigit(digit))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Seu CPF deve conter apenas dígitos! Tente novamente.");
                                    isValidInput = false;
                                    break;
                                }
                            }

                            if (!isValidInput) continue;

                            if (ownerCpf.Length != 11)
                            {
                                Console.Clear();
                                Console.WriteLine("Seu CPF deve conter 11 dígitos! Tente novamente.");
                                isValidInput = false;
                            }

                        } while (ownerCpf == "" || !isValidInput);

                        if (Utils.SearchOwner(owners, ownerCpf) == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Seu usuário não foi encontrado. Cadastre-se!");
                            break;
                        } else
                        {
                            client = Utils.SearchOwner(owners, ownerCpf);
                        }
                        BankAccount? currentAccount = Menu.UserAccounts(client, bankAccounts);

                        int transactionOption = 1;
                        while (transactionOption != 0)
                        {
                            transactionOption = Menu.Transactions(currentAccount);
                            switch (option)
                            {
                                case 0:
                                    Console.Clear();
                                    break;

                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Op1");
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Op2");
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Op3");
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção inválida! Tente novamente.");
                                    break;
                            }
                        }
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

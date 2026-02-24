// transferência de dinheiro função
// centralizar validações em uma classe
// empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
// usar construtor primário
// refazer a lópgica de saquew, checkin
// 2. TRANSAÇÕES DEPOIUS DE SELECIONAR CONTA

// funcionalidade de pagar empréstimo. se pagar parcelado, juros cumulativos

// dá p enxugar as validações de enrada, retirando a bool isValidInput

// EM PROPGRESSO:
// menu de criar conta

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

                        int accountNumber, ownerAge;

                        string? ownerCpf = Validation.Cpf();
                        if (ownerCpf == null) break;

                        if (Utils.SearchOwner(owners, ownerCpf) == null)
                        {
                            Console.Clear();
                            string? ownerName = Validation.Name();

                            Console.Clear();
                            ownerAge = Validation.Age();

                            Console.Clear();
                            decimal ownerMonthlyIncome = Validation.MonthlyIncome("Insira a sua renda mensal: ");

                            client = new Person(ownerAge, ownerCpf, ownerMonthlyIncome, ownerName);
                            owners.Add(client);
                        }
                        else
                        {
                            client = Utils.SearchOwner(owners, ownerCpf);
                            if (client == null) break; 
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
                        break;

                    case 2:
                        Console.Clear();
                        ownerCpf = Validation.Cpf();
                        if (ownerCpf == null) break;

                        if (Utils.SearchOwner(owners, ownerCpf) == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Seu usuário não foi encontrado. Cadastre-se!");
                            break;
                        } else
                        {
                            client = Utils.SearchOwner(owners, ownerCpf);
                            if (client == null) break;
                        }
                        
                        Console.Clear();
                        BankAccount? currentAccount = Menu.UserAccounts(client, bankAccounts);
                        if (currentAccount == null) break;

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

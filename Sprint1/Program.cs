// ===============================================================================================================================================
// EXTRA:
// -> Empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
// -> Usar construtor primário

// PENDENTES:
// - Função Transferir
// - Transações após selecionar conta
// - Pagar empréstimo. Se pagar parcelado, juros cumulativos
// - Enxugar as validações de entrada, retirando a bool isValidInput
// - UI nos textos: https://gemini.google.com/app/a9e3bd3d2f67f91b?hl=pt-BR
// - Deletar o código de Validation
// - Melhorar o Controller

// EM PROPGRESSO:
// - Menu de criar conta

// ===============================================================================================================================================


using SistemaBancario.BankAccounts;

namespace SistemaBancario
{
    class Program
    {
        static void Main()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            List<Person> owners = new List<Person>();

            Person pessoa = new Person(40, "12345678901", 2000, "OII");
            Checking conta = new Checking(3456, pessoa);
            conta.Deposit();

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

                        int ownerAge;

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
                        Controller.AccountType(client, bankAccounts);
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

                        //int transactionOption = 1;
                        //while (transactionOption != 0)
                        //{
                        //    transactionOption = Menu.Transactions(currentAccount);
                        //    switch (option)
                        //    {
                        //        case 0:
                        //            Console.Clear();
                        //            break;

                        //        case 1:
                        //            Console.Clear();
                        //            Console.WriteLine("Op1");
                        //            break;

                        //        case 2:
                        //            Console.Clear();
                        //            Console.WriteLine("Op2");
                        //            break;

                        //        case 3:
                        //            Console.Clear();
                        //            Console.WriteLine("Op3");
                        //            break;

                        //        default:
                        //            Console.Clear();
                        //            Console.WriteLine("Opção inválida! Tente novamente.");
                        //            break;
                        //    }
                        //}
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

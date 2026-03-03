// ===============================================================================================================================================
// EXTRA:
// -> Empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
// -> Usar construtor primário
// -> Contas compartilhadas

// PENDENTES:
// - Função Transferir
// - Transações após selecionar conta
// - Pagar empréstimo. Se pagar parcelado, juros cumulativos
// - Enxugar as validações de entrada, retirando a bool isValidInput
// - UI nos textos: https://gemini.google.com/app/a9e3bd3d2f67f91b?hl=pt-BR

// EM PROPGRESSO:
// - Menu de criar conta

// ===============================================================================================================================================


using SistemaBancario.BankAccounts;
using SistemaBancario.Owner;

namespace SistemaBancario
{
    class Program
    {
        static void Main()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            List<IAccountOwner> owners = new List<IAccountOwner>();

            //Person pessoa = new Person(40, "12345678901", 2000, "OII");
            //Checking conta = new Checking(3456, pessoa);
            //Saving conta2 = new Saving(3456, pessoa);
            //Business conta3 = new Business(3456, pessoa, 5000);

            //conta.Deposit();
            //conta.WithdrawLoan();
            //conta.Withdrawal();
            //conta.PayLoan();
            //conta.PayLoan();

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
                        IAccountOwner? client;

                        int ownerAge;

                        string? ownerCpf = Validation.Cpf();
                        if (ownerCpf == null) break;

                        client = Utils.SearchOwner(owners, ownerCpf);

                        if (client == null)
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

                        Controller.Transactions(currentAccount);
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

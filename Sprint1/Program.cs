// ===============================================================================================================================================
// EXTRA:
// -> // - Função de hash p senhas
// -> Empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
//      + Campo para o representante legal da empresa
//      + Verificação de CNPJ válido
// -> Usar construtor primário
// -> Contas compartilhadas

// PENDENTES:
// - Função Transferir
// - Verificar email válido, senha válida
// - Alterar dados pessoais
// - Pagar empréstimo. Se pagar parcelado, juros cumulativos
// - Padrão MVC simplificado, class View, Controller e Model
// - UI nos textos: https://gemini.google.com/app/a9e3bd3d2f67f91b?hl=pt-BR

// EM PROPGRESSO:
// - criação de conta. se pj, direto p conta empresárial. else, escolhe entre poupança e corrente

// ===============================================================================================================================================


using SistemaBancario.BankAccounts;
using SistemaBancario.Owner;

namespace SistemaBancario
{
    class Program
    {
        static void Main()
        {
            List<User> users = new();
            List<Person> people = new();
            List<Company> companies = new();
            List<BankAccount> bankAccounts = new();

            int option;
            do
            {
                option = Menu.Start();
                string? userEmail, userPassword;
                User? currentUser;

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    case 1:
                        Console.WriteLine("Informe o email que deseja cadastrar:");
                        userEmail = Console.ReadLine();

                        Console.WriteLine("Informe a senha que deseja cadastrar:");
                        userPassword = Console.ReadLine();

                        User newUser = new User(userEmail, userPassword);
                        users.Add(newUser);
                        break;

                    case 2:
                        Console.WriteLine("Informe seu email:");
                        userEmail = Console.ReadLine();

                        Console.WriteLine("Informe sua senha:");
                        userPassword = Console.ReadLine();

                        currentUser = Utils.SearchUser(users, userEmail, userPassword);
                        if (currentUser != null)
                        {
                            int homeOption;
                            do
                            {
                                homeOption = Menu.Home(currentUser);

                                switch (homeOption)
                                {
                                    case 0:
                                        break;

                                    case 1:
                                        int userType;
                                        
                                        do
                                        {
                                            userType = Menu.UserType();

                                            switch (userType)
                                            {
                                                case 0:
                                                    break;

                                                case 1:
                                                    Controller.AccountType(currentUser, )
                                                    break;

                                                case 2:
                                                    break;

                                                default:
                                                    break;
                                            }
                                        }


                                        Random rdn = new Random();
                                        IAccountOwner? client;

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
                                        break;

                                    case 3:
                                        break;
                                }

                            } while (homeOption != 0);
                        }
                        break;

                    case 3:
                        break;

                    default:
                        break;
                }

            } while (option != 0);

        }
    }
}

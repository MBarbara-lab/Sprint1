// ===============================================================================================================================================
// EXTRA:
// - Trocar lógica de busca por find()
// - Função Transferir
// -> verificações com regex: cpf, cnpj, email
// -> Função Excluir conta
// -> Padrão MVC simplificado, class View, Controller e Model
// -> UI nos textos: https://gemini.google.com/app/a9e3bd3d2f67f91b?hl=pt-BR
// -> Melhorar aleatoridade do id de usuário
// -> Função de hash p senhas
// -> Empresarial vai passar a receber cnpj (alfanumérico) e pessoa vai passar a possuir cnpj tbm ;)
//      + Campo para o representante legal da empresa
//      + Verificação de CNPJ válido
// -> Usar construtor primário
// -> Contas compartilhadas


// PENDENTES:
// - exclusão age validation
// - Verificação data de nascimento
// - Verificação cnpj
// - Verificação se já existe alguma empresa cadastrada com esse cnpj
// - Alterar dados pessoais
// - Pagar empréstimo. Juros simples no valor da dívida


// EM PROPGRESSO:
// -> 
// -> isaccountcreated tá duplicada

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
            List<IAccountOwner> owners = new();
            List<Person> people = new();
            List<Company> companies = new();
            List<BankAccount> bankAccounts = new();

            int option;
            do
            {
                Random rdn = new Random();
                option = Menu.Start();
                string? userEmail, userPassword;
                User? currentUser;

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    case 1:
                        int userId = rdn.Next(100, 900);
                        
                        Console.Clear();
                        userEmail = Validation.Email("Informe o email que deseja cadastrar:", users);

                        userPassword = Validation.Password("Informe a senha que deseja cadastrar:");

                        User newUser = new User(userId, userEmail, userPassword);
                        users.Add(newUser);
                        
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Informe seu email: ");
                        userEmail = Console.ReadLine();

                        Console.WriteLine("Informe sua senha: ");
                        userPassword = Console.ReadLine();

                        currentUser = Utils.SearchUser(users, userEmail, userPassword);
                        if (currentUser == null) {
                            Console.Clear();
                            Console.WriteLine("Email ou senha incorretos.");
                            break;
                        }

                        Console.Clear();
                        int homeOption;
                        bool isAccountCreated = false;
                        do
                        {
                            homeOption = Menu.Home(currentUser);

                            switch (homeOption)
                            {
                                case 0:
                                    Console.Clear();
                                    break;

                                case 1:
                                    Console.Clear();
                                    int accountNumber;
                                    IAccountOwner newOwner;

                                    int userType;
                                    do
                                    {
                                        userType = Menu.UserType();

                                        switch (userType)
                                        {
                                            case 0:
                                                Console.Clear();
                                                break;

                                            case 1:
                                                Console.Clear();
                                                newOwner = Utils.SearchOwner(owners, currentUser.Id);

                                                if (newOwner == null)
                                                {
                                                    string ownerCpf = Validation.Cpf(users);

                                                    Console.Clear();
                                                    string? ownerName = Validation.Name("Insira seu nome: ");

                                                    Console.Clear();
                                                    Console.WriteLine("Insira sua data de nascimento:");
                                                    string? ownerDateOfBirth = Console.ReadLine();

                                                    Console.Clear();
                                                    decimal ownerMonthlyIncome = Validation.MonthlyIncome("Insira a sua renda mensal: ");

                                                    currentUser.setPersonCpf(ownerCpf);
                                                    newOwner = new Person(currentUser.Id, ownerCpf, ownerDateOfBirth, ownerMonthlyIncome, ownerName);
                                                    owners.Add(newOwner);
                                                }

                                                Console.Clear();
                                                Controller.AccountType(currentUser.Id, newOwner, bankAccounts);
                                                isAccountCreated = true;
                                                break;

                                            case 2:
                                                Console.Clear();
                                                accountNumber = rdn.Next(100000, 200000);

                                                Console.Clear();
                                                string? companyName = Validation.Name("Insira o nome da sua empresa: ");

                                                Console.Clear();
                                                Console.WriteLine("Insira o CNPJ da empresa: ");
                                                string? companyCnpj = Console.ReadLine();

                                                Console.Clear();
                                                decimal revenue = Validation.MonthlyIncome("Insira a renda mensal do seu negócio: ");

                                                newOwner = new Company(currentUser.Id, companyCnpj, companyName, revenue);
                                                
                                                bankAccounts.Add(new Business(accountNumber, newOwner, currentUser.Id));

                                                Console.Clear();
                                                Console.WriteLine("Sua conta empresarial foi criada!");
                                                isAccountCreated = true;
                                                break;

                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Opção inválida!");
                                                break;
                                        }
                                    } while (userType != 0 && !isAccountCreated);

                                    break;

                                case 2:
                                    BankAccount? currentBankAccount;
                                        
                                    Console.Clear();
                                    currentBankAccount = Menu.UserAccounts(currentUser.Id, owners, bankAccounts);

                                    if (currentBankAccount == null)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Você ainda não possui nenhuma conta.");
                                        break;
                                    }

                                    Controller.Transactions(currentBankAccount);
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opção inválida!");
                                    break;
                            }

                            } while (homeOption != 0);
                        break;

                    case 3:
                        int devModeOption;
                        do
                        {
                            devModeOption = Menu.DevOptions();

                            switch (devModeOption)
                            {
                                case 0:
                                    Console.Clear();
                                    break;

                                case 1:
                                    Console.Clear();
                                    Utils.PrintAccounts(bankAccounts, owners);
                                    break;

                                case 2:
                                    Console.Clear();
                                    Utils.PrintUsers(users);
                                    break;
                            }
                        } while (devModeOption != 0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (option != 0);

        }
    }
}

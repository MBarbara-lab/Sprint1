// ===============================================================================================================================================
// EXTRA:
// - deixar de passar user total e passar só o id?
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
// - Verificar email válido
// - Verificar senha válida
// - Verificação cnpj
// - Função Transferir
// - Alterar dados pessoais
// - Pagar empréstimo. Se pagar parcelado, juros cumulativos
// - Padrão MVC simplificado, class View, Controller e Model
// - UI nos textos: https://gemini.google.com/app/a9e3bd3d2f67f91b?hl=pt-BR

// EM PROPGRESSO:
// - criação de conta. se pj, direto p conta empresárial. else, escolhe entre poupança e corrente
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
                        Console.WriteLine("Informe o email que deseja cadastrar:");
                        userEmail = Console.ReadLine();

                        Console.WriteLine("Informe a senha que deseja cadastrar:");
                        userPassword = Console.ReadLine();

                        User newUser = new User(userId, userEmail, userPassword);
                        users.Add(newUser);
                        break;

                    case 2:
                        Console.WriteLine("Informe seu email:");
                        userEmail = Console.ReadLine();

                        Console.WriteLine("Informe sua senha:");
                        userPassword = Console.ReadLine();

                        currentUser = Utils.SearchUser(users, userEmail, userPassword);
                        if (currentUser == null) {
                            Console.Clear();
                            Console.WriteLine("Email ou senha incorretos.");
                            break;
                        }

                        int homeOption;
                        bool isAccountCreated = false;
                        do
                        {
                            homeOption = Menu.Home(currentUser);

                            switch (homeOption)
                            {
                                case 0:
                                    break;

                                case 1:
                                    //Random rdn = new Random();
                                    int accountNumber;
                                    Company? newCompany;
                                        
                                    Person? newPerson;

                                    int userType;
                                    do
                                    {
                                        userType = Menu.UserType();

                                        switch (userType)
                                        {
                                            case 0:
                                                break;

                                            case 1:
                                                string? ownerCpf = Validation.Cpf();
                                                if (ownerCpf == null) break;

                                                newPerson = Utils.SearchPerson(people, ownerCpf);
                                                if (newPerson == null)
                                                {
                                                    Console.Clear();
                                                    string? ownerName = Validation.Name("Insira seu nome: ");

                                                    string? ownerDateOfBirth = Console.ReadLine();

                                                    Console.Clear();
                                                    decimal ownerMonthlyIncome = Validation.MonthlyIncome("Insira a sua renda mensal: ");

                                                    newPerson = new Person(currentUser.Id, ownerCpf, ownerDateOfBirth, ownerMonthlyIncome, ownerName);
                                                    people.Add(newPerson);
                                                }

                                                Console.Clear();
                                                Controller.AccountType(currentUser, newPerson, bankAccounts);
                                                isAccountCreated = true;
                                                break;

                                            case 2:
                                                Console.Clear();
                                                accountNumber = rdn.Next(100000, 200000);

                                                Console.Clear();
                                                string? companyName = Validation.Name("Insira o nome da sua empresa: ");

                                                string? companyCnpj = Console.ReadLine();

                                                decimal revenue = Validation.MonthlyIncome("Insira a renda mensal do seu negócio: ");

                                                newCompany = new Company(currentUser.Id, companyCnpj, companyName, revenue);
                                                
                                                bankAccounts.Add(new Business(accountNumber, newCompany, currentUser));

                                                Console.Clear();
                                                Console.WriteLine("Sua conta empresarial foi criada!");
                                                isAccountCreated = true;
                                                break;

                                            default:
                                                break;
                                        }
                                    } while (userType != 0 && !isAccountCreated);
                                    break;

                                    case 2:
                                        
                                        break;

                                    case 3:
                                        break;
                                }

                            } while (homeOption != 0 && !isAccountCreated);
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

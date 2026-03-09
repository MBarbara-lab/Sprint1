using SistemaBancario.BankAccounts;
using SistemaBancario.Owner;

namespace SistemaBancario
{
    class Utils
    {
        public static void PrintUsers(List<User> users)
        {
            foreach (User user in users)
            {
                if (user == null) {
                    Console.Clear();
                    Console.WriteLine("Não há nenhum usuário cadastrado.");
                    break;
                };

                Console.WriteLine("Titular {0}", user.Id);
                Console.WriteLine(" Email {0}", user.Email);
                Console.WriteLine(" Senha {0}", user.Password);
                Console.WriteLine(" Tipo:  {0}", user.PersonCpf);
            }
        }

        public static void PrintAccounts<T>(List<T> list, List<IAccountOwner> owners) where T : BankAccount
        {
            IAccountOwner? currentOwner;
            foreach (T account in list)
            {
                currentOwner = Utils.SearchOwner(owners, account.UserId);

                if (account == null || currentOwner == null)
                {
                    Console.WriteLine("Nenhuma conta encontrada.");
                    break;
                }

                Console.WriteLine("Titular {0}", currentOwner.Name);
                Console.WriteLine(" Tipo:  {0}", account.Type);
                Console.WriteLine(" Conta: {0}", account.Number);
                Console.WriteLine(" Saldo: R$ {0:n2}", account.Balance);
            }
        }

        public static IAccountOwner? SearchOwner(List<IAccountOwner> owners, int searchedUserId)
        {
            foreach (IAccountOwner owner in owners)
            {
                if (owner.UserId == searchedUserId) return owner;
            }
            return null;
        }

        public static Person? SearchPerson(List<Person> people, string searchedCpf)
        {
            foreach (Person person in people)
            {
                if (person.Identifier == searchedCpf) return person;
            }
            return null;
        }

        public static Company? SearchCompany(List<Company> companies, string searchedCnpj)
        {
            foreach (Company company in companies)
            {
                if (company.Identifier == searchedCnpj) return company;
            }
            return null;
        }

        public static User? SearchUser(List<User> users, string searchedEmail, string searchedPassword)
        {
            int i = 0;
            while (i < users.Count && users[i].Email != searchedEmail) i++;

            if (i >= users.Count() || users[i].Password != searchedPassword) return null;
            
            return users[i];
        }
    }
}

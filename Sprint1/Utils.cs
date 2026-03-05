using SistemaBancario.BankAccounts;
using SistemaBancario.Owner;

namespace SistemaBancario
{
    class Utils
    {
        public static void PrintAccounts<T>(List<T> list, List<IAccountOwner> owners) where T : BankAccount
        {
            IAccountOwner? currentOwner;
            foreach (T account in list)
            {
                currentOwner = Utils.SearchOwner(owners, account.OwnerIdentifier);

                if (currentOwner == null) continue;

                Console.WriteLine("Titular {0}", currentOwner.Name);
                Console.WriteLine(" Tipo:  {0}", account.Type);
                Console.WriteLine(" Conta: {0}", account.Number);
                Console.WriteLine(" Saldo: R$ {0:n2}", account.Balance);
            }
        }

        public static IAccountOwner? SearchOwner(List<IAccountOwner> owners, string searchedIdentifier)
        {
            foreach (IAccountOwner owner in owners)
            {
                if (owner.Identifier == searchedIdentifier) return owner;
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
            while (users[i].Email != searchedEmail) i++;

            if (i >= users.Count() || users[i].Password == searchedPassword) return null;
            
            return users[i];
        }
    }
}

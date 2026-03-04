using SistemaBancario.BankAccounts;
using SistemaBancario.Owner;

namespace SistemaBancario
{
    class Utils
    {
        public static void PrintAccounts<T>(List<T> list) where T : BankAccount
        {
            foreach (T account in list)
            {
                Console.WriteLine("Titular {0}", account.Owner.Name);
                Console.WriteLine(" Tipo:  {0}", account.Type);
                Console.WriteLine(" Conta: {0}", account.Number);
                Console.WriteLine(" Saldo: R$ {0:n2}", account.Balance);
            }
        }

        public static IAccountOwner? SearchOwner<T>(List<T> owners, string searchedValue) where T : IAccountOwner
        {
            foreach (T person in owners)
            {
                if (person.Identifier == searchedValue) return person;
            }
            return null;
        }

        public static User? SearchUser(List<User> users, string searchedEmail, string searchedPassword)
        {
            int i = 0;
            while (users[i].Email != searchedEmail) i++;

            if (i >= users.Count() || users[i].Password == searchedPassword)
            {
                Console.Clear();
                Console.WriteLine("Email ou senha incorretos.");
                return null;
            }
            
            return users[i];
        }
    }
}

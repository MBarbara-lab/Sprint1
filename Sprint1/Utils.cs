using SistemaBancario.BankAccounts;

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

        public static Person? SearchOwner<T>(List<T> owners, string searchedValue) where T : Person
        {
            foreach (T person in owners)
            {
                if (person.Cpf == searchedValue) return person;
            }
            return null;
        }
    }
}

using System;
using SistemaBancario.BankAccounts;

namespace SistemaBancario
{
    class Menu
    {
        public static int Home()
        {
            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Entrar na Conta");
                Console.WriteLine("3 - Modo DEV");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;                             // caso a conversão falhe, TryParse atribui 0 ao segundo parâmetro
                }
            }

            return 0;
        }
        public static BankAccount? UserAccounts(Person person, List<BankAccount> bankAccounts)
        {
            List<BankAccount> userAccounts = new List<BankAccount>();
            if (person == null) return null;

            string? userInput;
            bool isValidInput = false;
            int option = 1;

            while (option > 0 || !isValidInput)
            {
                Console.WriteLine("Olá, {0}! Selecione sua conta: ", person.Name);

                int i = 1;
                foreach (BankAccount account in bankAccounts)
                {
                    if (account.Owner.Cpf == person.Cpf)
                    {
                        Console.WriteLine("#{0} - Conta {1}", i, account.Type);
                        Console.Write("Saldo: {0}", account.Balance);
                        Console.Write("\tNumero da conta: {0}\n", account.Number);
                        userAccounts.Add(account);
                        i++;
                    }
                }
                Console.WriteLine("\n0 - Sair");

                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out option);

                Console.Clear();
                if (option >= userAccounts.Count || !isValidInput)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    isValidInput = false;
                    option = 1;
                    continue;
                }

                Console.WriteLine("Conta {0} selecionada", userAccounts[option - 1].Type);
                Console.WriteLine("Número: {0} \t Saldo: {1:n2}", userAccounts[option - 1].Number, userAccounts[option - 1].Balance);
                return userAccounts[option - 1];
            }

            return null;
        }
        public static int Transactions(BankAccount account)
        {
            if (account == null) return 0;

            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione a transação que deseja realizar: ");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Empréstimo");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

        public static int AccountType()
        {
            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione o tipo da conta que deseja criar: ");
                Console.WriteLine("1 - Corrente");
                Console.WriteLine("2 - Empresarial");
                Console.WriteLine("3 - Poupança");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

        public static int DevOptions()
        {
            string? userInput;
            bool isValidInput;
            int option = 1;

            while (option > 0)
            {
                Console.WriteLine("Selecione o que deseja fazer:");
                Console.WriteLine("1 - Listar todas as contas");
                Console.WriteLine("0 - Sair");
                userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out option);

                if (isValidInput) return option;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    option = 1;
                }
            }

            return 0;
        }

    }
}
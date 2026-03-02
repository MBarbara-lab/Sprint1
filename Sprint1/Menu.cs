using SistemaBancario.BankAccounts;

namespace SistemaBancario
{
    class Menu
    {
        //public static int Start()
        //{
        //    var validation = (result: false, option: 1);

        //    while (validation.option > 0)
        //    {
        //        Console.WriteLine("Boas vindas ao EventHorizon Bank!\n");

        //        Console.WriteLine("Selecione uma opção:");
        //        Console.WriteLine("1 - Cadastre-se");
        //        Console.WriteLine("2 - Entrar");
        //        Console.WriteLine("3 - Modo DEV");
        //        Console.WriteLine("0 - Sair");

        //        validation = Validation.Option();

        //        if (validation.result) return validation.option;
        //    }
        //    return 0;
        //}

        //public static int Home(Person owner)
        //{
        //    var validation = (result: false, option: 1);

        //    while (validation.option > 0)
        //    {
        //        Console.WriteLine("Olá, {0}! O que deseja fazer?", owner.Name);
        //        Console.WriteLine("1 - Criar Conta");
        //        Console.WriteLine("2 - Selecionar Conta");
        //        Console.WriteLine("0 - Sair da conta");

        //        validation = Validation.Option();

        //        if (validation.result) return validation.option;
        //    }
        //    return 0;
        //}

        public static int Home()
        {
            var validation = (result: false, option: 1);

            while (!validation.result)
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Entrar na Conta");
                Console.WriteLine("3 - Modo DEV");
                Console.WriteLine("0 - Sair");

                validation = Validation.Option();
            }
            return validation.option;
        }

        public static BankAccount? UserAccounts(Person person, List<BankAccount> bankAccounts)
        {
            List<BankAccount> userAccounts = new List<BankAccount>();
            if (person == null) return null;

            bool isValidInput = false;
            int option = 1;

            while (!isValidInput)
            {
                Console.WriteLine("Olá, {0}! Selecione sua conta: ", person.Name);

                int i = 1;
                foreach (BankAccount account in bankAccounts)
                {
                    if (account.Owner.Cpf == person.Cpf)
                    {
                        Console.WriteLine("\n#{0} - Conta {1}", i, account.Type);
                        Console.Write("Saldo: {0}", account.Balance);
                        Console.Write("\tNumero da conta: {0}\n", account.Number);
                        userAccounts.Add(account);
                        i++;
                    }
                }
                Console.WriteLine("\n0 - Sair");

                isValidInput = int.TryParse(Console.ReadLine(), out option);
                if (option < 0 || option > userAccounts.Count || !isValidInput)
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    isValidInput = false;
                    option = 1;
                    continue;
                }

                if (option != 0)
                {
                    Console.WriteLine("Conta {0} selecionada", userAccounts[option - 1].Type);
                    Console.WriteLine("Número: {0} \t Saldo: {1:n2}", userAccounts[option - 1].Number, userAccounts[option - 1].Balance);
                    return userAccounts[option - 1];
                }
                else Console.Clear();
            }
            return null;
        }

        public static int Transactions(BankAccount account)
        {
            if (account == null)
            {
                Console.WriteLine("Erro: conta não encontrada.");
                return 0;
            }

            var validation = (result: false, option: 1);

            while (!validation.result)
            {
                Console.WriteLine("Selecione a transação que deseja realizar: ");
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Empréstimo");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("0 - Sair");

                validation = Validation.Option();
            }
            return validation.option;
        }

        public static int AccountType()
        {
            var validation = (result: false, option: 1);

            while (!validation.result)
            {
                Console.WriteLine("Selecione o tipo da conta que deseja criar: ");
                Console.WriteLine("1 - Corrente");
                Console.WriteLine("2 - Empresarial");
                Console.WriteLine("3 - Poupança");
                Console.WriteLine("0 - Sair");

                validation = Validation.Option();
            }
            return validation.option;
        }

        public static int DevOptions()
        {
            var validation = (result: false, option: 1);

            while (!validation.result)
            {
                Console.WriteLine("Selecione o que deseja fazer:");
                Console.WriteLine("1 - Listar todas as contas");
                Console.WriteLine("0 - Sair");

                validation = Validation.Option();
            }
            return validation.option;
        }

    }
}
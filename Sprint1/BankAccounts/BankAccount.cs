namespace SistemaBancario.BankAccounts
{
    public abstract class BankAccount
    {
        public decimal Balance { get; protected set; } = 0;
        public decimal LoanLimit { get; protected set; }
        public decimal Number { get; protected set; }
        public Person Owner { get; protected set; }
        public string? Type { get; protected set; }

        abstract public void Withdrawal();

        public void Deposit()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja depositar:");
                validation = Validation.Amount();

                if (validation.result)
                {
                    Balance += validation.amount;

                    Console.Clear();
                    Console.WriteLine("Depósito concluído com sucesso! Saldo atual: {0:n2}", Balance);
                }
            }
        }

        public BankAccount(int number, Person owner)
        {
            Number = number;
            Owner = owner;
        }

        public void WithdrawLoan()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja pegar de empréstimo:");
                validation = Validation.Amount();

                if (validation.result)
                {
                    if (validation.amount > LoanLimit)
                    {
                        Console.Clear();
                        Console.WriteLine("Empréstimo excede o limite! Limite disponível: {0:n2}", LoanLimit);
                        validation.result = false;
                        continue;
                    }

                    LoanLimit -= validation.amount;
                    Balance += validation.amount;

                    Console.Clear();
                    Console.WriteLine("Empréstimo concedido! Saldo atual: {0:n2}", Balance);
                }
            }
        }
    }
}

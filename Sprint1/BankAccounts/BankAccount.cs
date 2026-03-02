namespace SistemaBancario.BankAccounts
{
    public abstract class BankAccount
    {
        public decimal Balance { get; protected set; } = 0;
        public decimal InitalLoanLimit { get; protected set; }
        public decimal CurrentLoanLimit { get; protected set; }
        public decimal WithdrawalTax { get; protected set; }
        public decimal Number { get; protected set; }
        public Person Owner { get; protected set; }
        public string? Type { get; protected set; }

        public BankAccount(int number, Person owner)
        {
            Number = number;
            Owner = owner;
        }

        public void Withdrawal(decimal withdrawalTax) {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja sacar:");
                validation = Validation.Amount();

                if (validation.result)
                {
                    decimal totalAmount = validation.amount * (1 + withdrawalTax);

                    if (totalAmount > Balance)
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo insuficiente! Saldo atual: {0:n2}", Balance);
                        validation.result = false;
                        continue;
                    }

                    Balance -= totalAmount;

                    Console.Clear();
                    Console.WriteLine("Saque concluída com sucesso! Saldo atual: {0:n2}", Balance);
                }
            }
        }
        
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

        public void WithdrawLoan()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja pegar de empréstimo:");
                validation = Validation.Amount();

                if (validation.result)
                {
                    if (validation.amount > CurrentLoanLimit)
                    {
                        Console.Clear();
                        Console.WriteLine("Empréstimo excede o limite! Limite disponível: {0:n2}", CurrentLoanLimit);
                        validation.result = false;
                        continue;
                    }

                    CurrentLoanLimit -= validation.amount;
                    Balance += validation.amount;

                    Console.Clear();
                    Console.WriteLine("Empréstimo concedido! Saldo atual: {0:n2}", Balance);
                }
            }
        }

        public void PayLoan()
        {
            var validation = (result: false, amount: 0m);
            decimal debt = InitalLoanLimit - CurrentLoanLimit;

            while (!validation.result)
            {
                if (debt == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Você não possui dívida de empréstimo.");
                    return;
                }

                if (Balance == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Você não possui dinheiro em conta.");
                    return;
                }

                Console.WriteLine("Valor pendente: {0:n2}", debt);
                Console.WriteLine("Insira o valor que deseja pagar do seu empréstimo: ");
                validation = Validation.Amount();

                if (validation.result)
                {
                    if (validation.amount > Balance)
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo insuficiente! Saldo atual: {0:n2}", Balance);
                        validation.result = false;
                        continue;
                    }

                    if (validation.amount > debt)
                    {
                        Console.Clear();
                        Console.WriteLine("Seu pagamento excede sua dívida! Tente novamente.");
                        validation.result = false;
                        continue;
                    }

                    CurrentLoanLimit += validation.amount;
                    Balance -= validation.amount;

                    if (InitalLoanLimit == CurrentLoanLimit)
                    {
                        Console.Clear();
                        Console.WriteLine("Parabéns! Dívida quitada. Saldo atual: {0:n2}", Balance);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Transação realizada! Saldo atual: {0:n2}", Balance);
                    }
                }
            }
        }

        public void Transfer()
        {
            Console.WriteLine("");
        }
    }
}

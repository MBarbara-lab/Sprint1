using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    public abstract class BankAccount
    {
        public int UserId { get; protected set; }
        public string? OwnerIdentifier { get; protected set; }
        
        public decimal Balance { get; protected set; } = 0;
        public decimal LoanLimit { get; protected set; }
        public decimal LoanDebt { get; protected set; } = 0;
        public decimal WithdrawalTax { get; protected set; }
        public decimal Number { get; protected set; }
        public string? Type { get; protected set; }

        public BankAccount(int number, IAccountOwner owner, User user)
        {
            UserId = user.Id;
            OwnerIdentifier = owner.Identifier;

            Number = number;
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
                    if (validation.amount > (LoanLimit - LoanDebt))                     // Limite - Débito atual resulta no limite atual
                    {
                        Console.Clear();
                        Console.WriteLine("Empréstimo excede o limite! Limite disponível: {0:n2}", LoanDebt);
                        validation.result = false;
                        continue;
                    }

                    LoanDebt += validation.amount;
                    Balance += validation.amount;

                    Console.Clear();
                    Console.WriteLine("Empréstimo concedido! Saldo atual: {0:n2}", Balance);
                }
            }
        }

        public void PayLoan()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                if (LoanDebt == 0)
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

                Console.WriteLine("Valor pendente: {0:n2}", LoanDebt);
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

                    if (validation.amount > LoanDebt)
                    {
                        Console.Clear();
                        Console.WriteLine("Seu pagamento excede sua dívida! Tente novamente.");
                        validation.result = false;
                        continue;
                    }

                    LoanDebt -= validation.amount;
                    Balance -= validation.amount;

                    if (LoanDebt == 0)
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

        public virtual void IncomeForecast()
        {
            Console.WriteLine("Essa conta não possui rendimento.");
        }

        public void Transfer()
        {
            Console.WriteLine("");
        }
    }
}

namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, Person owner, decimal monthlyIncome) : base(number, owner)
        {
            InitalLoanLimit = monthlyIncome * 0.5m;
            CurrentLoanLimit = InitalLoanLimit;
            Type = "Empresarial";
        }

        public override void Withdrawal()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja sacar:");
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

                    Balance -= validation.amount;

                    Console.Clear();
                    Console.WriteLine("Saque concluída com sucesso! Saldo atual: {0:n2}", Balance);
                }
            }
        }
    }
}

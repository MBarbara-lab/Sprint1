using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    class Saving : BankAccount
    {
        public Saving(int number, IAccountOwner owner) : base(number, owner)
        {
            InitalLoanLimit = owner.MonthlyIncome * 0.3m;
            CurrentLoanLimit = InitalLoanLimit;
            Type = "Poupança";
        }

        private decimal Income { get; set; } = 0.005m;

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

        public void IncomeForecast()
        {
            string? userInput;
            bool isValidInput;
            int range;
            decimal totalAmount;

            do
            {
                Console.WriteLine("Defina o alcance da sua previsão, em meses: ");
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out range);

                if (!isValidInput || range < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Alcance inválido!");
                }
            } while (!isValidInput || range < 1);

            totalAmount = Balance;
            for (int i = range; i > 0; i--) totalAmount *= (1 + Income);

            Console.WriteLine("Em {0} meses, seu saldo será de {1:n2}", range, totalAmount);
        }
    }
}

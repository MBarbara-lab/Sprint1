namespace SistemaBancario.BankAccounts
{
    class Saving : BankAccount
    {
        public Saving(int number, Person owner) : base(number, owner)
        {
            LoanLimit = owner.MonthlyIncome * 0.3m;
            Type = "Poupança";
        }

        private decimal Income { get; set; } = 0.005m;

        public override void Withdrawal(decimal value)
        {
            if (value > Balance)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }

            Balance -= value;
            Console.WriteLine("Transação concluída com sucesso! Saldo atual: {0}", Balance);
        }

        public void IncomeForecast()
        {
            string? userInput;
            bool isValidInput;
            int range;
            decimal amount;

            do
            {
                Console.WriteLine("Defina o alcance da sua previsão, em meses: ");
                userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out range);

                if (!isValidInput || range < 1) Console.WriteLine("Alcance inválido!");
            } while (!isValidInput || range < 1);

            amount = Balance;
            for (int i = range; i > 0; i--) amount *= (1 + Income);

            Console.WriteLine("Em {0} meses, seu saldo será de {1:n2}", range, amount);
        }
    }
}

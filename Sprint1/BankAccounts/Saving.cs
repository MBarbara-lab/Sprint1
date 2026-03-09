using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    class Saving : BankAccount
    {
        public Saving(int number, IAccountOwner owner, int userId) : base(number, owner, userId)
        {
            UserId = userId;
            
            LoanLimit = owner.MonthlyIncome * 0.3m;
            Type = "Poupança";
            WithdrawalTax = 0;
        }

        private decimal Income { get; set; } = 0.005m;

        public override void IncomeForecast()
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

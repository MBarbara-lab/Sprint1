namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, Person owner) : base(number, owner)
        {
            InitalLoanLimit = owner.MonthlyIncome * 0.3m;
            CurrentLoanLimit = InitalLoanLimit;
            Type = "Corrente";
        }

        private decimal WithdrawalTax { get; set; } = 0.05m;

        public override void Withdrawal()
        {
            var validation = (result: false, amount: 0m);

            while (!validation.result)
            {
                Console.WriteLine("Insira o valor que deseja sacar:");
                validation = Validation.Amount();

                if (validation.result)
                {
                    decimal totalAmount = validation.amount * (1 + WithdrawalTax);
                    
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
    }
}
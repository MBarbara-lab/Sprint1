namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, Person owner) : base(number, owner)
        {
            LoanLimit = owner.MonthlyIncome * 0.3m;
            Type = "Corrente";
        }

        private decimal WithdrawalTax { get; set; } = 0.05m;

        public override void Withdrawal(decimal value)
        {
            decimal total = (value * WithdrawalTax) + value;
            if (total > Balance || value <= 0)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }

            Balance -= total;
            Console.WriteLine("Transação concluída com sucesso! Saldo atual: {0}", Balance);
        }
    }
}
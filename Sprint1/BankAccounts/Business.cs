namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, Person owner, decimal monthlyIncome) : base(number, owner)
        {
            LoanLimit = monthlyIncome * 0.5m;
            Type = "Empresarial";
        }

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
    }
}

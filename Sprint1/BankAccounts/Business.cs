namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, Person owner, decimal monthlyIncome) : base(number, owner)
        {
            InitalLoanLimit = monthlyIncome * 0.5m;
            CurrentLoanLimit = InitalLoanLimit;
            Type = "Empresarial";
            WithdrawalTax = 0;
        }
    }
}

using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, IAccountOwner owner, decimal monthlyIncome) : base(number, owner)
        {
            InitalLoanLimit = monthlyIncome * 0.5m;
            LoanDebt = InitalLoanLimit;
            Type = "Empresarial";
            WithdrawalTax = 0;
        }
    }
}

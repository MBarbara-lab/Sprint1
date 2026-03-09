using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, IAccountOwner company, int userId) : base(number, company, userId)
        {
            UserId = userId;

            LoanLimit = company.MonthlyIncome * 0.5m;
            Type = "Empresarial";
            WithdrawalTax = 0;
        }
    }
}

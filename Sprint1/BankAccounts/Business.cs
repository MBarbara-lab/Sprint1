using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    class Business : BankAccount
    {
        public Business(int number, IAccountOwner company, User user) : base(number, company, user)
        {
            UserId = user.Id;

            LoanLimit = company.MonthlyIncome * 0.5m;
            Type = "Empresarial";
            WithdrawalTax = 0;
        }
    }
}

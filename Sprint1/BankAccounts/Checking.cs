using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, IAccountOwner owner, User user) : base(number, owner, user)
        {
            UserId = user.Id;

            LoanLimit = owner.MonthlyIncome * 0.3m;
            Type = "Corrente";
            WithdrawalTax = 0.05m;
        }
    }
}
using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, IAccountOwner owner, int userId) : base(number, owner, userId)
        {
            UserId = userId;

            LoanLimit = owner.MonthlyIncome * 0.3m;
            Type = "Corrente";
            WithdrawalTax = 0.05m;
        }
    }
}
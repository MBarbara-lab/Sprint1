using SistemaBancario.Owner;

namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, IAccountOwner owner) : base(number, owner)
        {
            InitalLoanLimit = owner.MonthlyIncome * 0.3m;
            LoanDebt = InitalLoanLimit;
            Type = "Corrente";
            WithdrawalTax = 0.05m;
        }
    }
}
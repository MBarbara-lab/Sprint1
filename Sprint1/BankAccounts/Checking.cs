namespace SistemaBancario.BankAccounts
{
    public class Checking : BankAccount
    {
        public Checking(int number, Person owner) : base(number, owner)
        {
            InitalLoanLimit = owner.MonthlyIncome * 0.3m;
            CurrentLoanLimit = InitalLoanLimit;
            Type = "Corrente";
            WithdrawalTax = 0.05m;
        }
    }
}
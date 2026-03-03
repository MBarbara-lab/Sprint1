namespace SistemaBancario.Owner
{
    public interface IAccountOwner
    {
        public string? Identifier { get; }
        public string? Name { get; }
        public decimal MonthlyIncome { get; }
    }
}

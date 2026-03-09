namespace SistemaBancario.Owner
{
    public interface IAccountOwner
    {
        public int UserId { get; }
        public string? Identifier { get; }
        public string? Name { get; }
        public decimal MonthlyIncome { get; }
        public string Type { get; }
    }
}

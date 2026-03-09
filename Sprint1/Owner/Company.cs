namespace SistemaBancario.Owner
{
    public class Company : IAccountOwner
    {
        public int UserId { get; protected set; }
        public string Identifier { get; protected set; }
        public string? Name { get; private set; }
        public decimal MonthlyIncome { get; protected set; }
        public string Type { get; } = "Pessoa Jurídica";

        public Company(int userId, string cnpj, string? name, decimal revenue)
        {
            UserId = userId;

            Identifier = cnpj;
            MonthlyIncome = revenue;
            Name = name;
        }
    }
}

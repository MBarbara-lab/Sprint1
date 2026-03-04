namespace SistemaBancario.Owner
{
    public class Company : IAccountOwner
    {
        public string Identifier { get; protected set; }
        public string? Name { get; private set; }
        public decimal MonthlyIncome { get; protected set; }

        public Company(string cnpj, string? name, decimal revenue)
        {
            Identifier = cnpj;
            MonthlyIncome = revenue;
            Name = name;
        }
    }
}

namespace SistemaBancario.Owner
{
    public class Person : IAccountOwner
    {
        public string Identifier { get; protected set; }
        public string? Name { get; private set; }
        public decimal MonthlyIncome { get; protected set; }
        public string DateOfBirth { get; private set; }

        public Person(string cpf, string dateOfBirth, decimal salary, string? name)
        {
            DateOfBirth = dateOfBirth;
            Identifier = cpf;
            MonthlyIncome = salary;
            Name = name;
        }
    }
}
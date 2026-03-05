namespace SistemaBancario.Owner
{
    public class Person : IAccountOwner
    {
        public int UserId { get; protected set; }

        public string Identifier { get; protected set; }
        public string? Name { get; private set; }
        public decimal MonthlyIncome { get; protected set; }
        public string DateOfBirth { get; private set; }

        public Person(int userId, string cpf, string dateOfBirth, decimal salary, string? name)
        {
            UserId = userId;

            DateOfBirth = dateOfBirth;
            Identifier = cpf;
            MonthlyIncome = salary;
            Name = name;
        }
    }
}
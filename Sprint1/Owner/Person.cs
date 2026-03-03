namespace SistemaBancario.Owner
{
    public class Person : IAccountOwner
    {
        public string Identifier { get; protected set; }
        public string? Name { get; private set; }
        public decimal MonthlyIncome { get; protected set; }
        public int Age { get; private set; }

        public Person(int age, string cpf, decimal salary, string? name)
        {
            Age = age;
            Identifier = cpf;
            MonthlyIncome = salary;
            Name = name;
        }
    }
}
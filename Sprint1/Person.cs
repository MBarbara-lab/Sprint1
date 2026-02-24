namespace SistemaBancario
{
    public class Person
    {
        public int Age { get; private set; }
        public string? Cpf { get; private set; }
        public decimal MonthlyIncome { get; set; }
        public string? Name { get; private set; }

        public Person(int age, string? cpf, decimal monthlyIncome, string? name)
        {
            Age = age;
            Cpf = cpf;
            MonthlyIncome = monthlyIncome;
            Name = name;
        }
    }
}
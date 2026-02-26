namespace SistemaBancario.BankAccounts
{
    public abstract class BankAccount
    {
        public decimal Balance { get; protected set; } = 0;
        public decimal LoanLimit { get; protected set; }
        public decimal Number { get; protected set; }
        public Person Owner { get; protected set; }
        public string? Type { get; protected set; }

        abstract public void Withdrawal(decimal amount);

        public void Deposit()
        {
            string? userInput;
            bool isValidInput;
            decimal depositValue;

            do
            {
                Console.WriteLine("Insira o valor do depósito:");

                isValidInput = decimal.TryParse(Console.ReadLine(), out depositValue);

                if (!isValidInput || depositValue <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido");
                }
            } while (!isValidInput || depositValue <= 0);

            Balance += depositValue;
            
            Console.Clear();
            Console.WriteLine("Depósito concluído com sucesso! Saldo atual: {0}", Balance);
        }

        public BankAccount(int number, Person owner)
        {
            Number = number;
            Owner = owner;
        }

        public void Loan(decimal value)
        {
            if (value > LoanLimit)
            {
                Console.WriteLine("Empréstimo excede o limite!");
                return;
            }

            LoanLimit -= value;
            Balance += value;
            Console.WriteLine("Empréstimo concedido! Saldo atual: {0}", Balance);
        }
    }
}

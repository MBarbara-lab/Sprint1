using Microsoft.VisualBasic.FileIO;

namespace SistemaBancario
{
    internal class Validation
    {
        static public int Age()
        {
            bool isValidInput;
            int age;

            do
            {
                Console.WriteLine("Insira sua idade:");
                isValidInput = int.TryParse(Console.ReadLine(), out age);

                if (!isValidInput || age <= 0 || age > 130)
                {
                    Console.Clear();
                    Console.WriteLine("Idade inválida");
                    isValidInput = false;
                    continue;
                }

                if (age < 18)
                {
                    Console.Clear();
                    Console.WriteLine("Você não possui idade suficiente para abrir uma conta!");
                    isValidInput = false;
                }

            } while (!isValidInput || age <= 0);

            return age;
        }

        static public string? Cpf()
        {
            bool isValidInput;
            string? cpf;

            do
            {
                isValidInput = true;
                Console.WriteLine("Insira seu CPF: ");
                cpf = Console.ReadLine();
                cpf = cpf?.Trim() ?? "";
                if (cpf == "")
                {
                    Console.Clear();
                    Console.WriteLine("Seu CPF não pode ser nulo! Tente novamente.");
                    continue;
                }

                foreach (char digit in cpf)
                {
                    if (!char.IsDigit(digit))
                    {
                        Console.Clear();
                        Console.WriteLine("Seu CPF deve conter apenas dígitos! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                }

                if (!isValidInput) continue;

                if (cpf.Length != 11)
                {
                    Console.Clear();
                    Console.WriteLine("Seu CPF deve conter 11 dígitos! Tente novamente.");
                    isValidInput = false;
                }
            } while (cpf == "" || !isValidInput);

            return cpf;
        }

        static public decimal MonthlyIncome(string texto)
        {
            bool isValidInput;
            decimal monthlyIncome;

            do
            {
                Console.WriteLine("{0}", texto);
                isValidInput = decimal.TryParse(Console.ReadLine(), out monthlyIncome);

                if (!isValidInput || monthlyIncome <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido");
                    continue;
                }
            } while (!isValidInput || monthlyIncome <= 0);

            return monthlyIncome;
        }
        static public string? Name()
        {
            bool isValidInput;
            string? name;

            do
            {
                isValidInput = true;
                Console.WriteLine("Insira seu nome:");
                name = Console.ReadLine();
                name = name?.Trim() ?? "";
                if (name == "")
                {
                    Console.Clear();
                    Console.WriteLine("Seu nome não pode ser nulo! Tente novamente.");
                    continue;
                }

                foreach (char letter in name)
                {
                    if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                    {
                        Console.Clear();
                        Console.WriteLine("Seu nome deve conter apenas letras não acentuadas e espaços! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                }
            } while (name == "" || !isValidInput);

            return name;
        }

        static public KeyValuePair<bool, int> Option()
        {
            bool isValidInput = int.TryParse(Console.ReadLine(), out int option);
            
            if (!isValidInput)
            {
                Console.Clear();
                Console.WriteLine("Apenas dígitos são aceitos. Tente novamente.");
                option = 1;                            // caso a conversão falhe, TryParse atribui 0 ao segundo parâmetro
            }
            
            if (option < 0)
            {
                Console.Clear();
                Console.WriteLine("Opção inválida!");
                option = 1;
                isValidInput = false;
            }
            return new KeyValuePair<bool, int> (isValidInput, option);
        }
    }
}

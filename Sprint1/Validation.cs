using SistemaBancario.Owner;

namespace SistemaBancario
{
    internal class Validation
    {
        //static public int Age()
        //{
        //    bool isValidInput;
        //    int age;

        //    do
        //    {
        //        Console.WriteLine("Insira sua idade:");
        //        isValidInput = int.TryParse(Console.ReadLine(), out age);

        //        if (!isValidInput || age <= 0 || age > 130)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Idade inválida");
        //            isValidInput = false;
        //            continue;
        //        }

        //        if (age < 18)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Você não possui idade suficiente para abrir uma conta!");
        //            isValidInput = false;
        //        }

        //    } while (!isValidInput || age <= 0);

        //    return age;
        //}

        static public string? Cpf(List<User> users)
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

                foreach (User user in users)
                {
                    if (user.PersonCpf == cpf)
                    {
                        Console.Clear();
                        Console.WriteLine("Esse CPF já está cadastrado.");
                        isValidInput = false;
                    }
                }
            } while (cpf == "" || !isValidInput);

            return cpf;
        }

        static public string DateOfBirth ()
        {
            bool isValidInput;
            string? dateOfBirth;

            do
            {
                isValidInput = true;
                Console.WriteLine("Insira sua data de nascimento: ");
                dateOfBirth = Console.ReadLine();
                dateOfBirth = dateOfBirth?.Trim() ?? "";
                
                if (dateOfBirth == "")
                {
                    Console.Clear();
                    Console.WriteLine("Sua data de nascimento não pode ser nula! Tente novamente.");
                    continue;
                }

                foreach (char digit in dateOfBirth)
                {
                    if (!char.IsDigit(digit))
                    {
                        Console.Clear();
                        Console.WriteLine("Sua data de nascimento deve conter apenas dígitos! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                }

                if (!isValidInput) continue;

                if (dateOfBirth.Length != 8)
                {
                    Console.Clear();
                    Console.WriteLine("Sua data de nascimento deve conter 8 dígitos! Ex.: 15082007");
                    isValidInput = false;
                    continue;
                }

                string yearS, monthS, dayS;
                yearS = dateOfBirth.Substring(dateOfBirth.Length - 4 - 1);          // 4 últimos dígitos + converte p 0-based
                monthS = dateOfBirth.Substring(dateOfBirth.Length - 6 - 1, 2);      // Pega 2 dos 6 últimos dígitos e converte p 0-based
                dayS = dateOfBirth.Substring(0, 2);

                var dateOfBirthI = (
                    year: int.Parse(yearS),
                    month: int.Parse(monthS),
                    day: int.Parse(dayS)
                );

                DateOnly birthDate = new DateOnly();
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                int age = currentDate.Year - birthDate.Year;

                // Se a data atual for menor que o dia do aniversário este ano, subtraímos 1
                if (currentDate < birthDate.AddYears(age)) age--;

                if (age < 18)
                {
                    Console.Clear();
                    Console.WriteLine("Você não possui idade suficiente para abrir uma conta!");
                    isValidInput = false;
                }

            } while (dateOfBirth == "" || !isValidInput);

            return dateOfBirth;
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
        
        static public string? Name(string text)
        {
            bool isValidInput;
            string? name;

            do
            {
                isValidInput = true;
                Console.WriteLine("{0}", text);
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
                        Console.WriteLine("Seu nome deve conter apenas letras e espaços! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                }
            } while (name == "" || !isValidInput);

            return name;
        }

        static public (bool, int) Option()
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

            return (isValidInput, option);
        }

        static public string? Email(string text, List<User> users)
        {
            string? email;
            bool isValidInput, containsAt = false;

            do
            {
                isValidInput = true;

                Console.WriteLine("{0}", text);
                email = Console.ReadLine();
                email = email?.Trim() ?? "";

                if (email == "")
                {
                    Console.Clear();
                    Console.WriteLine("Seu email não pode ser nulo! Tente novamente.");
                    continue;
                }

                int i = 0;
                while (i < email.Length)
                {
                    if (email[i] == '@') containsAt = true;

                    if (!char.IsAsciiLetterOrDigit(email[i]) && (email[i] != '.') && (email[i] != '_') && (email[i] != '@'))
                    {
                        Console.Clear();
                        Console.WriteLine("Seu email deve conter apenas letras não acentuadas, dígitos, \".\" e/ou \"_\"! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                    i++;
                }

                if (!containsAt)
                {
                    Console.Clear();
                    Console.WriteLine("Seu email deve conter um domínio. Ex.: @gmail.com, @hotmail.com, etc.");
                    isValidInput = false;
                    continue;
                }

                foreach (User user in users)
                {
                    if (user.Email == email)
                    {
                        Console.Clear();
                        Console.WriteLine("Esse email já está cadastrado.");
                        isValidInput = false;
                    }
                }

            } while (email == "" || !isValidInput);

            return email;
        }

        static public string? Password(string text)
        {
            bool isValidInput;
            string? password;

            do
            {
                isValidInput = true;
                Console.WriteLine("{0}", text);
                password = Console.ReadLine();
                password = password?.Trim() ?? "";
                
                if (password == "")
                {
                    Console.Clear();
                    Console.WriteLine("Sua senha não pode ser nula! Tente novamente.");
                    continue;
                }

                foreach (char digit in password)
                {
                    if (!char.IsDigit(digit))
                    {
                        Console.Clear();
                        Console.WriteLine("Sua senha deve conter apenas dígitos! Tente novamente.");
                        isValidInput = false;
                        break;
                    }
                }

            } while (password == "" || !isValidInput);

            return password;
        }

        static public (bool, decimal) Amount()
        {
            string? userInput;
            bool isValidInput = true;

            userInput = Console.ReadLine();
            if (userInput != null) userInput = userInput.Trim();

            if (userInput == null || userInput == "")
            {
                Console.Clear();
                Console.WriteLine("O valor não deve ser nulo!");
                return (false, 0);
            }

            userInput = userInput.Replace('.', ',');

            foreach (char digit in userInput)
            {
                int commaQtd = 0;

                if (!char.IsDigit(digit))
                {
                    if (digit == ',' && commaQtd == 0) commaQtd++;
                    else
                    {
                        Console.Clear();
                        isValidInput = false;
                        Console.WriteLine("Por favor, digite um valor válido! Ex: 40,77 ou 23.54");
                        break;
                    }
                }
            }
            
            if (!isValidInput) return (false, 0);

            isValidInput = decimal.TryParse(userInput, out decimal amount);

            if (!isValidInput || amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Valor inválido! Modelo aceito: 13,32 ou 6.88");
                return (false, 0);
            }

            return (isValidInput, amount);
        }
    }
}

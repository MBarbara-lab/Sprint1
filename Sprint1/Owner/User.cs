using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Owner
{
    public class User
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public string? PersonCpf { get; protected set; }
        public List<string>? CompanyCnpj = new List<string>();

        public User (string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

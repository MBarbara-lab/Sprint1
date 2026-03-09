namespace SistemaBancario.Owner
{
    public class User
    {
        public int Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public string? PersonCpf { get; protected set; }
        public List<string>? CompanyCnpj = new List<string>();

        public void setPersonCpf (string? cpf)
        {
            PersonCpf = cpf;
        }

        public User (int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}

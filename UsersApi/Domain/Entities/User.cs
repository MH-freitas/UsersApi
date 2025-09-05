using UsersApi.Domain.Enums;

namespace UsersApi.Domain.Entities
{
    public class User
    {
        private Guid _id = Guid.NewGuid();

        private string? _userName;

        private string? _email;
       
        private ERole _role;

        private string? _password;


        public Guid Id
        {
            get { return _id; }
        }

        public string? UserName
        {
            get { return _userName; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nome de usuario invalido");
                }

                _userName = value;
            }
        }

        public string? Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) && !value.Contains("@"))
                {
                    throw new ArgumentException("Email invalido");
                }

                _email = value;
            }
        }

        public ERole Role
        {
            get { return _role; }
            set 
            {
                if(!Enum.IsDefined(typeof(ERole), value))
                {
                    throw new ArgumentException("Cargo invalido");
                }
                _role = value; 
            }
        }

        public string? Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                {
                    throw new ArgumentException("Senha invalida");
                }

                _password = value;
            }
        }

        public User(){}

        public User(string? userName, string? email, string? password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Id: {Id}, UserName: {UserName}, Email: {Email}";
        }
    }
}

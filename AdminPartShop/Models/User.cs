using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPartShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middle_Name { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool TwoFactor_Authentication { get; set; } = false;

        public User(string surname, string name, string middleName, string email, string password)
        {
            Surname = surname;
            Name = name;
            Middle_Name = middleName;
            Email = email;
            Password = password;
        }

        public User() { }
    }
}

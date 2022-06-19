using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        //public virtual Role Role { get; set; } = null!;
        public int RoleId { get; set; }

        public UserModel(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Password = user.Password;
            RoleId = user.Roleid;
            //Role = user.Role;
        }
    }
}

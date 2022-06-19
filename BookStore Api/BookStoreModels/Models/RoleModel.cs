using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public RoleModel() { }
        public RoleModel(Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreModels.ViewModels;
using BookStoreModels.Models;
namespace BookStoreRepository
{
    public class UserRepository : BaseRepository
    {
        public User Login(LoginModel model)
        {
            return _context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }

        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Roleid = model.Roleid,
            };
            var entry = _context.Users.Add(user);
            _context.SaveChanges();
            return entry.Entity;
        }

        public List<User> GetUsers(int pageIndex, int pageSize, string? keyword)
        {
            var users = _context.Users.AsQueryable();

            if (pageIndex > 0)
            {
                if (string.IsNullOrEmpty(keyword) == false)
                {
                    users = users.Where(w => w.Firstname.ToLower().Contains(keyword) || w.Lastname.ToLower().Contains(keyword));
                }
                var userList = users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                return userList;
            }

            return null;
        }

        public User GetUser(int id)
        {
            if (id > 0)
            {
                return _context.Users.Where(u => u.Id == id).FirstOrDefault();
            }

            return null;
        }
        public bool UpdateUser(User model)
        {
            if (model.Id > 0)
            {
                _context.Update(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUser(User model)
        {
            if (model.Id > 0)
            {
                _context.Remove(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ListResponse<Role> GetRoles()
        {
            var query = _context.Roles;
            int totalRecords = query.Count();
            List<Role> roles = query.ToList();
            return new ListResponse<Role>()
            {
                Records = roles,
                TotalRecords = totalRecords,
            };
        }
    }
}
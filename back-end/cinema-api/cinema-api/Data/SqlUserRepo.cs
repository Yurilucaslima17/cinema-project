using cinema_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_api.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly CinemaContext _context;

        public SqlUserRepo(CinemaContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if(GetUserByEmail(user.Email) != null)
            {
                throw new Exception("User already exists");
            }

            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public User GetUserByEmail(string Email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == Email);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {

        }
    }
}

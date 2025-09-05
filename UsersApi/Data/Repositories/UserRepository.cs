using Microsoft.EntityFrameworkCore.Diagnostics;
using UsersApi.Domain.Entities;
using UsersApi.Domain.Interfaces;

namespace UsersApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(Guid id)
        {
            var user = _context.User.FirstOrDefault(p => p.Id == id);

            if (user == null)
            {
                throw new ArgumentException("Usuario nao encontrado");
            }

            return user;
        }

        public User GetByUserName(string userName)
        {
            var user = _context.User.FirstOrDefault(p => p.UserName == userName);
            if (user == null)
            {
                throw new ArgumentException("Usuario nao encontrado");
            }
            return user;
        }

        public User Create(string userName, string email, string password)
        {
            var user = _context.User.FirstOrDefault(p => p.UserName == userName);
            if (user != null)
            {
                throw new ArgumentException("Usuario ja existe");
            }

            var newUser = new User
            {
                UserName = userName,
                Email = email,
                Password = password
            };

            _context.User.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User Update(string userName, string email, string password)
        {
            var user = _context.User.FirstOrDefault(p => p.UserName == userName);
            if (user == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            var UpdateUser = new User
            {
                UserName = userName,
                Email = email,
                Password = password
            };

            _context.User.Update(UpdateUser);
            _context.SaveChanges();
            return UpdateUser;
        }

        public void Delete(Guid id)
        {
            var user = _context.User.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }
            _context.User.Remove(user);
            _context.SaveChanges();
        }
    }
}

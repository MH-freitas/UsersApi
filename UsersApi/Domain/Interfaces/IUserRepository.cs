using UsersApi.Domain.Entities;
namespace UsersApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();

        public User GetById(Guid id);

        public User GetByUserName(string userName);

        public User Create(string userName, string email, string password);

        public User Update(string userName, string email, string password);

        public void Delete(Guid id);
    }
}

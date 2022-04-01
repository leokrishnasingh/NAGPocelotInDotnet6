
using AccountAPI.Models;

namespace AccountAPI.Repositories
{
    public class AccountRepository
    {
        private readonly List<User> users;

        public AccountRepository()
        {
            users = new List<User>
            {
                new User { Id = 1, Name = "Sample User", UserName = "SampleUser", Email = "SampleUser@test.com" },
                new User { Id = 2, Name = "User1", UserName = "User1", Email = "User1@test.com" },
                new User { Id = 3, Name = "User2", UserName = "User2", Email = "User1@test.com" },
            };
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User GetUsersById(int id)
        {
            return users.FirstOrDefault(user => user.Id==id);
        }
    }
}
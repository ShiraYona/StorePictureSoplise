



using Entities;

namespace servies
{
    public interface IUserServies
    {
        Task<int> check(string Code);
        Task<User> getUserByUserNameAndPassword(string userName, string password);
        Task<User> CreateNewUser(User user);
        Task Put(int id, User userToUpdate);
    }
}
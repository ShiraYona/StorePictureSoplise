
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Repositories
{
    public class UserRepository :IUserRepository
    {
     private readonly StoreDataBase1Context _dbContext;
     public UserRepository(StoreDataBase1Context _Dbcontext)
     {
        _dbContext = _Dbcontext;
     }
        public  async Task<User> getUserByUserNameAndPassword(string userName, string password)
        {

            return await _dbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();

        }
        public  async Task<User> CreateNewUser(User user)
        {

           await _dbContext.AddAsync(user);

            await _dbContext.SaveChangesAsync();
            return user;

          

        }
        public async Task Put(int id, User userToUpdate)
        {
              _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}

using Entities;
using Repositories;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;

namespace servies
{
    public class UserServies : IUserServies
    {
        IUserRepository _userRepository;
        public UserServies(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public  async Task<User> getUserByUserNameAndPassword(string userName, string password)
        {
            return await _userRepository.getUserByUserNameAndPassword(userName, password);
        }

        public async Task<User> CreateNewUser(User user)
        {
            
            return await _userRepository.CreateNewUser(user);
        }

        public async Task Put(int id, User userToUpdate)
        {
           await  _userRepository.Put(id, userToUpdate);

        }

        public async Task<int> check(string Code)
        {
            var result = Zxcvbn.Core.EvaluatePassword(Code);
            return result.Score;
        }
    }

}

using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Interface
{
    public interface IUserRepository
    {
        Task<User> Login(string username, string password);
        Task<User> GetMyTokens(int userId);
    }
}

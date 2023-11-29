using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Interface;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly BookBorrowDbContext context;

        public UserRepository(BookBorrowDbContext context)
        {
            this.context = context;
        }

        //get my tokens
        public async Task<User> GetMyTokens(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserId==userId);
            if (user == null)
            {
                return null;
            }

            return user;
        }


        //login user
        public async Task<User> Login(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            if (user.Password != password)
            {
                return null;
            }

            return user;
        }
    }
}

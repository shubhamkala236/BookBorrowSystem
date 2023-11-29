using DataAccessLayer.Context;
using SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookBorrowDbContext context;

        public UnitOfWork(BookBorrowDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => new UserRepository(context);
        public IBookRepository BookRepository => new BookRepository(context);

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}

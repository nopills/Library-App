using Library_App.Models;
using Library_App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services
{
    public class UserService: IUserService
    {
        public DatabaseContext _db { get; }
        public UserService(DatabaseContext db)
        {
            _db = db;
        }


        public async Task AddReadedBook(Book book, User user)
        {
             _db.Books.Include(x => x.ReadedByUser).FirstOrDefault(x => x.Id == book.Id).ReadedByUser.Add(user);
      
            await _db.SaveChangesAsync();
        }
    }
}

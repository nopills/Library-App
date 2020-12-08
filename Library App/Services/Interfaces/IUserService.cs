using Library_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services.Interfaces
{
    public interface IUserService
    {
        Task AddReadedBook(Book book, User user);
    }
}

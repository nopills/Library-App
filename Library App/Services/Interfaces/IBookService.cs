using Library_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Library_App.Models.ViewModels.BookViewModel;

namespace Library_App.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookList> GetBookList(User user);
        Task<BookList> GetReadedBooks(User user);
    }
}

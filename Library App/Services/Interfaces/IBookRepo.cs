﻿using Library_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services.Interfaces
{
    public interface IBookRepo
    {
        Task AddBook(Book book);
        Task AddListBooks(ICollection<Book> books);
        

        Book GetBookById(int id);
        IQueryable<Book> GetBookByName(string name);
        Task<ICollection<Book>> GetAllBooks();
        Task<ICollection<Book>> GetReadedBookList(User user);

        Task RemoveBookFromReaded(Book book);
    }
}
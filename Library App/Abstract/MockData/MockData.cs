using Library_App.Models;
using Library_App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Services.MockData
{
    public class MockData
    {
        public IBookRepo _bookRepo;
        public MockData(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

      
        public async Task CreateMockData()
        {           
            await _bookRepo.AddListBooks(new List<Book> {
            new Book { Name = "Код", Author = "Чарльз Петцольд" },
            new Book { Name = "Sapiens", Author = "Юваль Ной Харари" },
            new Book { Name = "CLR via C#", Author = "Джефри Рихтер" },
            new Book { Name = "C# для профессионалов", Author = "Эндрю Троелсен" },
            new Book { Name = "Защита от тёмных искусств", Author = "Александр Панчин" },
            new Book { Name = "Как завоёвывать друзей", Author = "Дейл Карнеги" },
            }); ;
        }
    }
}

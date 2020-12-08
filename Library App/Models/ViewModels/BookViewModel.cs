using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models.ViewModels
{
    public class BookViewModel
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public class BookList
        {
            public List<BookViewModel> books = new List<BookViewModel>();
        }
    }
}

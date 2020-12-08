using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public ICollection<User> ReadedByUser { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Models
{
    public class User: IdentityUser
    {
        public ICollection<Book> Books { get; set; }
    }
}

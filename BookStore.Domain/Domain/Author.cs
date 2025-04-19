using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

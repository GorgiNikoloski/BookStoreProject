using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string? OwnerId { get; set; }
        public User? Owner { get; set; }
        public ICollection<BookPublisherInOrder> BooksInOrder { get; set; }
    }
}

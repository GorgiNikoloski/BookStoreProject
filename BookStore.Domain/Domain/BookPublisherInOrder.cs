using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
    public class BookPublisherInOrder : BaseEntity
    {
        public Guid OrderedBookId { get; set; }
        public BookPublisher? OrderedBook { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
    }
}

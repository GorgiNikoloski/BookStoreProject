using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public ICollection<BookPublisher> BookPublishers { get; set;  } = new List<BookPublisher>();
    }
}

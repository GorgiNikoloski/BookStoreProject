using BookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IBookPublisherService
    {
        List<BookPublisher> GetAll();
        BookPublisher GetDetails(Guid? id);
        void CreateNew(BookPublisher p);
        void UpdateExisting(BookPublisher p);
        void Delete(Guid id);
    }
}

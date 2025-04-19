using BookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetDetails(Guid? id);
        void CreateNew(Book p);
        void UpdateExisting(Book p);
        void Delete(Guid id);
    }
}

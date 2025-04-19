using BookStore.Domain.Domain;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void CreateNew(Book p)
        {
            _repository.Insert(p);
        }

        public void Delete(Guid id)
        {
            var book = _repository.Get(id);
            _repository.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Book GetDetails(Guid? id)
        {
            var book = _repository.Get(id);
            return book;
        }

        public void UpdateExisting(Book p)
        {
            _repository.Update(p);
        }
    }
}

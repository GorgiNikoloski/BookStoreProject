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
    public class BookPublisherService : IBookPublisherService
    {
        private readonly IRepository<BookPublisher> _repository;

        public BookPublisherService(IRepository<BookPublisher> repository)
        {
            _repository = repository;
        }

        public void CreateNew(BookPublisher p)
        {
            _repository.Insert(p);
        }

        public void Delete(Guid id)
        {
            var bookP= _repository.Get(id);
            _repository.Delete(bookP);
        }

        public List<BookPublisher> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public BookPublisher GetDetails(Guid? id)
        {
            return _repository.Get(id);
          
        }

        public void UpdateExisting(BookPublisher p)
        {
            _repository.Update(p);
        }
    }
}

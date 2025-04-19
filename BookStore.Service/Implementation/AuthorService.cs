using BookStore.Domain.Domain;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;


namespace BookStore.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public void CreateNew(Author p)
        {
            _repository.Insert(p);
        }

        public void Delete(Guid id)
        {
            var author = _repository.Get(id);
            _repository.Delete(author);
        }

        public List<Author> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Author GetDetails(Guid? id)
        {
            var author = _repository.Get(id);
            return author;
        }

        public void UpdateExisting(Author p)
        {
            _repository.Update(p);
        }
    }
}

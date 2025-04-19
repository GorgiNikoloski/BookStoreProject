using BookStore.Domain.Domain;
using BookStore.Repository.Interface;
using BookStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(BookPublisher)))
            {
                return entities
                       .Include("Book")
                       .Include("Publisher")
                      .AsEnumerable();
            }
            if (typeof(T).IsAssignableFrom(typeof(Book)))
            {
                return entities
                       .Include("Author")
                      .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                       .Include("BooksInOrder")
                       .Include("Owner")
                       .Include("BooksInOrder.OrderedBook")
                      .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(ShoppingCart)))
            {
                return entities
                       .Include("BooksInCart")
                       .Include("Owner")
                       .Include("BooksInCart.BookPublisher")
                       .Include("BooksInCart.BookPublisher.Book")
                       .AsEnumerable();
            }
            else
            return entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
            if (typeof(T).IsAssignableFrom(typeof(Author)))
            {
                return entities
                       .Include("Books")
                       .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(Book)))
            {
                return entities
                       .Include("Author")
                       .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(BookPublisher)))
            {
                return entities
                       .Include("Book")
                       .Include("Publisher")
                       .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(Order)))
            {
                return entities
                       .Include("BooksInOrder")
                       .Include("Owner")
                       .Include("BooksInOrder.OrderedBook")
                       .Include("BooksInOrder.OrderedBook.Book")
                       .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(ShoppingCart)))
            {
                return entities
                       .Include("BooksInCart")
                       .Include("Owner")
                       .Include("BooksInCart.BookPublisher")
                       .Include("BooksInCart.BookPublisher.Book")
                       .First(s => s.Id == id);
            }
            else
            {
                return entities.SingleOrDefault(s => s.Id == id);
            }
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }
    }
}

using BookStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IPublisherService
    {
        List<Publisher> GetAll();
        Publisher GetDetails(Guid? id);
        void CreateNew(Publisher p);
        void UpdateExisting(Publisher p);
        void Delete(Guid id);
    }
}

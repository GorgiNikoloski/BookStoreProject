using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public User? Owner { get; set; }

        public ICollection<BookPublisherInCart> BookInCart { get; set; }
    }
}

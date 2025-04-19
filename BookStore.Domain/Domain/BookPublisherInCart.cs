namespace BookStore.Domain.Domain
{
    public class BookPublisherInCart : BaseEntity
    {
        public Guid BookPublisherId { get; set; }
        public BookPublisher? BookPublisher { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}

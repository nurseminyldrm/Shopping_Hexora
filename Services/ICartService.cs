


namespace Shopping_Hexora.Services
{
    public interface ICartService
    {
        Task<ShoppingCart> GetCart(string userId);
        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<bool>  DoCheckout(CheckoutModel model);
    }
}

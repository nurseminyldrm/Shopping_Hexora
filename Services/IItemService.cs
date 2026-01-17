using Shopping_Hexora.Models;
using Shopping_Hexora.ViewModels;

namespace Shopping_Hexora.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetItemsByUserId();
        Item? GetById(int id);
        Task Create (CreateItemVM vmItem , Stock st);
        Task<Item?> Update (EditItemVM vmItem);
        bool Delete (int id);
        
    }
}

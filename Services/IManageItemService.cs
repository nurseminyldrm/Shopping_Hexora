namespace Shopping_Hexora.Services
{
    public interface IManageItemService
    {
        Task<IEnumerable<Item>> GetAllItems();
        Task ToggleApprovementStatus(int ItemId);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}

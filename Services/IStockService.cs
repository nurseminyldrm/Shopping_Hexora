namespace Shopping_Hexora.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockDisplayModel>> GetStocks( );
        Task<Stock?> GetStockByItemId(int itemId);
        Task ManageStock(StockDTO stockToManage);
    }
}

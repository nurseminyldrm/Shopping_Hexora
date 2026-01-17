using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shopping_Hexora.Services
{
    public interface ICategoryService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}

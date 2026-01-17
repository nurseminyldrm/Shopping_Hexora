using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping_Hexora.Data;

namespace Shopping_Hexora.Services
{
    
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _dbContext.categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
               .OrderBy(c => c.Text)
               .AsNoTracking()
               .ToList();
        }
    }
}

using MyStore.Context;

namespace MyStore.Controllers;

public class CategoryController(AppDbContext _dbContext) : Controller
{
    public IActionResult Index()
    {
        List<CategoryVM> categories = _dbContext.Categories.Select(item =>
            new CategoryVM
            {
                CategoryId = item.CategoryId,
                Name = item.Name
            }
        ).ToList();
        return View(categories);
    }
}

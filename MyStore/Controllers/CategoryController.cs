using MyStore.Context;

namespace MyStore.Controllers;

public class CategoryController(AppDbContext _dbContext) : Controller
{
    public IActionResult Index()
    {
        List<Category> categories = _dbContext.Categories.ToList();
        return View(categories);
    }
}

using MyStore.Context;
using MyStore.Services;

namespace MyStore.Controllers;

public class CategoryController(CategoryService _categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        List<CategoryVM> categories = (List<CategoryVM>)await _categoryService.GetAllAsync();
        return View(categories);
    }
}

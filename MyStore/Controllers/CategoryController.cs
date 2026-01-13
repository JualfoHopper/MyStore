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
    //Se crea la vista para agregar
    [HttpGet]
    public async Task<IActionResult> AddEdit()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddEdit(CategoryVM categoryVM)
    {
       await _categoryService.AddAsync(categoryVM);
        ViewBag.message = "Category added successfully";
        return View();
    }
}

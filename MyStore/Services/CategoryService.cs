using MyStore.Repositories;
using MyStore.Models;

namespace MyStore.Services;

public class CategoryService(GenericRepository<Entities.Category> _categoryRepository)
{
    public async Task<IEnumerable<CategoryVM>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        List<CategoryVM> categoriesVM = categories.Select(item =>
        new CategoryVM
        {
            CategoryId = item.CategoryId,
            Name = item.Name
        }).ToList();
        return categoriesVM;
    }
}

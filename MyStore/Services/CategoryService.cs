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
    public async Task AddAsync(CategoryVM categoryVM)
    {
        Entities.Category category = new Entities.Category
        {
            Name = categoryVM.Name
        };
        await _categoryRepository.AddEntity(category);
    }
}

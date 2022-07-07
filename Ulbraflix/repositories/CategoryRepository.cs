using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class CategoryRepository : ICategoryRepository
{
    private DataContext _dataContext;

    public CategoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public Category GetById(int id)
    {
        return _dataContext.Category.SingleOrDefault(
            category => category.id = id);
    }

    public List<Category> GetAll()
    {
        return _dataContext.Category.ToList();
    }

    public void Insert(Category entity)
    {
        _dataContext.Category.Add(entity);
    }

    public void Update(Category entity)
    {
        _dataContext.Category.Update(entity);
    }

    public void Delete(int id)
    {
        Category category = GetById(id);
        _dataContext.Category.Remove(category);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _dataContext
            .DbSetCategory
            .FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task<IList<Category>> GetAllByIdAsync()
    {
        return await _dataContext
            .DbSetCategory
            .ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using Ulbraflix.data.context;
using Ulbraflix.domain.entities;

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
        return _dataContext.Category.SingleOrDefault(category => category.Id == id);
    }

    public List<Category> GetAll()
    {
        return _dataContext.Category.ToList();
    }

    public bool Insert(Category entity)
    {
        _dataContext.Category.Add(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Update(Category entity)
    {
        _dataContext.Category.Update(entity);
        return (_dataContext.SaveChanges()) > 0;
    }

    public bool Delete(Category category)
    {
        _dataContext.Category.Remove(category);
        return (_dataContext.SaveChanges()) > 0;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _dataContext
            .Category
            .FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        return await _dataContext
            .Category
            .ToListAsync();
    }
}
using Ulbraflix.domain.entities;
using Ulbraflix.domain.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public bool Insert(Category entity)
    {
        return _categoryRepository.Insert(entity);
    }

    public bool Update(Category entity)
    {
        return _categoryRepository.Update(entity);
    }

    public bool Delete(int id)
    {
        Category category = GetById(id);
        return _categoryRepository.Delete(category);
    }
    
    public Category GetById(int id)
    {
        return _categoryRepository.GetById(id);
    }

    public List<Category> GetAll()
    {
        return _categoryRepository.GetAll();
    }
}
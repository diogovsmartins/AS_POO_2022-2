using Ulbraflix.entities;
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

    public void Insert(Category entity)
    {
        _categoryRepository.Insert(entity);
    }

    public void Update(Category entity)
    {
        _categoryRepository.Update(entity);
    }

    public void Delete(int id)
    {
        _categoryRepository.Delete(id);
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
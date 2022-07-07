using System.Collections;
using Ulbraflix.entities;
using Ulbraflix.repositories.interfaces;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        this._categoryRepository = categoryRepository;
        this._unitOfWork = unitOfWork;
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
}
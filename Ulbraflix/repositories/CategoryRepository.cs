using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class CategoryRepository : ICategoryRepository
{
    private DataContext _dataContext;

    public CategoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public CategoryRepository GetById(int id)
    {
        return _dataContext.CategoryRepository.SingleOrDefault(
            CategoryRepository => CategoryRepository.id = id);
    }

    public List<CategoryRepository> GetAll()
    {
        return _dataContext.CategoryRepository.ToList();
    }

    public void Insert(CategoryRepository entity)
    {
        _dataContext.CategoryRepository.Add(entity);
    }

    public void Update(CategoryRepository entity)
    {
        _dataContext.CategoryRepository.Update(entity);
    }

    public void Delete(int id)
    {
        CategoryRepository CategoryRepository = GetById(id);
        _dataContext.CategoryRepository.Remove(CategoryRepository);
    }
}
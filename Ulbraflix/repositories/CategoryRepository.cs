using Ulbraflix.repositories.interfaces;

namespace Ulbraflix.repositories;

public class Category : ICategoryRepository
{
    private DataContext _dataContext;

    public Category(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public Category GetById(int id)
    {
        return _dataContext.Category.SingleOrDefault(
            Category => Category.id = id);
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
        Category Category = GetById(id);
        _dataContext.Category.Remove(Category);
    }
}
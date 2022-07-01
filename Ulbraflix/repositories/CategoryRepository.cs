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

    public bool Insert(Category entity)
    {
        bool success=true;
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty)) throw new ArgumentException();
        try
        {
            _dataContext.Category.Add(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Update(Category entity)
    {
        bool success=true;
        if (entity.Equals(null) ||
            entity.Name.Equals(String.Empty)) throw new ArgumentException();
        try
        {
            _dataContext.Category.Update(entity);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }

    public bool Delete(int id)
    {
        bool success=true;
        try
        {
            Category category = GetById(id);
            _dataContext.Category.Remove(category);
            _dataContext.SaveChanges();
            return success;
        }
        catch (Exception e )
        {
            success = false;
        }
        return success;
    }
}
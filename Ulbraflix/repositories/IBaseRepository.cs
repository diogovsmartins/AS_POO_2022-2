namespace Ulbraflix.repositories;

public interface IBaseRepository <Entity> where Entity : class
{
    Entity GetById(int id);
    List<Entity> GetAll();
    bool Insert(Entity entity);
    bool Update(Entity entity);
    bool Delete(int id);    
}
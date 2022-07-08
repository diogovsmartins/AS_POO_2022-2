namespace Ulbraflix.services.interfaces;

public interface IBaseService<Entity> where Entity : class
{
    Entity GetById(int id);

    List<Entity> GetAll();
    bool Insert(Entity entity);
    bool Update(Entity entity);
    bool Delete(int id);
}
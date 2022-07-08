namespace Ulbraflix.services.interfaces;

public interface IBaseService<Entity> where Entity : class
{
    Entity GetById(int id);

    List<Entity> GetAll();
    void Insert(Entity entity);
    void Update(Entity entity, int id);
    void Delete(int id);
}
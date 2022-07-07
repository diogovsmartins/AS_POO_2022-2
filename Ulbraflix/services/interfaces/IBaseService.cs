namespace Ulbraflix.services.interfaces;

public interface IBaseService<Entity> where Entity : class
{
    Task<Entity> GetByIdAsync(int id);
    Task<IList<Entity>> GetAllAsync();
    void Insert(Entity entity);
    void Update(Entity entity);
    void Delete(int id);
}
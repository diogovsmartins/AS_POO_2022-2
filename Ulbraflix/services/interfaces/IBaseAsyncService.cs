namespace Ulbraflix.services.interfaces;

public interface IBaseAsyncService<Entity> where Entity : class
{
    Task<Entity> GetByIdAsync(int id);
    Task<IList<Entity>> GetAllAsync();
}
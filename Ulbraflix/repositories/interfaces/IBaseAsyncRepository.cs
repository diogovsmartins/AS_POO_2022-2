using System.Collections;

namespace Ulbraflix.repositories.interfaces;

public interface IBaseAsyncRepository <Entity> where Entity : class
{
    Task<Entity> GetByIdAsync(int id);
    Task<IList<Entity>> GetAllAsync();
}
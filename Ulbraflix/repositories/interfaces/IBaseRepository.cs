using System.Collections.Generic;

namespace Ulbraflix.repositories.interfaces;

public interface IBaseRepository <Entity> where Entity : class
{
    Entity GetById(int id);
    List<Entity> GetAll();
    bool Insert(Entity entity);
    bool Update(Entity entity);
    bool Delete(Entity entity);    
}
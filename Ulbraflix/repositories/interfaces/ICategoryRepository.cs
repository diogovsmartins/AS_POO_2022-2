using System.Collections;
using Ulbraflix.Controllers;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface ICategoryRepository : IBaseRepository<Category>, IBaseAsyncRepository<Category>
{
}
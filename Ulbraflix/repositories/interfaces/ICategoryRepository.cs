using System.Collections;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.repositories.interfaces;

public interface ICategoryRepository : IBaseRepository<Category>, IBaseAsyncRepository<Category>
{
}
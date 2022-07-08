using System.Collections;
using Ulbraflix.domain.entities;
using Ulbraflix.entities;

namespace Ulbraflix.services.interfaces;

public interface ICategoryService : IBaseService<Category>, IBaseAsyncService<Category>
{
}
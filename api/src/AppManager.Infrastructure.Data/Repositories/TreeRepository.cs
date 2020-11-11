using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppManager.Infrastructure.Data.Repositories
{
  public class TreeRepository : RepositoryBase<Tree>, ITreeRepository
  {
    public TreeRepository(DataContext context) : base(context) { }

    public IEnumerable<Tree> FindAllWithSpecie()
    {
      return DbSet.Include(x => x.Specie).AsEnumerable();
    }
  }
}

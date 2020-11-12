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

    public IEnumerable<Tree> FindAllWithIncludes(string specieName, string groupName)
    {
      return DbSet.Include(x => x.Specie)
                .Include(X=>X.Group)
                .Where(x=> (string.IsNullOrEmpty(specieName) || x.Specie.PopularName.Contains(specieName) || x.Specie.ScientificName.Contains(specieName))
                && (string.IsNullOrEmpty(groupName) || x.Group.Name.Contains(groupName))
                )
                .AsEnumerable();
    }
  }
}

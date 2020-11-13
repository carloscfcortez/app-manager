using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace AppManager.Infrastructure.Data.Repositories
{
  public class HarvestRepository : RepositoryBase<Harvest>, IHarvestRepository
  {
    public HarvestRepository(DataContext context) : base(context) { }

    public IEnumerable<Harvest> FindAllWithIncludesAndFilters(int treeId = 0, int groupId = 0, int specieId = 0, DateTime? periodStart = null, DateTime? periodEnd = null)
    {
      return DbSet
      .Include(x => x.Tree)
      .Include(x => x.Tree.Specie)
      .Include(x => x.Tree.Group)
          .Where(x =>
              (treeId == 0 || x.TreeId == treeId)
              && (groupId == 0 || x.Tree.GroupId == groupId)
              && (specieId == 0 || x.Tree.SpecieId == specieId)
              && (periodStart == null || x.HarvestDate >= periodStart)
              && (periodEnd == null || x.HarvestDate <= periodEnd)
          )
         .AsEnumerable();
    }
  }
}

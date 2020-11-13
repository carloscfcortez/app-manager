using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces
{
  public interface IHarvestRepository : IRepositoryBase<Harvest>
  {
    IEnumerable<Harvest> FindAllWithIncludesAndFilters(int treeId = 0, int groupId = 0, int specieId = 0, DateTime? periodStart = null, DateTime? periodEnd = null);
  }
}

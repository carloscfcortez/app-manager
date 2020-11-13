using System;
using System.Collections.Generic;
using AppManager.Domain.Entities;

namespace AppManager.Application.Interfaces
{
  public interface IHarvestAppService : IAppServiceBase<Harvest>
  {
    IEnumerable<Harvest> FindAllWithIncludesAndFilters(int treeId = 0, int groupId = 0, int specieId = 0, DateTime? periodStart = null, DateTime? periodEnd = null);
  }
}

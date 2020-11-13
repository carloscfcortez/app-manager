using System;
using System.Collections.Generic;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Domain.Services
{
  public class HarvestService : ServiceBase<Harvest>, IHarvestService
  {
    private readonly IHarvestRepository _repository;
    public HarvestService(IHarvestRepository repository) : base(repository)
    {
      _repository = repository;
    }

    public IEnumerable<Harvest> FindAllWithIncludesAndFilters(int treeId = 0, int groupId = 0, int specieId = 0, DateTime? periodStart = null, DateTime? periodEnd = null)
    {
      return _repository.FindAllWithIncludesAndFilters(treeId, groupId, specieId, periodStart, periodEnd);
    }
  }
}

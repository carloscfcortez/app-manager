using System;
using System.Collections.Generic;
using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Application.Services
{
  public class HarvestAppService : AppServiceBase<Harvest>, IHarvestAppService
  {
    private readonly IHarvestService _appService;

    public HarvestAppService(IHarvestService service) : base(service)
    {
      _appService = service;
    }

    public IEnumerable<Harvest> FindAllWithIncludesAndFilters(int treeId = 0, int groupId = 0, int specieId = 0, DateTime? periodStart = null, DateTime? periodEnd = null)
    {
      return _appService.FindAllWithIncludesAndFilters(treeId, groupId, specieId, periodStart, periodEnd);
    }
  }
}

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
  }
}

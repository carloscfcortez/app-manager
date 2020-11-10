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
    }
}

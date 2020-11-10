using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Application.Services
{
    public class SpecieAppService : AppServiceBase<Specie>, ISpecieAppService
    {
        private readonly ISpecieService _appService;

        public SpecieAppService(ISpecieService service) : base(service)
        {
            _appService = service;
        }
    }
}

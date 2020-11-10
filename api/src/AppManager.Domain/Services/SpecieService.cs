using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Domain.Services
{
  public class SpecieService : ServiceBase<Specie>, ISpecieService
  {
    private readonly ISpecieRepository _repository;
    public SpecieService(ISpecieRepository repository) : base(repository)
    {
      _repository = repository;
    }
  }
}

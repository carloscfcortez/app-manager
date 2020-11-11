using System.Collections.Generic;
using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Application.Services
{
  public class TreeAppService : AppServiceBase<Tree>, ITreeAppService
  {
    private readonly ITreeService _appService;

    public TreeAppService(ITreeService service) : base(service)
    {
      _appService = service;
    }

    public IEnumerable<Tree> FindAllWithSpecie()
    {
      return _appService.FindAllWithSpecie();
    }
  }
}

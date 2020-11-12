using System.Collections.Generic;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Domain.Services
{
  public class TreeService : ServiceBase<Tree>, ITreeService
  {
    private readonly ITreeRepository _repository;
    public TreeService(ITreeRepository repository) : base(repository)
    {
      _repository = repository;
    }

    public IEnumerable<Tree> FindAllWithIncludes(string specieName, string groupName)
    {
      return _repository.FindAllWithIncludes(specieName, groupName);
    }
  }
}

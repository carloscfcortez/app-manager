using System.Collections.Generic;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces.Services
{
  public interface ITreeService : IServiceBase<Tree>
  {
    IEnumerable<Tree> FindAllWithIncludes(string specieName, string groupName);
  }
}

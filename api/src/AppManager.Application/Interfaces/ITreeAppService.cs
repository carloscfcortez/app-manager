using System.Collections.Generic;
using AppManager.Domain.Entities;

namespace AppManager.Application.Interfaces
{
  public interface ITreeAppService : IAppServiceBase<Tree>
  {
    IEnumerable<Tree> FindAllWithIncludes(string specieName, string groupName);
  }
}

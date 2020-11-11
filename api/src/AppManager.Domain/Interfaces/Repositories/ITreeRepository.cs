using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces
{
  public interface ITreeRepository : IRepositoryBase<Tree>
  {
    IEnumerable<Tree> FindAllWithSpecie();
  }
}

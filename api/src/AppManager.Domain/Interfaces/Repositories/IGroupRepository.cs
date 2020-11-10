using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        IEnumerable<Group> FindFilterByNameOrId(string filter);
    }
}

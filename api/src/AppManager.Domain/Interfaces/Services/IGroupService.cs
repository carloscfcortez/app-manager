using System.Collections.Generic;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces.Services
{
    public interface IGroupService : IServiceBase<Group>
    {
        IEnumerable<Group> FindFilterByNameOrId(string filter);
    }
}

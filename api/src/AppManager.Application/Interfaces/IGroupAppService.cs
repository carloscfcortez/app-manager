using System.Collections.Generic;
using AppManager.Domain.Entities;

namespace AppManager.Application.Interfaces
{
    public interface IGroupAppService : IAppServiceBase<Group>
    {
        IEnumerable<Group> FindFilterByNameOrId(string filter);
    }
}

using AppManager.Domain.Entities;

namespace AppManager.Application.Interfaces
{
    public interface IGroupAppService : IAppServiceBase<Group>
    {
        Group FindByName(string name);
    }
}

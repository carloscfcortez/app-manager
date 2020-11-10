using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces.Services
{
    public interface IGroupService : IServiceBase<Group>
    {
        Group FindByName(string name);
    }
}

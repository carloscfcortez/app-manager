using System.Threading.Tasks;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        Group FindByName(string name);
    }
}

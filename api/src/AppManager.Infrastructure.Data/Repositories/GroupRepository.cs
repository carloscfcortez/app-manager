using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;

namespace AppManager.Infrastructure.Data.Repositories
{
  public class GroupRepository : RepositoryBase<Group>, IGroupRepository
  {

        public Group FindByName(string name)
        {
            return this.DbSet.Where(x => x.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
        }
    }
}

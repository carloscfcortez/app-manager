using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;
using System.Collections.Generic;

namespace AppManager.Infrastructure.Data.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        private readonly DataContext _context;
        public GroupRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Group> FindFilterByNameOrId(string filter)
        {
            return DbSet
                .Where(x => x.Name.ToLower().Contains(filter.ToLower()) || x.Id.ToString().Contains(filter))
                .AsEnumerable();
        }
    }
}

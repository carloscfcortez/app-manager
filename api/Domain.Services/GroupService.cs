
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Entities;

namespace Domain.Services
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public readonly IGroupRepository _repository;
        public GroupService(IGroupRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

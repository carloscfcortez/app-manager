using System.Collections.Generic;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Domain.Services
{
    public class GroupService : ServiceBase<Group>, IGroupService
    {
        private readonly IGroupRepository _repository;
        public GroupService(IGroupRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Group> FindFilterByNameOrId(string filter)
        {
           return _repository.FindFilterByNameOrId(filter);
        }
    }
}

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

        public Group FindByName(string name)
        {
           return _repository.FindByName(name);
        }
    }
}

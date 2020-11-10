using System.Collections.Generic;
using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Application.Services
{
    public class GroupAppService : AppServiceBase<Group>, IGroupAppService
    {
        private readonly IGroupService _appService;

        public GroupAppService(IGroupService service) : base(service)
        {
            _appService = service;
        }

        public IEnumerable<Group> FindFilterByNameOrId(string name)
        {
            return _appService.FindFilterByNameOrId(name);
        }
    }
}

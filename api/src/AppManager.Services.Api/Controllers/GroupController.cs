using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppManager.Application.DTO;
using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppManager.Services.Api.Controllers
{
  [Route("api/group")]
  [ApiController]
  public class GroupController : ControllerBase
  {
    private readonly IGroupAppService _service;
    private readonly IMapper _mapper;
    public GroupController(IGroupAppService service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GroupDTO>> Get([FromQuery] string filter)
    {
      if (!string.IsNullOrEmpty(filter))
      {
        return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(_service.FindFilterByNameOrId(filter));
      }
      else
      {
        return _mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(await _service.FindAll());
      }
    }
    [HttpGet("{id}")]
    public async Task<GroupDTO> Get(int id)
    {
      GroupDTO groupDTO = _mapper.Map<Group, GroupDTO>(await _service.Find(id));
      return groupDTO;
    }

    [HttpPost]
    public async Task Post([FromBody] GroupDTO value)
    {
      Group entity = _mapper.Map<GroupDTO, Group>(value);

      await _service.Add(entity);

    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] GroupDTO value)
    {

      var groupEntity = await _service.Find(id);
      Group newEntity = _mapper.Map(value, groupEntity);

      await _service.Update(newEntity);
    }
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _service.Delete(id);

    }
  }
}

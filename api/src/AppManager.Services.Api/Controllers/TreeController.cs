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
  [Route("api/tree")]
  [ApiController]
  public class TreeController : ControllerBase
  {
    private readonly ITreeAppService _service;
    private readonly IMapper _mapper;
    public TreeController(ITreeAppService service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TreeDTO>> Get()
    {
      IEnumerable<TreeDTO> treeDTO = _mapper.Map<IEnumerable<Tree>, IEnumerable<TreeDTO>>(await _service.FindAll());
      return treeDTO;
    }

    [HttpGet("{id}")]
    public async Task<TreeDTO> Get(int id)
    {
      TreeDTO treeDTO = _mapper.Map<Tree, TreeDTO>(await _service.Find(id));
      return treeDTO;
    }

    [HttpPost]
    public async Task Post([FromBody] TreeDTO value)
    {
      Tree entity = _mapper.Map<TreeDTO, Tree>(value);

      await _service.Add(entity);

    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] TreeDTO value)
    {

      var treeEntity = await _service.Find(id);
      Tree newEntity = _mapper.Map(value, treeEntity);

      await _service.Update(newEntity);
    }
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _service.Delete(id);

    }
  }
}

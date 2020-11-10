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
  [Route("api/harvest")]
  [ApiController]
  public class HarvestController : ControllerBase
  {
    private readonly IHarvestAppService _service;
    private readonly IMapper _mapper;
    public HarvestController(IHarvestAppService service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<HarvestDTO>> Get()
    {
      IEnumerable<HarvestDTO> harvestDTO = _mapper.Map<IEnumerable<Harvest>, IEnumerable<HarvestDTO>>(await _service.FindAll());
      return harvestDTO;
    }

    [HttpGet("{id}")]
    public async Task<HarvestDTO> Get(int id)
    {
      HarvestDTO harvestDTO = _mapper.Map<Harvest, HarvestDTO>(await _service.Find(id));
      return harvestDTO;
    }

    [HttpPost]
    public async Task Post([FromBody] HarvestDTO value)
    {
      Harvest entity = _mapper.Map<HarvestDTO, Harvest>(value);

      await _service.Add(entity);

    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] HarvestDTO value)
    {

      var harvestEntity = await _service.Find(id);
      Harvest newEntity = _mapper.Map(value, harvestEntity);

      await _service.Update(newEntity);
    }
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _service.Delete(id);

    }
  }
}

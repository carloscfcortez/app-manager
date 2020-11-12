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
  [Route("api/specie")]
  [ApiController]
  public class SpecieController : ControllerBase
  {
    private readonly ISpecieAppService _service;
    private readonly IMapper _mapper;
    public SpecieController(ISpecieAppService service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SpecieDTO>> Get([FromQuery] string filter)
    {
      IEnumerable<SpecieDTO> specieDTO = _mapper.Map<IEnumerable<Specie>, IEnumerable<SpecieDTO>>(await _service.FindAll());
      return specieDTO;
    }

    [HttpGet("{id}")]
    public async Task<SpecieDTO> Get(int id)
    {
      SpecieDTO specieDTO = _mapper.Map<Specie, SpecieDTO>(await _service.Find(id));
      return specieDTO;
    }

    [HttpPost]
    public async Task Post([FromBody] SpecieDTO value)
    {
      Specie entity = _mapper.Map<SpecieDTO, Specie>(value);

      await _service.Add(entity);

    }

    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] SpecieDTO value)
    {

      var specieEntity = await _service.Find(id);
      Specie newEntity = _mapper.Map(value, specieEntity);

      await _service.Update(newEntity);
    }
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      await _service.Delete(id);

    }
  }
}

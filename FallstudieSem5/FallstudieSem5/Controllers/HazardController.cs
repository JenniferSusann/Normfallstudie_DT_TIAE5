using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using FallstudieSem5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;


namespace FallstudieSem5.Controllers
{
  [Route("api/hazard")]
  [ApiController]
  public class HazardController : ControllerBase
  {
    private readonly IDataRepository<Hazard> _dataRepository;

    public HazardController(IDataRepository<Hazard> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      Hazard hazard = _dataRepository.Get(id);
      if (hazard == null)
      {
        return NotFound("not found.");
      }
      return Ok(hazard);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Hazard hazard)
    {
      if (hazard == null)
      {
        return BadRequest("is null");
      }
      _dataRepository.Add(hazard);
      return CreatedAtRoute(
        "Get", new { Id = hazard.HazardId }, hazard);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Hazard hazard)
    {
      if (hazard == null)
      {
        return BadRequest("is null.");
      }
      Hazard hazardToUpdate = _dataRepository.Get(id);
      if (hazardToUpdate == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Update(hazardToUpdate, hazard);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Hazard hazard = _dataRepository.Get(id);
      if (hazard == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Delete(hazard);
      return NoContent();
    }

  }
}

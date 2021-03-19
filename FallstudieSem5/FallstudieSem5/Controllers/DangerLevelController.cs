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
  [Route("api/dangerlevel")]
  [ApiController]
  public class DangerLevelController : ControllerBase
  {
    private readonly IDataRepository<DangerLevel> _dataRepository;

    public DangerLevelController(IDataRepository<DangerLevel> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "GetDangerLevel")]
    public IActionResult Get(long id)
    {
      DangerLevel dangerLevel = _dataRepository.Get(id);
      if (dangerLevel == null)
      {
        return NotFound("DangerLevel not found.");
      }
      return Ok(dangerLevel);
    }

    [HttpPost]
    public IActionResult Post([FromBody] DangerLevel dangerLevel)
    {
      if (dangerLevel == null)
      {
        return BadRequest("DangerLevel is null");
      }
      _dataRepository.Add(dangerLevel);
      return CreatedAtRoute(
        "Get", new { Id = dangerLevel.DangerLevelId }, dangerLevel);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] DangerLevel dangerLevel)
    {
      if (dangerLevel == null)
      {
        return BadRequest("DangerLevel is null.");
      }
      DangerLevel dangerlevelToUpdate = _dataRepository.Get(id);
      if (dangerlevelToUpdate == null)
      {
        return NotFound("dangerlevel not found");
      }
      _dataRepository.Update(dangerlevelToUpdate, dangerLevel);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      DangerLevel dangerLevel = _dataRepository.Get(id);
      if (dangerLevel == null)
      {
        return NotFound("DangerLevel not found");
      }
      _dataRepository.Delete(dangerLevel);
      return NoContent();
    }

  }
}

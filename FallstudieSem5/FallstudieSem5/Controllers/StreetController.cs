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
  [Route("api/street")]
  public class StreetController : ControllerBase
  {
    private readonly IDataRepository<Street> _dataRepository;

    public StreetController(IDataRepository<Street> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "GetStreet")]
    public IActionResult Get(long id)
    {
      Street street = _dataRepository.Get(id);
      if (street == null)
      {
        return NotFound("street not found.");
      }
      return Ok(street);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Street street)
    {
      if (street == null)
      {
        return BadRequest("Street is null");
      }
      _dataRepository.Add(street);
      return CreatedAtRoute(
        "Get", new { Id = street.StreetId }, street);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Street street)
    {
      if (street == null)
      {
        return BadRequest("Object is null.");
      }
      Street streetToUpdate = _dataRepository.Get(id);
      if (streetToUpdate == null)
      {
        return NotFound("street not found");
      }
      _dataRepository.Update(streetToUpdate, street);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Street street = _dataRepository.Get(id);
      if (street == null)
      {
        return NotFound("Street not found");
      }
      _dataRepository.Delete(street);
      return NoContent();
    }

  }
}

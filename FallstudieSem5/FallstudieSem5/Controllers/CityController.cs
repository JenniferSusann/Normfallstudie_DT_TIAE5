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
  [Route("api/city")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly IDataRepository<City> _dataRepository;

    public CityController(IDataRepository<City> dataRepository)
    {
      _dataRepository = dataRepository;
    }

    [HttpGet("{id}", Name = "GetCity")]
    public IActionResult Get(long id)
    {
      City city = _dataRepository.Get(id);
      if (city == null)
      {
        return NotFound("City not found.");
      }
      return Ok(city);
    }

    [HttpPost]
    public IActionResult Post([FromBody] City city)
    {
      if (city == null)
      {
        return BadRequest("City is null");
      }
      _dataRepository.Add(city);
      return CreatedAtRoute(
        "Get", new { Id = city.CityId }, city);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] City city)
    {
      if (city == null)
      {
        return BadRequest("City is null.");
      }
      City cityToUpdate = _dataRepository.Get(id);
      if (cityToUpdate == null)
      {
        return NotFound("City not found");
      }
      _dataRepository.Update(cityToUpdate, city);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      City city = _dataRepository.Get(id);
      if (city == null)
      {
        return NotFound("City not found");
      }
      _dataRepository.Delete(city);
      return NoContent();
    }

  }
}

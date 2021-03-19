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
  [Route("api/housenumber")]
  public class HouseNumberController : ControllerBase
  {
    private readonly IDataRepository<HouseNumber> _dataRepository;

    public HouseNumberController(IDataRepository<HouseNumber> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "GetHouseNumber")]
    public IActionResult Get(long id)
    {
      HouseNumber houseNumber = _dataRepository.Get(id);
      if (houseNumber == null)
      {
        return NotFound("Object not found.");
      }
      return Ok(houseNumber);
    }

    [HttpPost]
    public IActionResult Post([FromBody] HouseNumber houseNumber)
    {
      if (houseNumber == null)
      {
        return BadRequest("is null");
      }
      _dataRepository.Add(houseNumber);
      return CreatedAtRoute(
        "Get", new { Id = houseNumber.HouseNumberID }, houseNumber);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] HouseNumber houseNumber)
    {
      if (houseNumber == null)
      {
        return BadRequest("is null.");
      }
      HouseNumber housenumberToUpdate = _dataRepository.Get(id);
      if (housenumberToUpdate == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Update(housenumberToUpdate, houseNumber);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      HouseNumber houseNumber = _dataRepository.Get(id);
      if (houseNumber == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Delete(houseNumber);
      return NoContent();
    }

  }
}

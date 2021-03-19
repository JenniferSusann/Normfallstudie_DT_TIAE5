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
  [Route("api/propertyowner")]
  public class PropertyOwnerController : ControllerBase
  {
    private readonly IDataRepository<PropertyOwner> _dataRepository;

    public PropertyOwnerController(IDataRepository<PropertyOwner> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "GetPropertyOwner")]
    public IActionResult Get(long id)
    {
      PropertyOwner propertyOwner = _dataRepository.Get(id);
      if (propertyOwner == null)
      {
        return NotFound("not found.");
      }
      return Ok(propertyOwner);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PropertyOwner propertyOwner)
    {
      if (propertyOwner == null)
      {
        return BadRequest("is null");
      }
      _dataRepository.Add(propertyOwner);
      return CreatedAtRoute(
        "Get", new { Id = propertyOwner.PropertyOwnerId }, propertyOwner);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] PropertyOwner propertyOwner)
    {
      if (propertyOwner == null)
      {
        return BadRequest("is null.");
      }
      PropertyOwner propertyownerToUpdate = _dataRepository.Get(id);
      if (propertyownerToUpdate == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Update(propertyownerToUpdate, propertyOwner);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      PropertyOwner propertyOwner = _dataRepository.Get(id);
      if (propertyOwner == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Delete(propertyOwner);
      return NoContent();
    }

  }
}

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
  [Route("api/objectowner")]
  public class ObjectOwnerController : ControllerBase
  {
    private readonly IDataRepository<ObjectOwner> _dataRepository;

    public ObjectOwnerController(IDataRepository<ObjectOwner> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      ObjectOwner objectOwner = _dataRepository.Get(id);
      if (objectOwner == null)
      {
        return NotFound("not found.");
      }
      return Ok(objectOwner);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ObjectOwner objectOwner)
    {
      if (objectOwner == null)
      {
        return BadRequest("is null");
      }
      _dataRepository.Add(objectOwner);
      return CreatedAtRoute(
        "Get", new { Id = objectOwner.ObjectOwnerId }, objectOwner);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] ObjectOwner objectOwner)
    {
      if (objectOwner == null)
      {
        return BadRequest("is null.");
      }
      ObjectOwner objectownerToUpdate = _dataRepository.Get(id);
      if (objectownerToUpdate == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Update(objectownerToUpdate, objectOwner);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      ObjectOwner objectOwner = _dataRepository.Get(id);
      if (objectOwner == null)
      {
        return NotFound("not found");
      }
      _dataRepository.Delete(objectOwner);
      return NoContent();
    }

  }
}

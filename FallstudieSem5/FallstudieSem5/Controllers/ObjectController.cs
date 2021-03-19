using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using FallstudieSem5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FallstudieSem5.Controllers
{
  [Route("api/person")]
  [ApiController]
  public class ObjectController : ControllerBase
  {
    private readonly IDataRepository<Object> _dataRepository;

    public ObjectController(IDataRepository<Object> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    //get api/Person
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<Object> objects = _dataRepository.GetAll();
      return Ok(persons);
    }

    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      Object object = _dataRepository.Get(id);
      if (object == null)
      {
        return NotFound("Object not found.");
      }
      return Ok(object);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Object Object)
    {
      if (Object == null)
      {
        return BadRequest("Object is null");
      }
      _dataRepository.Add(object);
      return CreatedAtRoute(
        "Get", new { Id = object.ObjectId }, object);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Object object)
    {
      if (object == null)
      {
        return BadRequest("Object is null.");
      }
      Object objectToUpdate = _dataRepository.Get(id);
      if (objectToUpdate == null)
      {
        return NotFound("Person not found");
      }
      _dataRepository.Update(objectToUpdate, object);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Object object = _dataRepository.Get(id);
      if (object == null)
      {
        return NotFound("object not found");
      }
      _dataRepository.Delete(object);
      return NoContent();
    }

  }
}

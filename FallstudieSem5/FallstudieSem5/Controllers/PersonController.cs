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
  public class PersonController : ControllerBase
  {
    private readonly IDataRepository<Person> _dataRepository;

    public PersonController(IDataRepository<Person> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    //get api/Person
    [HttpGet]
    public IActionResult Get()
    {
      IEnumerable<Person> persons = _dataRepository.GetAll();
      return Ok(persons);
    }

    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      Person person = _dataRepository.Get(id);
      if (person == null)
      {
        return NotFound("Person not found.");
      }
      return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
      if (person == null)
      {
        return BadRequest("Person is null");
      }
      _dataRepository.Add(person);
      return CreatedAtRoute(
        "Get", new { Id = person.PersonId }, person);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Person person)
    {
      if (person == null)
      {
        return BadRequest("Person is null.");
      }
      Person personToUpdate = _dataRepository.Get(id);
      if (personToUpdate == null)
      {
        return NotFound("Person not found");
      }
      _dataRepository.Update(personToUpdate, person);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Person person = _dataRepository.Get(id);
      if (person == null)
      {
        return NotFound("Person not found");
      }
      _dataRepository.Delete(person);
      return NoContent();
    }

  }
}

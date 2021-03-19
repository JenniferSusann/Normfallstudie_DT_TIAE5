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
  [Route("api/title")]
  public class TitleController : ControllerBase
  {
    private readonly IDataRepository<Title> _dataRepository;

    public TitleController(IDataRepository<Title> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      Title title = _dataRepository.Get(id);
      if (title == null)
      {
        return NotFound("title not found.");
      }
      return Ok(title);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Title title)
    {
      if (title == null)
      {
        return BadRequest("title is null");
      }
      _dataRepository.Add(title);
      return CreatedAtRoute(
        "Get", new { Id = title.TitleId }, title);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Title title)
    {
      if (title == null)
      {
        return BadRequest("Object is null.");
      }
      Title titleToUpdate = _dataRepository.Get(id);
      if (titleToUpdate == null)
      {
        return NotFound("address not found");
      }
      _dataRepository.Update(titleToUpdate, title);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Title title = _dataRepository.Get(id);
      if (title == null)
      {
        return NotFound("title not found");
      }
      _dataRepository.Delete(title);
      return NoContent();
    }

  }
}

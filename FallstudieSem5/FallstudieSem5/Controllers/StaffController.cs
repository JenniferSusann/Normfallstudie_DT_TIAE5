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
  [Route("api/staff")]
  public class StaffController : ControllerBase
  {
    private readonly IDataRepository<Staff> _dataRepository;

    public StaffController(IDataRepository<Staff> dataRepository)
    {
      _dataRepository = dataRepository;
    }
    
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(long id)
    {
      Staff staff = _dataRepository.Get(id);
      if (staff == null)
      {
        return NotFound("Object not found.");
      }
      return Ok(staff);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Staff staff)
    {
      if (staff == null)
      {
        return BadRequest("Staff is null");
      }
      _dataRepository.Add(staff);
      return CreatedAtRoute(
        "Get", new { Id = staff.StaffId }, staff);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Staff staff)
    {
      if (staff == null)
      {
        return BadRequest("Staff is null.");
      }
      Staff staffToUpdate = _dataRepository.Get(id);
      if (staffToUpdate == null)
      {
        return NotFound("Staff not found");
      }
      _dataRepository.Update(staffToUpdate, staff);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Staff staff = _dataRepository.Get(id);
      if (staff == null)
      {
        return NotFound("staff not found");
      }
      _dataRepository.Delete(staff);
      return NoContent();
    }

  }
}

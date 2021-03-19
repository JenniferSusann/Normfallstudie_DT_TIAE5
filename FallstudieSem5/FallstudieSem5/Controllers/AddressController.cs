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
  [Route("api/address")]
  public class AddressController : ControllerBase
  {
    private readonly IDataRepository<Address> _dataRepository;

    public AddressController(IDataRepository<Address> dataRepository)
    {
      _dataRepository = dataRepository;
    }

    [HttpGet("{id}", Name = "GetAddress")]
    public IActionResult Get(long id)
    {
      Address address = _dataRepository.Get(id);
      if (address == null)
      {
        return NotFound("Object not found.");
      }
      return Ok(address);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Address address)
    {
      if (address == null)
      {
        return BadRequest("Address is null");
      }
      _dataRepository.Add(address);
      return CreatedAtRoute(
        "Get", new { Id = address.AddressId }, address);
    }
    [HttpPut("{id}")]
    public IActionResult Put(long id, [FromBody] Address address)
    {
      if (address == null)
      {
        return BadRequest("Object is null.");
      }
      Address addressToUpdate = _dataRepository.Get(id);
      if (addressToUpdate == null)
      {
        return NotFound("address not found");
      }
      _dataRepository.Update(addressToUpdate, address);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      Address address = _dataRepository.Get(id);
      if (address == null)
      {
        return NotFound("address not found");
      }
      _dataRepository.Delete(address);
      return NoContent();
    }

  }
}

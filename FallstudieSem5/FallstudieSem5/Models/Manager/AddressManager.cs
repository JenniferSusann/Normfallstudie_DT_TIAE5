using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5.Models.Manager
{
  public class AddressManager : IDataRepository<Address>
  {
    readonly Context _addressContext;

      public AddressManager(Context context)
    {
      _addressContext = context;
    }
    public IEnumerable<Address> GetAll()
    {
      return _addressContext.Addresses.Include(a => a.Street).ToList();
    }
    public Address Get(long id)
    {
      return _addressContext.Addresses
        .FirstOrDefault(a => a.AddressId == id);
    }
    public void Add(Address entity)
    {
      _addressContext.Addresses.Add(entity);
      _addressContext.SaveChanges();
    }
    public void Update(Address address, Address entity)
    {
      address.AddressId = entity.AddressId;

      _addressContext.SaveChanges();
    }

    public void Delete(Address address)
    {
      _addressContext.Addresses.Remove(address);
      _addressContext.SaveChanges();
    }

  }
}

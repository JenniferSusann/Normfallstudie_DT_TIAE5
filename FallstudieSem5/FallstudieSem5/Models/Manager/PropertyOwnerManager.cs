using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class PropertyOwnerManager : IDataRepository<PropertyOwner>
  {
    readonly Context _propertyownerContext;

      public PropertyOwnerManager(Context context)
    {
      _propertyownerContext = context;
    }
    public IEnumerable<PropertyOwner> GetAll()
    {
      return _propertyownerContext.PropertyOwners.ToList();
    }
    public PropertyOwner Get(long id)
    {
      return _propertyownerContext.PropertyOwners
        .FirstOrDefault(pw => pw.PropertyOwnerId == id);
    }
    public void Add(PropertyOwner entity)
    {
      _propertyownerContext.PropertyOwners.Add(entity);
      _propertyownerContext.SaveChanges();
    }
    public void Update(PropertyOwner propertyOwner, PropertyOwner entity)
    {
      propertyOwner.PropertyOwnerId = entity.PropertyOwnerId;
      propertyOwner.PurchaseDate = entity.PurchaseDate;

      _propertyownerContext.SaveChanges();
    }

    public void Delete(PropertyOwner propertyOwner)
    {
      _propertyownerContext.PropertyOwners.Remove(propertyOwner);
      _propertyownerContext.SaveChanges();
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class ObjectOwnerManager : IDataRepository<ObjectOwner>
  {
    readonly Context _objectownerContext;

      public ObjectOwnerManager(Context context)
    {
      _objectownerContext = context;
    }
    public IEnumerable<ObjectOwner> GetAll()
    {
      return _objectownerContext.ObjectOwners.ToList();
    }
    public ObjectOwner Get(long id)
    {
      return _objectownerContext.ObjectOwners
        .FirstOrDefault(ow => ow.ObjectOwnerId == id);
    }
    public void Add(ObjectOwner entity)
    {
      _objectownerContext.ObjectOwners.Add(entity);
      _objectownerContext.SaveChanges();
    }
    public void Update(ObjectOwner objectOwner, ObjectOwner entity)
    {
      objectOwner.ObjectOwnerId = entity.ObjectOwnerId;
      objectOwner.PurchaseDate = entity.PurchaseDate;

      _objectownerContext.SaveChanges();
    }

    public void Delete(ObjectOwner objectOwner)
    {
      _objectownerContext.ObjectOwners.Remove(objectOwner);
      _objectownerContext.SaveChanges();
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class ObjectManager : IDataRepository<Object>
  {
    readonly Context _objectContext;

      public ObjectManager(Context context)
    {
      _objectContext = context;
    }
    public IEnumerable<Object> GetAll()
    {
      return _objectContext.Objects.ToList();
    }
    public Object Get(long id)
    {
      return _objectContext.Objects
        .FirstOrDefault(o => o.ObjectId == id);
    }
    public void Add(Object entity)
    {
      _objectContext.Objects.Add(entity);
      _objectContext.SaveChanges();
    }
    public void Update(Object @object, Object entity)
    {
      @object.Descripton = entity.Descripton;

      _objectContext.SaveChanges();
    }

    public void Delete(Object @object)
    {
      _objectContext.Objects.Remove(@object);
      _objectContext.SaveChanges();
    }

  }
}

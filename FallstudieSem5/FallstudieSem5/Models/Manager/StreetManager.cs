using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5.Models.Manager
{
  public class StreetManager : IDataRepository<Street>
  {
    readonly Context _streetContext;

      public StreetManager(Context context)
    {
      _streetContext = context;
    }
    public IEnumerable<Street> GetAll()
    {
      return _streetContext.Streets.Include(s => s.City).Include(s => s.HouseNumber).ToList();
    }
    public Street Get(long id)
    {
      return _streetContext.Streets
        .FirstOrDefault(st => st.StreetId == id);
    }
    public void Add(Street entity)
    {
      _streetContext.Streets.Add(entity);
      _streetContext.SaveChanges();
    }
    public void Update(Street street, Street entity)
    {
      street.StreetName = entity.StreetName;

      _streetContext.SaveChanges();
    }

    public void Delete(Street street)
    {
      _streetContext.Streets.Remove(street);
      _streetContext.SaveChanges();
    }

  }
}

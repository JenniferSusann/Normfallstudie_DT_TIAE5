using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class CityManager : IDataRepository<City>
  {
    readonly Context _cityContext;

      public CityManager(Context context)
    {
      _cityContext = context;
    }
    public IEnumerable<City> GetAll()
    {
      return _cityContext.Cities.ToList();
    }
    public City Get(long id)
    {
      return _cityContext.Cities
        .FirstOrDefault(c => c.CityId == id);
    }
    public void Add(City entity)
    {
      _cityContext.Cities.Add(entity);
      _cityContext.SaveChanges();
    }
    public void Update(City city, City entity)
    {
      city.CityName = entity.CityName;
      city.ZipCode = entity.ZipCode;

      _cityContext.SaveChanges();
    }

    public void Delete(City city)
    {
      _cityContext.Cities.Remove(city);
      _cityContext.SaveChanges();
    }

  }
}

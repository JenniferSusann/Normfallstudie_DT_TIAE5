using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class HouseNumberManager : IDataRepository<HouseNumber>
  {
    readonly Context _housenumberContext;

      public HouseNumberManager(Context context)
    {
      _housenumberContext = context;
    }
    public IEnumerable<HouseNumber> GetAll()
    {
      return _housenumberContext.HouseNumbers.ToList();
    }
    public HouseNumber Get(long id)
    {
      return _housenumberContext.HouseNumbers
        .FirstOrDefault(hn => hn.HouseNumberID == id);
    }
    public void Add(HouseNumber entity)
    {
      _housenumberContext.HouseNumbers.Add(entity);
      _housenumberContext.SaveChanges();
    }
    public void Update(HouseNumber houseNumber, HouseNumber entity)
    {
      houseNumber.Number = entity.Number;

      _housenumberContext.SaveChanges();
    }

    public void Delete(HouseNumber houseNumber)
    {
      _housenumberContext.HouseNumbers.Remove(houseNumber);
      _housenumberContext.SaveChanges();
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class HazardManager : IDataRepository<Hazard>
  {
    readonly Context _hazardContext;

      public HazardManager(Context context)
    {
      _hazardContext = context;
    }
    public IEnumerable<Hazard> GetAll()
    {
      return _hazardContext.Hazards.ToList();
    }
    public Hazard Get(long id)
    {
      return _hazardContext.Hazards
        .FirstOrDefault(h => h.HazardId == id);
    }
    public void Add(Hazard entity)
    {
      _hazardContext.Hazards.Add(entity);
      _hazardContext.SaveChanges();
    }
    public void Update(Hazard hazard, Hazard entity)
    {
      hazard.Description = entity.Description;
      hazard.LastUpdated = entity.LastUpdated;

      _hazardContext.SaveChanges();
    }

    public void Delete(Hazard hazard)
    {
      _hazardContext.Hazards.Remove(hazard);
      _hazardContext.SaveChanges();
    }

  }
}

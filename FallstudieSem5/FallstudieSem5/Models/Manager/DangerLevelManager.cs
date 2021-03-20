using System.Collections.Generic;
using System.Linq;
using FallstudieSem5.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5.Models.Manager
{
  public class DangerLevelManager : IDataRepository<DangerLevel>
  {
    readonly Context _dangerLevelContext;

      public DangerLevelManager(Context context)
    {
      _dangerLevelContext = context;
    }
    public IEnumerable<DangerLevel> GetAll()
    {
      return _dangerLevelContext.DangerLevels.ToList();
    }
    public DangerLevel Get(long id)
    {
      return _dangerLevelContext.DangerLevels
        .FirstOrDefault(dl => dl.DangerLevelId == id);
    }
    public void Add(DangerLevel entity)
    {
      _dangerLevelContext.DangerLevels.Add(entity);
      _dangerLevelContext.SaveChanges();
    }
    public void Update(DangerLevel dangerLevel, DangerLevel entity)
    {
      dangerLevel.Score = entity.Score;

      _dangerLevelContext.SaveChanges();
    }

    public void Delete(DangerLevel dangerLevel)
    {
      _dangerLevelContext.DangerLevels.Remove(dangerLevel);
      _dangerLevelContext.SaveChanges();
    }

  }
}

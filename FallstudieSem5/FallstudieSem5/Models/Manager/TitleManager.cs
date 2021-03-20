using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5.Models.Manager
{
  public class TitleManager : IDataRepository<Title>
  {
    readonly Context _titleContext;

      public TitleManager(Context context)
    {
      _titleContext = context;
    }
    public IEnumerable<Title> GetAll()
    {
      return _titleContext.Titles.ToList();
    }
    public Title Get(long id)
    {
      return _titleContext.Titles
        .FirstOrDefault(t => t.TitleId == id);
    }
    public void Add(Title entity)
    {
      _titleContext.Titles.Add(entity);
      _titleContext.SaveChanges();
    }
    public void Update(Title title, Title entity)
    {
      title.Description = entity.Description;

      _titleContext.SaveChanges();
    }

    public void Delete(Title title)
    {
      _titleContext.Titles.Remove(title);
      _titleContext.SaveChanges();
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;

namespace FallstudieSem5.Models.Manager
{
  public class StaffManager : IDataRepository<Staff>
  {
    readonly Context _StaffContext;

      public StaffManager(Context context)
    {
      _staffContext = context;
    }
    public IEnumerable<Staff> GetAll()
    {
      return _staffContext.Staffs.ToList();
    }
    public Object Get(long id)
    {
      return _staffContext.Staffs
        .FirstOrDefault(s => s.StaffId == id);
    }
    public void Add(Staff entity)
    {
      _staffContext.Staffs.Add(entity);
      _staffContext.SaveChanges();
    }
    public void Update(Staff staff, Staff entity)
    {
      Staff.Description = entity.Description;

      _staffContext.SaveChanges();
    }

    public void Delete(Staff staff)
    {
      _staffContext.Staffs.Remove(staff);
      _staffContext.SaveChanges();
    }

  }
}

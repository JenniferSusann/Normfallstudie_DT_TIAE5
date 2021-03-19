using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5
{
  public class Context : DbContext
  {
    public Context(DbContextOptions options)
      :base(options)
    {

    }
    public DbSet<City> Cities { get; set; }
    public DbSet<HouseNumber> HouseNumbers { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<DangerLevel> DangerLevels { get; set; }
    public DbSet<Hazard> Hazards { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PropertyOwner> PropertyOwners { get; set; }
    public DbSet<ObjectOwner> ObjectOwners { get; set; }
    public DbSet<Staff> Staffs { get; set; }


  }
}

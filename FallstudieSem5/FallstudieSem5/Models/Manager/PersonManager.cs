using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FallstudieSem5.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace FallstudieSem5.Models.Manager
{
  public class PersonManager : IDataRepository<Person>
  {
    readonly Context _personContext;

      public PersonManager(Context context)
    {
      _personContext = context;
    }
    public IEnumerable<Person> GetAll()
    {
      return _personContext.Persons.Include(p => p.Title).Include(p => p.Object).Include(p => p.Address).ToList(); ///
    }
    public Person Get(long id)
    {
      return _personContext.Persons
        .FirstOrDefault(p => p.PersonId == id);
    }
    public void Add(Person entity)
    {
      _personContext.Persons.Add(entity);
      _personContext.SaveChanges();
    }
    public void Update(Person person, Person entity)
    {
      person.FirstName = entity.FirstName;
      person.LastName = entity.LastName;
      person.Email = entity.Email;
      _personContext.SaveChanges();
    }

    public void Delete(Person person)
    {
      _personContext.Persons.Remove(person);
      _personContext.SaveChanges();
    }

  }
}

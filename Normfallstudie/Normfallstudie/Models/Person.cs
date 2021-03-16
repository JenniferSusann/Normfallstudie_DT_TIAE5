using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Person")] // created Table with the Name Person
  public class Person
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set PersonId as PrimaryKey in the Database
    public long PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ICollection<Staff> Staffs { get; set; } // used to extend functionality to add, remove and update elements in the list
    public ICollection<PropertyOwner> PropertyOwners { get; set; }
    public ICollection<ObjectOwner> ObjectOwners { get; set; }

    [ForeignKey(nameof(Title))]
    public Title TitleId { get; set; }

    [ForeignKey(nameof(Object))]
    public Object ObjectId { get; set; }
  }
}

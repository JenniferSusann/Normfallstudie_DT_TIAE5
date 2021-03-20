using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("Person")] // created Table with the Name Person
  public class Person
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set PersonId as PrimaryKey in the Database
    public long PersonId { get; set; }

    [Required(ErrorMessage = "FirstName is Required")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is Required")]
    [StringLength(150)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "E-Mail is Required")]
    [EmailAddress]
    public string Email { get; set; }

    [JsonIgnore]
    public ICollection<Staff> Staffs { get; set; } // used to extend functionality to add, remove and update elements in the list
    [JsonIgnore]
    public ICollection<PropertyOwner> PropertyOwners { get; set; }
    [JsonIgnore]
    public ICollection<ObjectOwner> ObjectOwners { get; set; }


    [Required(ErrorMessage = "Title is Required")]
    public Title Title { get; set; }

    public Object Object { get; set; }
    public Address Address { get; set; }
  }
}

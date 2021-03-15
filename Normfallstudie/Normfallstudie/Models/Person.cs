using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Person")]
  public class Person
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}

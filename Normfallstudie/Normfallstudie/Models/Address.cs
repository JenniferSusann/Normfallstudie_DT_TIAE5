using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Address")] // created Table with the Name Address
  public class Address
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HouseNumberId as PrimaryKey in the Database
    public long AddressId { get; set; }
    public ICollection<Object> Objects { get; set; }
    public ICollection<Person> Persons { get; set; }

    [ForeignKey(nameof(Street))]
    public Street StreetId { get; set; }

  }
}

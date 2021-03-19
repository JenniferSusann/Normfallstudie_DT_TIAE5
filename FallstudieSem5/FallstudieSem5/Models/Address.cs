using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("Address")] // created Table with the Name Address
  public class Address
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HouseNumberId as PrimaryKey in the Database
    public long AddressId { get; set; }
    [JsonIgnore]
    public ICollection<Object> Objects { get; set; }
    [JsonIgnore]
    public ICollection<Person> Persons { get; set; }

    [Required(ErrorMessage = "Address needs a Street")]
    public Street Street { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("HouseNumber")] // created Table with the Name HouseNumber
  public class HouseNumber
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HouseNumberId as PrimaryKey in the Database
    public long HouseNumberID { get; set; }

    [Required(ErrorMessage = "HouseNumber is Required")]
    [StringLength(20)]
    public string Number { get; set; } // set as string because the posibility of having a housenumber like 17a

    [JsonIgnore]
    public ICollection<Street> Streets { get; set; }
  }
}

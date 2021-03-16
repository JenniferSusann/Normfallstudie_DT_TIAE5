using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("HouseNumber")] // created Table with the Name HouseNumber
  public class HouseNumber
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HouseNumberId as PrimaryKey in the Database
    public long HouseNumberID { get; set; }
    public string Number { get; set; } // set as string because the posibility of having a housenumber like 17a
    public ICollection<Street> Streets { get; set; }
  }
}

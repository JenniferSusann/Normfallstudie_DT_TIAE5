using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("HouseNumber")]
  public class HouseNumber
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long HouseNumberID { get; set; }
    public string Number { get; set; }

    public ICollection<Street> Streets { get; set; }
  }
}

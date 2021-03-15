using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Hazard")]
  public class Hazard
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long HazardId { get; set; }
    public string Description { get; set; }

  }
}

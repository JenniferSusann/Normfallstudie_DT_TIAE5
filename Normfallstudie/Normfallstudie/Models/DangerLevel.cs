using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("DangerLevel")]
  public class DangerLevel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long DangerLevelId { get; set; }
    public int score { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("DangerLevel")] // created Table with the Name DangerLevel
  public class DangerLevel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set DangerLevelId as PrimaryKey in the Database
    public long DangerLevelId { get; set; }
    public int Score { get; set; }
    public ICollection<Hazard> Hazards { get; set; } // used to extend functionality to add, remove and update elements in the list

  }
}

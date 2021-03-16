using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Hazard")] // created Table with the Name Hazard
  public class Hazard
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HazardId as PrimaryKey in the Database
    public long HazardId { get; set; }
    public string Description { get; set; }
    public ICollection<Object> Objects { get; set; } // used to extend functionality to add, remove and update elements in the list

    [ForeignKey(nameof(DangerLevel))]
    public DangerLevel DangerLevelId { get; set; }


  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FallstudieSem5.Models
{
  [Table("Hazard")] // created Table with the Name Hazard
  public class Hazard
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set HazardId as PrimaryKey in the Database
    public long HazardId { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public DateTime LastUpdated {get; set;}

    public ICollection<Object> Objects { get; set; } // used to extend functionality to add, remove and update elements in the list

    [Required(ErrorMessage = "DangerLevel is required")]
    public DangerLevel DangerLevel { get; set; }

  }
}

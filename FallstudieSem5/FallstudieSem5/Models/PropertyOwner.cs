using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("PropertyOwner")] // created Table with the Name PropertyOwner
  public class PropertyOwner
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set PropertyOwnerId as PrimaryKey in the Database
    public long PropertyOwnerId { get; set; }

    [Required(ErrorMessage = "PurchaseDate is required")]
    public DateTime PurchaseDate { get; set; }

    [Required]
    public Person Person { get; set; }
  }
}

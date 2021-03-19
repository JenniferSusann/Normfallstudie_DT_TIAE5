using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("ObjectOwner")] // created Table with the Name ObjectOwner
  public class ObjectOwner
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set ObjectOwnerId as PrimaryKey in the Database
    public long ObjectOwnerId { get; set; }

    [Required(ErrorMessage = "PurchaseDate is required")]
    public DateTime PurchaseDate { get; set; }

    [Required]
    public Person Person { get; set; }

  }
}

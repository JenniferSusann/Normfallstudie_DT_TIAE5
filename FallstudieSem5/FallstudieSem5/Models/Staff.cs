using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FallstudieSem5.Models
{
  [Table("Staff")] // created Table with the Name Staff
  public class Staff
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set StaffId as PrimaryKey in the Database
    public long StaffId { get; set; }

    [StringLength(150)]
    public string Description { get; set; }

    [Required]
    public Person Person { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Staff")] // created Table with the Name Staff
  public class Staff
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set StaffId as PrimaryKey in the Database
    public long StaffId { get; set; }
    public string Description { get; set; }

    [ForeignKey(nameof(Person))]
    public Person PersonId { get; set; }

  }
}

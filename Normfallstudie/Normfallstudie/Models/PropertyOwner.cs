using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("PropertyOwner")] // created Table with the Name PropertyOwner
  public class PropertyOwner
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set PropertyOwnerId as PrimaryKey in the Database
    public long PropertyOwnerId { get; set; }
    public DateTime PurchaseDate { get; set; }

    [ForeignKey(nameof(Person))]
    public Person PersonId { get; set; }

  }
}

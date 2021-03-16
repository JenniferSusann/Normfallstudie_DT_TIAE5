using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("ObjectOwner")] // created Table with the Name ObjectOwner
  public class ObjectOwner
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set ObjectOwnerId as PrimaryKey in the Database
    public long ObjectOwnerId { get; set; }
    public DateTime PurchaseDate { get; set; }

    [ForeignKey(nameof(Person))]
    public Person PersonId { get; set; }

  }
}

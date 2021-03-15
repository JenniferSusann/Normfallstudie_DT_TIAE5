using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("ObjectOwner")]
  public class ObjectOwner
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ObjectOwnerId { get; set; }
    public DateTime PurchaseDate { get; set; }

  }
}

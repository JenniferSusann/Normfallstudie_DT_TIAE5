using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Address")]
  public class Address
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AddressId { get; set; }

  }
}

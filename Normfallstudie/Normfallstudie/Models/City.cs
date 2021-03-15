using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("City")]
  public class City
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CityId { get; set; }
    public string CityName { get; set; }
    public int ZipCode { get; set; }

  }
}

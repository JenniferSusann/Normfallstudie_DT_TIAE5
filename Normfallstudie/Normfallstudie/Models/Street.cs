using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Street")] // erstellt tabelle mit Namen Street
  public class Street
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long StreetId { get; set; }
    public string StreetName { get; set; }

    [ForeignKey(nameof(HouseNumber))]
    public HouseNumber HouseNumberId { get; set; }
   

  }
}

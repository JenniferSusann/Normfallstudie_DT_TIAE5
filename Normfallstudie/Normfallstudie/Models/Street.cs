using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Street")] // created Table with the Name Street
  public class Street
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set StaffId as PrimaryKey in the Database
    public long StreetId { get; set; }
    public string StreetName { get; set; }
    public ICollection<Address> Addresses { get; set; }

    [ForeignKey(nameof(HouseNumber))]
    public HouseNumber HouseNumberId { get; set; }
   

  }
}

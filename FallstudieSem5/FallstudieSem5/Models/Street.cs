using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FallstudieSem5.Models
{
  [Table("Street")] // created Table with the Name Street
  public class Street
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set StaffId as PrimaryKey in the Database
    public long StreetId { get; set; }

    [Required(ErrorMessage = "Streetname is required")]
    [StringLength(255)]
    public string StreetName { get; set; }

    [Required(ErrorMessage = "HouseNuber is Required")]
    public HouseNumber HouseNumber { get; set; }

    [Required(ErrorMessage = "CityId is Required")]
    public City City { get; set; }

    public ICollection<Address> Addresses { get; set; }
  }
}

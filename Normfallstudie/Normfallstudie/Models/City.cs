using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("City")] // created Table with the Name City
  public class City
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set CityId as PrimaryKey in the Database
    public long CityId { get; set; }
    public string CityName { get; set; }
    public int ZipCode { get; set; }
    public ICollection<Street> Streets { get; set; } // used to extend functionality to add, remove and update elements in the list

  }
}

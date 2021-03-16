using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Object")] // created Table with the Name Object
  public class Object
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set ObjectId as PrimaryKey in the Database
    public long ObjectId { get; set; }
    public string Descripton { get; set; }
    public ICollection<Person> Persons { get; set; }
    public ICollection<Hazard> Hazards { get; set; }

    [ForeignKey(nameof(Address))]
    public Address AddressId { get; set; }

  }
}

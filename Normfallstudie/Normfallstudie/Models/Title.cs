using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Title")] // created Table with the Name Title
  public class Title
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set TitleId as PrimaryKey in the Database
    public long TitleId { get; set; }
    public string Description { get; set; }
    public ICollection<Person> Persons { get; set; } // used to extend functionality to add, remove and update elements in the list

  }
}

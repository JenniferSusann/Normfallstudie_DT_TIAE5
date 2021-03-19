using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FallstudieSem5.Models
{
  [Table("Title")] // created Table with the Name Title
  public class Title
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set TitleId as PrimaryKey in the Database
    public long TitleId { get; set; }

    [Required(ErrorMessage = "Title needs a Description")]
    [StringLength(20)]
    public string Description { get; set; }

    public ICollection<Person> Persons { get; set; }
  }
}

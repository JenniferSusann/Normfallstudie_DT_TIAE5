using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FallstudieSem5.Models;
using System.Text.Json.Serialization;

namespace FallstudieSem5
{
  [Table("Object")] // created Table with the Name Object
  public class Object
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // used to set ObjectId as PrimaryKey in the Database
    public long ObjectId { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [StringLength(255)]
    public string Description { get; set; }

    [JsonIgnore]
    public ICollection<Person> Persons { get; set; }
    [JsonIgnore]
    public ICollection<Hazard> Hazards { get; set; }


    [Required(ErrorMessage = "Address is Required")]
    public Address Address { get; set; }

    [Required(ErrorMessage = "Hazard is Required")]
    public Hazard Hazard { get; set; }

  }
}

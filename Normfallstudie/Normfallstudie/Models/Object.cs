using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Normfallstudie.Models
{
  [Table("Object")]
  public class Object
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ObjectId { get; set; }
    public string Descripton { get; set; }

  }
}

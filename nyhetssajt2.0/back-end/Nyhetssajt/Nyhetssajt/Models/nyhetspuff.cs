using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nyhetssajt.Models
{
  public class Nyhetspuff
  {

    [Key]
    public int GuId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public string Date { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Link { get; set; }

    [Required]
    public string Source { get; set; }
  }
}

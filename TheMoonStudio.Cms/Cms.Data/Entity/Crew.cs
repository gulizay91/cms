using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Crew : BaseEntity
  {
    public Crew()
    {
      BoatCrews = new HashSet<BoatCrew>();
    }

    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int UserId { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; }

    [MaxLength(500)]
    public string Address { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public virtual ICollection<BoatCrew> BoatCrews { get; set; }
  }
}

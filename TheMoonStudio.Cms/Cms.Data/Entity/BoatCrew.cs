using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class BoatCrew : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int BoatId { get; set; }

    [Required]
    public int CrewId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Role { get; set; }

    public bool? IsFrozen { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    [ForeignKey("BoatId")]
    public virtual Boat Boat { get; set; }

    [ForeignKey("CrewId")]
    public virtual Crew Crew { get; set; }
  }
}

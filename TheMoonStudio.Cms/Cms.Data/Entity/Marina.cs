using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Marina : BaseEntity
  {
    public Marina()
    {
      Boats = new HashSet<Boat>();
    }

    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; }

    [MaxLength(500)]
    public string Address { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    public virtual ICollection<Boat> Boats { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Fixture : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int BoatId { get; set; }

    [MaxLength(150)]
    public string ProductNumber { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Brand { get; set; }

    public int Total { get; set; }

    [MaxLength(500)]
    public string Note { get; set; }

    public DateTime? ExpirationDate { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    [ForeignKey("BoatId")]
    public virtual Boat Boat { get; set; }
  }
}

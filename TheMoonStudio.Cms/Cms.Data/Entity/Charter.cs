using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Charter : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    [MaxLength(100)]
    public string HirerName { get; set; }

    [Required]
    [MaxLength(100)]
    public string HirerLastName { get; set; }

    [MaxLength(50)]
    public string HirerPhone { get; set; }

    public int? NumberOfGuest { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class TenantHistory : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(250)]
    public string ApiKey { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Theme { get; set; }

    public bool? IsFrozen { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; }

  }
}

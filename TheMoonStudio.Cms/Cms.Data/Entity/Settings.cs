using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Settings : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public Guid TenantId { get; set; }

    public int? CompanyId { get; set; }

    [MaxLength(250)]
    public string Code { get; set; }

    [Required]
    [MaxLength(500)]
    public string Key { get; set; }

    [MaxLength]
    public string Value { get; set; }

    [MaxLength]
    public string Description { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; }

    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }
  }
}

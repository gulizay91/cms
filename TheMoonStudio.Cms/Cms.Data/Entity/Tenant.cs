using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Tenant 
  {
    public Tenant()
    {
      Companies = new HashSet<Company>();
      Settings = new HashSet<Settings>();
      TenantHistories = new HashSet<TenantHistory>();
    }

    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int Id { get; set; }

    [Key]
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

    [Required]
    public int CreateUser { get; set; }

    public int? UpdateUser { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    public virtual ICollection<Company> Companies { get; set; }
    public virtual ICollection<Settings> Settings { get; set; }
    public virtual ICollection<TenantHistory> TenantHistories { get; set; }
  }
}

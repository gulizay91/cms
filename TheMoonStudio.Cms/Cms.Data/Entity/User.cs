using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class User : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int UserTypeId { get; set; }

    public long? IdentityNumber { get; set; } 

    [Required]
    [MaxLength(20)]
    public string Username { get; set; }

    [Required]
    [MaxLength(30)]
    public string Password { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(150)]
    public string LastName { get; set; }

    [MaxLength(150)]
    public string Email { get; set; }

    public DateTime? Birthday { get; set; }

    public byte[] Avatar { get; set; }

    public bool? IsFrozen { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    [ForeignKey("UserTypeId")]
    public virtual UserType UserType { get; set; }
  }
}

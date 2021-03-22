using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public class UserRefreshToken : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(500)]
    public string RefreshToken { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
  }
}

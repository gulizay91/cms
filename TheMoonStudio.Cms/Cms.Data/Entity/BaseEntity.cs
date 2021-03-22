using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cms.Data.Entity
{
  public abstract class BaseEntity
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int CreateUser { get; set; }

    public int? UpdateUser { get; set; }

    private bool? _isActive;

    [Required]
    public bool IsActive
    {
      get
      {
        if (_isActive == null)
        {
          _isActive = true;
        }
        return (bool)_isActive;
      }

      set { _isActive = value; }
    }

    [Required]
    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
  }
}

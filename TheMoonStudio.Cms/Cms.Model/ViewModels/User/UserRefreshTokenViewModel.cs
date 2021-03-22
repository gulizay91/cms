using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class UserRefreshTokenViewModel
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string RefreshToken { get; set; }
    public bool IsActive { get; set; }
  }
}

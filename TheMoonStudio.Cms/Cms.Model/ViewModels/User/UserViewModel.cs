using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class UserViewModel : BaseViewModel
  {
    public int UserTypeId { get; set; }
    public long? IdentityNumber { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public string Email { get; set; }
    public DateTime? Birthday { get; set; }
    public byte Avatar { get; set; }
    public bool? IsFrozen { get; set; }

    public UserTypeViewModel UserType { get; set; }
  }
}

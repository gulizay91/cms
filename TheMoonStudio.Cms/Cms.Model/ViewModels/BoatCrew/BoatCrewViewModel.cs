using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class BoatCrewViewModel : BaseViewModel
  {
    public int BoatId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
    public bool? IsFrozen { get; set; }
  }
}

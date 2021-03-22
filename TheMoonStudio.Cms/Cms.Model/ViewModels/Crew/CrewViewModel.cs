using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class CrewViewModel
  {
    public int UserId { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserViewModel User { get; set; }
    public List<BoatCrewViewModel> BoatCrews { get; set; }
  }
}

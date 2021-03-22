using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class MarinaViewModel : BaseViewModel
  {
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public List<BoatViewModel> Boats { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class FixtureViewModel : BaseViewModel
  {
    public int BoatId { get; set; }
    public string ProductNumber { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public int Total { get; set; }
    public string Note { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public BoatViewModel Boat { get; set; }
  }
}

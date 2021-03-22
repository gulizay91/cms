using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class BoatViewModel : BaseViewModel
  {
    public string RegisterNumber { get; set; }
    public string Name { get; set; }
    public int? Year { get; set; }
    public string MotorBrand { get; set; }
    public int? NumberOfEngines { get; set; }
    public string Fuel { get; set; }
    public string Body { get; set; }
    public double? Height { get; set; }
    public double? Width { get; set; }
    public int? Cabin { get; set; }
    public int? NumberOfBed { get; set; }
    public int? CrewCapacity { get; set; }
    public int? GuestCapacity { get; set; }
    public string Flag { get; set; }
    public int? MarinaId { get; set; }
    public bool? IsMotorYacht { get; set; }
    public bool? IsCommercialBoat { get; set; }

    public List<FixtureViewModel> Fixtures { get; set; }
    public List<BoatCrewViewModel> BoatCrews { get; set; }
    public List<BoatHistoryViewModel> BoatHistories { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Boat : BaseEntity
  {
    public Boat()
    {
      Fixtures = new HashSet<Fixture>();
      BoatCrews = new HashSet<BoatCrew>();
      BoatHistories = new HashSet<BoatHistory>();
    }

    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [MaxLength(100)]
    public string RegisterNumber { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    public int? Year { get; set; }

    [MaxLength(100)]
    public string MotorBrand { get; set; }

    public int? NumberOfEngines { get; set; }

    public int? EnginePower { get; set; }

    [MaxLength(100)]
    public string Fuel { get; set; }

    [MaxLength(100)]
    public string Body { get; set; }

    public float? Height { get; set; }

    public float? Width { get; set; }

    public int? Cabin { get; set; }

    public int? NumberOfBed { get; set; }

    public int? CrewCapacity { get; set; }

    public int? GuestCapacity { get; set; }

    [MaxLength(100)]
    public string Flag { get; set; }

    public int? MarinaId { get; set; }

    public bool? IsMotorYacht { get; set; }

    public bool? IsCommercialBoat { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    public virtual ICollection<Fixture> Fixtures { get; set; }
    public virtual ICollection<BoatCrew> BoatCrews { get; set; }
    public virtual ICollection<BoatHistory> BoatHistories { get; set; }

  }
}

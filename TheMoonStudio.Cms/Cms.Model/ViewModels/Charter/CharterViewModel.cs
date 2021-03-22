using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class CharterViewModel : BaseViewModel
  {
    public string HirerName { get; set; }
    public string HirerLastName { get; set; }
    public string HirerPhone { get; set; }
    public int? NumberOfGuest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}

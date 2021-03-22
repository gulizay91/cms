using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class BaseViewModel
  {
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public bool IsActive { get; set; }

    public CompanyViewModel Company { get; set; }
  }
}

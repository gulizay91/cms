using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class ExpenseViewModel : BaseViewModel
  {
    public int ExpenseTypeId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Explanation { get; set; }
    public float PaidAmount { get; set; }
    public float RemainingAmount { get; set; }
    public float TotalAmount { get; set; }
    public ExpenseTypeViewModel ExpenseType { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Expense : BaseEntity
  {
    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int ExpenseTypeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; }

    [MaxLength(500)]
    public string Address { get; set; }

    [MaxLength(500)]
    public string Explanation { get; set; }

    [Required]
    public float PaidAmount { get; set; }

    [Required]
    public float RemainingAmount { get; set; }

    [Required]
    public float TotalAmount { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }

    [ForeignKey("ExpenseTypeId")]
    public virtual ExpenseType ExpenseType { get; set; }
  }
}

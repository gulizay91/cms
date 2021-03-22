using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Data.Entity
{
  public partial class Company : BaseEntity
  {
    public Company()
    {
      Users = new HashSet<User>();
      UserTypes = new HashSet<UserType>();
      Boats = new HashSet<Boat>();
      Expenses = new HashSet<Expense>();
      ExpenseTypes = new HashSet<ExpenseType>();
    }

    //-----------------------------
    //Properties
    //-----------------------------
    [Required]
    public Guid TenantId { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Name { get; set; }

    //-----------------------------
    //Relationships
    //-----------------------------
    [ForeignKey("TenantId")]
    public virtual Tenant Tenant { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<UserType> UserTypes { get; set; }
    public virtual ICollection<Boat> Boats { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; }
    public virtual ICollection<ExpenseType> ExpenseTypes { get; set; }
  }
}

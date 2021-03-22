using Cms.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.Configuration
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Ignore<View_GetBoatCrew_Result>(); // this view does not have unique key like pk
      //modelBuilder.Ignore<SP_GetExpense_Result>(); // this sp does not have unique key like pk
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    // Tables
    public DbSet<Tenant> Tenant { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserType> UserType { get; set; }
    public DbSet<Crew> Crew { get; set; }
    public DbSet<Boat> Boat { get; set; }
    public DbSet<BoatCrew> BoatCrew { get; set; }
    public DbSet<Charter> Charter { get; set; }
    public DbSet<Marina> Marina { get; set; }
    public DbSet<Fixture> Fixture { get; set; }
    public DbSet<Expense> Expense { get; set; }
    public DbSet<ExpenseType> ExpenseType { get; set; }
    public DbSet<TenantHistory> TenantHistory { get; set; }
    public DbSet<BoatHistory> BoatHistory { get; set; }
    public DbSet<UserRefreshToken> UserRefreshToken { get; set; }

    // Store Procedures / View / Functions
    //public DbSet<View_GetBoatCrew_Result> ViewGetBoatCrew { get; set; }
    //public DbSet<SP_GetExpense_Result> SP_Expense { get; set; }
  }
}

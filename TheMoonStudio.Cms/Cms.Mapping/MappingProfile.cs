using AutoMapper;
using Cms.Data.Entity;
using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Tenant, TenantViewModel>();
      CreateMap<TenantViewModel, Tenant>();

      CreateMap<TenantHistory, TenantHistoryViewModel>();
      CreateMap<TenantHistoryViewModel, TenantHistory>();

      CreateMap<Company, CompanyViewModel>();
      CreateMap<CompanyViewModel, Company>();

      CreateMap<User, UserViewModel>();
      CreateMap<UserViewModel, User>();

      CreateMap<UserType, UserTypeViewModel>();
      CreateMap<UserTypeViewModel, UserType>();

      CreateMap<Boat, BoatViewModel>();
      CreateMap<BoatViewModel, Boat>();

      CreateMap<BoatHistory, BoatHistoryViewModel>();
      CreateMap<BoatHistoryViewModel, BoatHistory>();

      CreateMap<BoatCrew, BoatCrewViewModel>();
      CreateMap<BoatCrewViewModel, BoatCrew>();

      CreateMap<Crew, CrewViewModel>();
      CreateMap<CrewViewModel, Crew>();

      CreateMap<Fixture, FixtureViewModel>();
      CreateMap<FixtureViewModel, Fixture>();

      CreateMap<Charter, CharterViewModel>();
      CreateMap<CharterViewModel, Charter>();

      CreateMap<Marina, MarinaViewModel>();
      CreateMap<MarinaViewModel, Marina>();;

      CreateMap<Expense, ExpenseViewModel>();
      CreateMap<ExpenseViewModel, Expense>();

      CreateMap<ExpenseType, ExpenseTypeViewModel>();
      CreateMap<ExpenseTypeViewModel, ExpenseType>();

      CreateMap<Settings, SettingsViewModel>();
      CreateMap<SettingsViewModel, Settings>();

      CreateMap<UserRefreshToken, UserRefreshTokenViewModel>();
      CreateMap<UserRefreshTokenViewModel, UserRefreshToken>();
    }
  }
}

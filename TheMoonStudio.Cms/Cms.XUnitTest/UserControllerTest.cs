using Cms.Model.ViewModels;
using Cms.Repository.EntityFramework;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cms.XUnitTest
{
  public class UserControllerTest
  {
    #region BaseInitialize
    IUserService _service;
    IUnitOfWork _uof;
    //UserController _controller;

    public UserControllerTest()
    {
      //_uof = new UnitOfWork();
      _service = new UserService(_uof, AutomapperSingleton.Mapper);
      //_controller = new UserController(_service);
    }
    #endregion


    //public IEnumerable<UserViewModel> GetAllItems()
    //{
    //  return _controller.;
    //}

    //public ShoppingItem Add(ShoppingItem newItem)
    //{
    //  newItem.Id = Guid.NewGuid();
    //  _shoppingCart.Add(newItem);
    //  return newItem;
    //}
  }
}

using AutoMapper;
using AutoMapper.Configuration;
using Cms.Data.Entity;
using Cms.Mapping;
using Cms.Model.ViewModels;
using Cms.Repository.Configuration;
using Cms.Repository.EntityFramework;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service;
using Cms.Service.Interface;
using Cms.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cms.XUnitTest
{
  public class AccountControllerTest
  {
    #region BaseInitialize
    IUserService _service;
    IUnitOfWork _uof;
    AccountController _controller;

    public AccountControllerTest()
    {
      //_uof = new UnitOfWork();
      _service = new UserService(_uof, AutomapperSingleton.Mapper);
      _controller = new AccountController(_service);
    }
    #endregion

    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
      // Act
      var okResult = _controller.Ok();

      // Assert
      Assert.IsType<OkObjectResult>(okResult.StatusCode);
    }

    public string Test()
    {
      return _controller.Test();
    }

    public string TestJWT()
    {
      return _controller.TestJWT();
    }
  }
}

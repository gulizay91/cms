﻿using AutoMapper;
using Cms.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.XUnitTest
{
  public class AutomapperSingleton
  {
    private static IMapper _mapper;
    public static IMapper Mapper
    {
      get
      {
        if (_mapper == null)
        {
          // Auto Mapper Configurations
          var mappingConfig = new MapperConfiguration(mc =>
          {
            mc.AddProfile(new MappingProfile());
          });
          IMapper mapper = mappingConfig.CreateMapper();
          _mapper = mapper;
        }
        return _mapper;
      }
    }
  }
}

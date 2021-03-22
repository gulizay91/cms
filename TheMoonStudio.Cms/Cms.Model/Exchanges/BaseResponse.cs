using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class BaseResponse
  {
    public BaseResponse()
    {
      this.ResultCode = 200;
      this.IsSucceed = true;
      this.Message = "İşlem başarılı bir şekilde gerçekleşmiştir.";
    }

    public void Fail(int resultCode, string message)
    {
      IsSucceed = false;
      ResultCode = resultCode;
      Message = message;
    }

    public bool IsSucceed { get; set; }
    public string Message { get; set; }
    public int ResultCode { get; set; }
  }
}

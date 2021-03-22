using AutoMapper;
using Cms.Mail;
using Cms.Model.ViewModels;
using Cms.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cms.Service
{
  public class BaseService
  {
    protected readonly IUnitOfWork _uof;
    protected readonly IMapper _mapper;

    public BaseService(IUnitOfWork uof, IMapper mapper)
    {
      _uof = uof;
      _mapper = mapper;
    }

    #region  ExceptionHandling

    protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func, string errorText = null) where T : class
    {
      try
      {
        var result = func.Invoke();

        return result;
      }
      catch (Exception ex)
      {
        ex.Data.Add("errorText-business", errorText);
        //NLogLogger.Log(ex, "APPLICATION", LogPriorityEnum.High);

        if (string.IsNullOrEmpty(errorText))
          errorText = "Yapılan işlem sırasında hata oluştu.";
        System.Type type = typeof(T);//aynı tip oluşturulur.
        ConstructorInfo magicConstructor = type.GetConstructor(System.Type.EmptyTypes);//constructure oluşturulur.
        object magicClassObject = magicConstructor.Invoke(new object[] { });//sınıf oluşturulur.
        MethodInfo methodInfo = type.GetMethod("Fail");//oluşturulan sınıfın Fail metodu bulunur.
        methodInfo.Invoke(magicClassObject, new object[] { 500, ex.HelpLink == "CustomException" ? ex.Message : errorText });//ilgili metodu gelen parametrelerle çağırırız.

        return magicClassObject as T;
      }
    }

    protected void ExecuteWithExceptionHandledOperation(Action action)
    {
      try
      {
        action.Invoke();
      }
      catch (Exception ex)
      {
        //NLogLogger.Log(ex, "BUSINESS", LogPriorityEnum.High);
      }
    }

    #endregion

    public bool SendMail(MailSettingModel mail, UserViewModel user)
    {
      var settings = _uof.SettingsRepository.GetAll(r => r.IsActive && r.TenantId == user.Company.TenantId && r.CompanyId == user.CompanyId).ToList();
      if (settings != null)
      {
        if (settings.Any(r => r.Key == "SMTP_From") && !string.IsNullOrEmpty(settings.Find(r => r.Key == "SMTP_From").Value))
          mail.SMTP_From = settings.Find(r => r.Key == "SMTP_From")?.Value;
        if (settings.Any(r => r.Key == "SMTP_Host") && !string.IsNullOrEmpty(settings.Find(r => r.Key == "SMTP_Host").Value))
          mail.SMTP_Host = settings.Find(r => r.Key == "SMTP_Host")?.Value;
        if (settings.Any(r => r.Key == "SMTP_Port") && !string.IsNullOrEmpty(settings.Find(r => r.Key == "SMTP_Port").Value))
          mail.SMTP_Port = Int32.Parse(settings.Find(r => r.Key == "SMTP_Port").Value);
        if (settings.Any(r => r.Key == "SMTP_Username") && !string.IsNullOrEmpty(settings.Find(r => r.Key == "SMTP_Username").Value))
          mail.SMTP_Username = settings.Find(r => r.Key == "SMTP_Username").Value;
        if (settings.Any(r => r.Key == "SMTP_Password") && !string.IsNullOrEmpty(settings.Find(r => r.Key == "SMTP_Password").Value))
          mail.SMTP_Password = settings.Find(r => r.Key == "SMTP_Password").Value;
      }

      return EMailService.SendEmail(mail);
    }

  }
}

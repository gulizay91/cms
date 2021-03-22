using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Cms.Mail
{
  public class EMailService
  {
    //public static bool SendEmail(string subject, string body, List<string> to, string from = "", List<string> bcc = null, List<string> cc = null)
    public static bool SendEmail(MailSettingModel setting)
    {
      try
      {
        MailMessage message = new MailMessage();

        if (setting.From == "")
          setting.From = setting.SMTP_From;//ConfigurationManager.AppSettings["SMTP.From"];

        message.From = new MailAddress(setting.From);

        setting.To.ForEach(t =>
        {
          message.To.Add(new MailAddress(t));
        });

        if (setting.Bcc != null)
        {
          foreach (string address in setting.Bcc)
          {
            if (!String.IsNullOrEmpty(address))
              message.Bcc.Add(address);
          }
        }

        if (setting.Cc != null)
        {
          foreach (string address in setting.Cc)
          {
            if (!String.IsNullOrEmpty(address))
              message.CC.Add(address);
          }
        }

        message.Subject = setting.Subject;
        message.Body = setting.Body;
        message.IsBodyHtml = true;

        SmtpClient smtpClient = new SmtpClient
        {
          Credentials = new NetworkCredential { UserName = setting.SMTP_Username, Password = setting.SMTP_Password },
          Host = setting.SMTP_Host,
          Port = setting.SMTP_Port,
          EnableSsl = true
        };

        smtpClient.Send(message);

        return true;
      }
      catch (Exception ex)
      {
        // TODO : Logger eklenecek
        return false;
      }
    }

  }
}

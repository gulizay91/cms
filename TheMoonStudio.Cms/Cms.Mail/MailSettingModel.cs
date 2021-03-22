using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Mail
{
  public class MailSettingModel
  {
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> To { get; set; }
    public string From { get; set; }
    public List<string> Cc { get; set; }
    public List<string> Bcc { get; set; }

    // SMTP
    public string SMTP_From { get; set; }
    public string SMTP_Host { get; set; }
    public string SMTP_Username { get; set; }
    public string SMTP_Password { get; set; }
    public int SMTP_Port { get; set; }
  }
}

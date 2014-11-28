using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WangFramework.Email;

namespace W3WGame.Ka.Controller.test
{
    public class testController:BaseController
    {
        public ActionResult index()
        {
            MailInfo info = new MailInfo();
            EmailUtility sendemail = new EmailUtility();
            sendemail.Send(new MailInfo
                               {
                                   ToEmailAddress = {"361337917@qq.com"},
                                   ToCcEmailAddress = {"196317883@qq.com"},
                                   //FromEmailAddress = string.Empty,
                                   //FromEmailPassword = string.Empty,
                                   EmailSubject = "用163测试发送邮件",
                                   EmailBody = "邮件主体",
                                   EmailPersonName = "发件人姓名wang",
                                   //EmailHostName = string.Empty,
                                   EmailPriority = EmailPriorityEnum.High,
                                   EmailPort =25,
                                   IsBodyHtml = true,
                                   EncodingType = Encoding.UTF8,


                               });
            return Content("已经发送");
        }
    }
}

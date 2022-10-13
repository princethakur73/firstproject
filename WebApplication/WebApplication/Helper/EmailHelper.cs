using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace WebApplication.Helper
{
    public static class EmailHelper
    {
        public static bool SendEmail(string Contact, string Name, string Description)
        {
            try
            {
                var senderEmail = new MailAddress("noreply@hvmsrsecschool.org", "HVM Support");
                var password = "Welcome@007";

                MailDefinition md = new MailDefinition
                {
                    From = "noreply@hvmsrsecschool.org",
                    IsBodyHtml = true,
                    Subject = string.Format("Contact {0}", Name),
                    Priority = MailPriority.High
                };

                ListDictionary replacements = new ListDictionary
                {
                    { "{name}", Name },
                    { "{contact}", Contact },
                    { "{description}", Description }
                };

                string body = "<div>Hello <br>Please check the following detail of the user who visit over the site.<br>" +
                    "Name: "+ Name +"<br>" +
                    "Conatct: " + Contact + "<br>" +
                    "Description: " + Description + "</div>";

                MailMessage msg = md.CreateMailMessage("hvmconvent@gmail.com", replacements, body, new System.Web.UI.Control());

                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = "mail.hvmsrsecschool.org";
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential(senderEmail.Address, password);
                    client.Send(msg);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
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
                var senderEmail = new MailAddress("hvmconvent@gmail.com", "HVM Support");
                var password = "HVM@2018";

                MailDefinition md = new MailDefinition
                {
                    From = "hvmconvent@gmail.com",
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
                    "Name: {name}<br>" +
                    "Conatct: {contact}<br>" +
                    "Description: {description}</div>";

                MailMessage msg = md.CreateMailMessage("hvmconvent@gmail.com", replacements, body, new System.Web.UI.Control());

                using(SmtpClient client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail.Address, password);
                    client.Send(msg);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
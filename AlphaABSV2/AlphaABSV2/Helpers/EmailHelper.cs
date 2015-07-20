using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.IO;
using AlphaABSV2.Helpers;

namespace AlphaABSV2.Helpers
{
    public static class EmailHelper
    {
        public static string SiteURL = ConfigurationManager.AppSettings["SiteUrl"];

        public static string ReturnMailTemplate(int companyRef)
        {
            var relativePathToContent = "";
            var txtMsg = "";

            switch(companyRef)
            {
                case (int)SystemOwner.Jungle:
                        relativePathToContent = "~/Content/emails/EmailTemplateOne.html";
                        txtMsg = ReadTXTFile(HttpContext.Current.Server.MapPath(relativePathToContent));
                        return txtMsg;
                case (int)SystemOwner.Mayhem:
                        relativePathToContent = "~/Content/emails/EmailTemplateOne.html";
                        txtMsg = ReadTXTFile(HttpContext.Current.Server.MapPath(relativePathToContent));
                        return txtMsg;
                case (int)SystemOwner.Paradise:
                        relativePathToContent = "~/Content/emails/EmailTemplateOne.html";
                        txtMsg = ReadTXTFile(HttpContext.Current.Server.MapPath(relativePathToContent));
                        return txtMsg;
                case (int)SystemOwner.Bunker:
                        relativePathToContent = "~/Content/emails/EmailTemplateOne.html";
                        txtMsg = ReadTXTFile(HttpContext.Current.Server.MapPath(relativePathToContent));
                        return txtMsg;
                    
            }
            //var subject = "You have been Invited to BoomWriter by a friend";
            //var relativePathToContent = "~/Content/emails/EmailTemplateOne.html";
            //var txtMsg = ReadTXTFile(HttpContext.Current.Server.MapPath(relativePathToContent));
            
            //var mail = new MailMessage();
            //mail.To.Add(new MailAddress(mailAddressTo));
            //mail.From = new MailAddress(ConfigurationManager.AppSettings["SystemEmail"]);
            //mail.Subject = subject;

            //Replace the key fields 
            //txtMsg = txtMsg.Replace("[Name]", name);

            //mail.Body = txtMsg;
            //mail.IsBodyHtml = true;

            //try
            //{
            //    SendMail(mail);
            //}
            //catch (Exception)
            //{

            //}

            return txtMsg;

        }

        private static string ReadTXTFile(string Path)
        {
            //var counter = 0;
            string line;

            var sb = new StringBuilder();
            var file = new System.IO.StreamReader(Path);

            while ((line = file.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            file.Close();

            return sb.ToString();

        }

        public static void SendMail(MailMessage mailMessage)
        {
            string isMachine = ConfigurationManager.AppSettings[null];
            try
            {
                //todo check if recipient is not on any of the unsub lists
               
                    string authEmail = mailMessage.To.First().Address;
                    var smtp = new SmtpClient();
                    
                        if (isMachine == "True")
                        {
                            string origEmail = mailMessage.To.ToString();
                            mailMessage.To.Clear();
                            mailMessage.To.Add(ConfigurationManager.AppSettings[null]);
                            try
                            {
                               
                                    smtp.Send(mailMessage);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            //mailMessage.Bcc.Add("boomtester@gmail.com");
                            try
                            {
                                
                                smtp.Send(mailMessage);
                                
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }

                    

              
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
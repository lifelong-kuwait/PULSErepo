// ***********************************************************************
// Assembly         : TMS.Common
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="EmailSend.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Net.Security;
namespace TMS.Common
{
    /// <summary>
    /// Class EmailSend.
    /// </summary>
    public static class EmailSend
    {
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="recievers">The recievers.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="IsAttachment">if set to <c>true</c> [is attachment].</param>
        /// <param name="AttachmentPath">The attachment path.</param>
        /// <param name="serverpath">The serverpath.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SendMail(string recievers, string cc, string subject, string body, bool IsAttachment, string AttachmentPath, string serverpath)
        {
            var fromEmail = ConfigurationManager.AppSettings["FromEmail"];
            var fromPassword = ConfigurationManager.AppSettings["FromPassword"];
            var host = ConfigurationManager.AppSettings["smtpHost"];

            var smtp = new SmtpClient
            {
                Host = host,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };
            try
            {
                if (recievers.EndsWith(","))
                {
                    recievers = recievers.Remove(recievers.Length - 1);
                }
                using (var mail = new MailMessage(fromEmail, recievers))
                {

                    if (IsAttachment)
                    {
                        foreach (var Attachment in AttachmentPath.Split(','))
                        {
                            if (Attachment.Equals(string.Empty))
                            {
                                continue;
                            }
                            var attachment = new Attachment(serverpath + Attachment);
                            ContentDisposition disposition = attachment.ContentDisposition;
                            disposition.CreationDate = File.GetCreationTime(serverpath + Attachment);
                            disposition.ModificationDate = File.GetLastWriteTime(serverpath + Attachment);
                            disposition.ReadDate = File.GetLastAccessTime(serverpath + Attachment);

                            string currentFile = Attachment.Contains("_")
                                                     ? Attachment.Substring(Attachment.LastIndexOf("_") + 1)
                                                     : Attachment.Substring(Attachment.LastIndexOf(@"/") + 1);

                            disposition.FileName = currentFile;
                            disposition.Size = new FileInfo(serverpath + Attachment).Length;
                            disposition.DispositionType = DispositionTypeNames.Attachment;
                            mail.Attachments.Add(attachment);
                        }
                    }
                    if (!String.IsNullOrEmpty(cc))
                    {
                        mail.CC.Add(cc);
                    }

                    mail.IsBodyHtml = true;
                    mail.Subject = subject;
                    mail.Body = body;
                    ServicePointManager.ServerCertificateValidationCallback =
                        delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                WriteEventLog(ex.Message);
                return false;
            }
            finally
            {
                smtp = null;
            }
        }


        /// <summary>
        /// Writes the event log.
        /// </summary>
        /// <param name="_Str">The string.</param>
        public static void WriteEventLog(string _Str)
        {
            try
            {
                if (!Directory.Exists(ConfigurationManager.AppSettings["tmsEventLogsDirectory"]))
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["tmsEventLogsDirectory"]);

                File.AppendAllText(ConfigurationManager.AppSettings["tmsEventLogsFileName"], DateTime.Now + "\r\n" + _Str + "\r\n");

                //EventLog _e = new EventLog();
                EventLog _e = new EventLog("tmsLog");
                _e.Source = "Warninglog";

     

                _e.WriteEntry(_Str);
            }
            catch (Exception ex)
            {
            }
        }

        
    }
}

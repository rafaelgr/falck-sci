using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;


namespace DosimetriaExtranet
{
    public class EMail
    {
        MailMessage correo = new MailMessage();
        SmtpClient smtp;

        public EMail(string mail)
        {
            correo.From = new MailAddress(ConfigurationSettings.AppSettings["mail_address"]);
            correo.To.Add(mail);
            correo.Bcc.Add(ConfigurationSettings.AppSettings["mail_address"]);
        }

        private void Servidor()
        {
            smtp = new SmtpClient(ConfigurationSettings.AppSettings["mail_server"]);
            smtp.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["mail_usr"], ConfigurationSettings.AppSettings["mail_pass"]);
            smtp.Port = int.Parse(ConfigurationSettings.AppSettings["mail_port"]);

            smtp.EnableSsl = bool.Parse(ConfigurationSettings.AppSettings["mail_ssl"]);
        }
        public void MandarMail(string asunto, string cuerpo)
        {
            correo.Subject = asunto;
            correo.Body = cuerpo;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            Servidor();
            smtp.Send(correo);
        }
        public void MandarMail(string asunto, string cuerpo, string fichero)
        {
            correo.Subject = asunto;
            correo.Body = cuerpo;
            Attachment fic = new Attachment(fichero);
            correo.Attachments.Add(fic);
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            Servidor();
            smtp.Send(correo);
        }
    }
}
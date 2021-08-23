// @author duyenthai

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public class MailWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MailWorker));
        private bool _running = true;

        private string email;
        private string fileName;
        private DhSmtpMail credential;
        
        public MailWorker(string name) : base(name)
        {
        }

        public MailWorker(string name, string email, string fileName) : base(name)
        {
            this.email = email;
            this.fileName = fileName;
        }

        public DhSmtpMail Credential
        {
            get => credential;
            set => credential = value;
        }

        protected override void RunThread()
        {
            if (_running)
            {
                RunWorker();
            }
        }

        protected override void Stop()
        {
            _running = false;
        }

        public void RunWorker()
        {
            if (credential == null)
            {
                return;
            }
            var fileStream = new FileStream(fileName, FileMode.Open);
            try
            {
                var smtpClient = new SmtpClient();
                smtpClient.Host = credential.Host;
                smtpClient.Port = credential.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(credential.Account, credential.Password);
                smtpClient.EnableSsl = true;

                var mail = new MailMessage();
                mail.From = new MailAddress("noreply@xmail.com");
                mail.To.Add(email);
                mail.Attachments.Add(new Attachment(fileStream, Path.GetFileName(fileStream.Name), "text/excel"));
                mail.Body = "Export excel file";
                mail.Subject = "League statistic";
                smtpClient.Send(mail);
                MessageBox.Show($"Sent mail success to {email}, please check your mail for more information", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.Error("Error send mail, ", ex);
                MessageBox.Show(ex.Message, "Error send mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
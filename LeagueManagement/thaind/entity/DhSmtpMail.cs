// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_smtp_mail")]
    public class DhSmtpMail
    {
        private int id;
        private string account;
        private string password;
        private string host;
        private int port;
        private bool active;

        public DhSmtpMail()
        {
        }

        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [Column(Name = "account")]
        public string Account
        {
            get => account;
            set => account = value;
        }

        [Column(Name = "password")]
        public string Password
        {
            get => password;
            set => password = value;
        }

        [Column(Name = "host")]
        public string Host
        {
            get => host;
            set => host = value;
        }

        [Column(Name = "port")]
        public int Port
        {
            get => port;
            set => port = value;
        }

        [Column(Name = "active")]
        public bool Active
        {
            get => active;
            set => active = value;
        }
    }
}
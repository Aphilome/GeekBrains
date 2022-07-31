namespace Catalog.Configs
{
    public class SmtpCredentials
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string HostPassword { get; set; }

        public string FromNick { get; set; }

        public string FromMail { get; set; }

        public string ToNick { get; set; }

        public string ToMail { get; set; }
    }
}

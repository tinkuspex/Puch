namespace Configuration
{
    public class AppSettings
    {
        public IEnumerable<string> ConnectionString { get; set; }
        public string Token { get; set; }
        public Polly Polly { get; set; }
        public IEnumerable<string> PathIgnore { get; set; }
        public SettingEndPoint SettingEndPoint { get; set; }
        public PushNotification PushNotification { get; set; }
        public SettingSAP SettingSAP { get; set; }
    }

    public class ConnectionString
    { 
        public string Con { get; set; }
    }
public class Polly
    {
        public int Intent { get; set; }
        public int Delay { get; set; }
    }
    public class SettingEndPoint
    {
        public string ClientMicroservice { get; set; }
        public string ProductMicroservice { get; set; }
        public string OrderMicroservice { get; set; }
        public string GroupAccountCollected { get; set; }
        public string PaidStatement { get; set; }
    }

    public class PushNotification
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }

    public class SettingSAP
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}

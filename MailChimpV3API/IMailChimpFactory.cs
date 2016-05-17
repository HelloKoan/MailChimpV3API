namespace MailChimpV3API
{
    public interface IMailChimpFactory
    {
        IMailChimp Create(string apiKey);
        IMailChimp Create(string accessToken, string dataCentrePrefix);
        IMailChimp Create(IMailChimpConnector connector);
    }
}

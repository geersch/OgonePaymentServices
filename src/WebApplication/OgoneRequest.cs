using System;
using System.Configuration;

namespace WebApplication
{
    public class OgoneRequest
    {
        public OgoneRequest()
        {
            OgoneUrl = ConfigurationManager.AppSettings["Ogone_Url"];
            Psid = ConfigurationManager.AppSettings["Ogone_PSID"];
            ShaKey = ConfigurationManager.AppSettings["Ogone_SHA1_IN"];
            Currency = ConfigurationManager.AppSettings["Ogone_Currency"];
            Language = ConfigurationManager.AppSettings["Ogone_Language"];
            AcceptUrl = ConfigurationManager.AppSettings["Ogone_AcceptUrl"];
            ExceptionUrl = ConfigurationManager.AppSettings["Ogone_ExceptionUrl"];
            CancellationUrl = ConfigurationManager.AppSettings["Ogone_CancellationUrl"];
        }

        public void RequestPayment(string reference, double amount, string email)
        {
            // Multiply by one hundred and round to zero decimals
            amount = Math.Round(amount * 100, 0);

            RemotePost post = new RemotePost { Url = this.OgoneUrl };
            post.Add("pspid", this.Psid);
            post.Add("orderid", reference);
            post.Add("amount", amount.ToString());
            post.Add("currency", this.Currency);
            post.Add("language", this.Language);
            post.Add("email", email);

            // Hash
            post.Add("SHASign", Ogone.GenerateHash(
                reference + amount + this.Currency + 
                this.Psid + this.ShaKey));

            // Redirection URLs
            post.Add("accepturl", this.AcceptUrl);
            post.Add("exceptionurl", this.ExceptionUrl);
            post.Add("cancelurl", this.CancellationUrl);

            post.Post();
        }

        public string OgoneUrl { get; set; }
        public string Psid { get; set; }
        public string ShaKey { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public string AcceptUrl { get; set; }
        public string ExceptionUrl { get; set; }
        public string CancellationUrl { get; set; }
    }
}

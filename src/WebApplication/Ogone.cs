using System.Security.Cryptography;
using System.Text;

namespace WebApplication
{
    public static class Ogone
    {
        public static string GenerateHash(string input)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(input);
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                string temp = hash[i].ToString("X2");
                if (temp.Length == 1)
                {
                    temp = "0" + temp;
                }
                result.Append(temp);
            }
            return result.ToString();
        }

        public static bool IsPaymentStatusValid(OgonePaymentStatus status)
        {
            return (status == OgonePaymentStatus.OrderStored) ||
                   (status == OgonePaymentStatus.WaitingClientPayment) ||
                   (status == OgonePaymentStatus.Authorized) ||
                   (status == OgonePaymentStatus.AuthorizationWaiting) ||
                   (status == OgonePaymentStatus.PaymentRequested) ||
                   (status == OgonePaymentStatus.PaymentProcessing);
        }
    }
}

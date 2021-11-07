using System;
using System.Configuration;
using System.Web;

namespace WebApplication
{
    public static class OgoneResponse
    {
        public static string OrderId { get { return HttpContext.Current.Request["orderid"]; } }
        public static string Currency { get { return HttpContext.Current.Request["currency"]; } }
        public static string Amount { get { return HttpContext.Current.Request["amount"]; } }
        public static string PaymentMethod { get { return HttpContext.Current.Request["pm"]; } }
        public static string AcceptanceCode { get { return HttpContext.Current.Request["acceptance"]; } }
        public static string CardNumber { get { return HttpContext.Current.Request["cardno"]; } }
        public static string PaymentId { get { return HttpContext.Current.Request["payid"]; } }
        public static string NcError { get { return HttpContext.Current.Request["ncerror"]; } }
        public static string Brand { get { return HttpContext.Current.Request["brand"]; } }
        public static string ShaSign { get { return HttpContext.Current.Request["shasign"]; } }

        public static OgonePaymentStatus Status
        {
            get
            {
                int status;
                if (!Int32.TryParse(HttpContext.Current.Request["status"], out status))
                {
                    return OgonePaymentStatus.IncompleteOrInvalid;
                }
                return (OgonePaymentStatus)status;
            }
        }

        public static bool IsShaSignValid
        {
            get
            {
                string key = OrderId + Currency + Amount + PaymentMethod + AcceptanceCode + (int)Status + CardNumber +
                             PaymentId + NcError + Brand + ConfigurationManager.AppSettings["Ogone_SHA1_OUT"];
                return ShaSign == Ogone.GenerateHash(key);
            }
        }
    }
}

using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class PaymentAccepted : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OgonePaymentStatus status = OgoneResponse.Status;

            // Invalid Sha key returned from Ogone? 
            bool paymentSucceeded = OgoneResponse.IsShaSignValid && Ogone.IsPaymentStatusValid(status);

            if (paymentSucceeded)
            {
                LabelStatus.Text = "Payment accepted";
            }
            else
            {
                LabelStatus.Text = "Payment invalid";
            }
        }
    }
}

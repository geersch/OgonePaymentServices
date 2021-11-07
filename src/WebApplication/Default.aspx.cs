using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class _Default : Page
    {
        // Ogone limits the reference to maximum 30 characters
        protected string _reference = Guid.NewGuid().ToString().Substring(0, 30);

        protected void Page_Load(object sender, EventArgs e)
        {
            labelReference.Text = _reference;
        }

        protected void StartPayment_Click(object sender, EventArgs e)
        {
            const double amount = 19.99;
            const string customerEmail = "test@example.com";

            // Persist order to database 
            // ...

            OgoneRequest ogoneRequest = new OgoneRequest();
            ogoneRequest.RequestPayment(this._reference, amount, customerEmail);

            // Clear shopping cart
            // ...
        }
    }
}

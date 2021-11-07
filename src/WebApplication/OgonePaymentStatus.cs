namespace WebApplication
{
    public enum OgonePaymentStatus
    {
        IncompleteOrInvalid = 0,
        OrderStored = 4,
        WaitingClientPayment = 41,
        Authorized = 5,
        AuthorizationWaiting = 51,
        RefundPending = 81,
        PaymentRequested = 9,
        PaymentProcessing = 91
        //...etc.
    }
}

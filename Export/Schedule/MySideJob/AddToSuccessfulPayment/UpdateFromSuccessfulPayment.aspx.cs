using System;
using System.Web.UI;

public partial class UpdateFromProfessionalSuccesfulPayement : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Upon Payment Success;
        //PDT or IPN
        CustomerUpdatePaymentForTimeUpandResponseDelayRountine();
        ProfessionalUpdatePaymentForTimeUpandResponseDelayRountine();
    }
    private void CustomerUpdatePaymentForTimeUpandResponseDelayRountine()
    {
        const int projectid = 2;
        const int payerid = 3;
        const string payerole = "CUS";
        PaymentProcessUpdate.PaymentUpdateProcedure(projectid, payerid, payerole);
    }

    private void ProfessionalUpdatePaymentForTimeUpandResponseDelayRountine()
    {
        const int projectid = 2;
        const int payerid = 3;
        const string payerole = "PRO";
        PaymentProcessUpdate.PaymentUpdateProcedure(projectid, payerid, payerole);
    }











}
// This example sets up an endpoint using the ASP.NET MVC framework.
// Watch this video to get started: https://youtu.be/2-mMOB8MhmE.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace StripeApi.Controllers
{
  public class PaymentsController : Controller
  {
    

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    public IActionResult Charge(string stripeEmail,string stripeToken){
      var customers = new CustomerService();
      var charges = new ChargeService();
      var customer = customers.Create(new CustomerCreateOptions{
        Email = stripeEmail,
        Source = stripeToken
        
      });
      

      var charge = charges.Create(new ChargeCreateOptions{
        Amount = 500,
        Description = "Test PaymentCharge",
        Currency="usd",
        Customer = customer.Id,
        ReceiptEmail = stripeEmail
      });
      
      if (charge.Status == "succeeded"){
        string BalanceTransactionId = charge.BalanceTransactionId;
        return View();
      }else{

      }
      return View();
    }

    // [HttpPost("create-checkout-session")]
    // public ActionResult CreateCheckoutSession()
    // {
    //   var options = new SessionCreateOptions
    //   {
    //     PaymentMethodTypes = new List<string>
    //     {
    //       "card",
    //     },
    //     LineItems = new List<SessionLineItemOptions>
    //     {
    //       new SessionLineItemOptions
    //       {
    //         PriceData = new SessionLineItemPriceDataOptions
    //         {
    //           UnitAmount = 2000,
    //           Currency = "usd",
    //           ProductData = new SessionLineItemPriceDataProductDataOptions
    //           {
    //             Name = "T-shirt",
    //           },

    //         },
    //         Quantity = 1,
    //       },
    //     },
    //     Mode = "payment",
    //     SuccessUrl = "https://example.com/success",
    //     CancelUrl = "https://example.com/cancel",
    //   };

    //   var service = new SessionService();
    //   Session session = service.Create(options);

    //   return Json(new { id = session.Id });
    // }
  }
}
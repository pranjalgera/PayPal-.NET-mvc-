using paypal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.paypal.sdk.profiles;
using com.paypal.sdk.util;
using com.paypal.sdk.services;

namespace paypal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaypalPost(PaypalViewModel obj)
        {


            ViewBag.actionURl = ConfigurationManager.AppSettings["PayPalPostUrl"];
            obj.business = ConfigurationManager.AppSettings["business_email"];
            obj.notify_url = ConfigurationManager.AppSettings["SiteURL"] + "Home/PaypalIPN";
            obj.cancel_return = ConfigurationManager.AppSettings["SiteURL"] + "Home/PaypalFail";
            obj.@return = ConfigurationManager.AppSettings["SiteURL"] + "Home/PaypalSuccess";
            obj.cmd = ConfigurationManager.AppSettings["cmd"];
            obj.no_shipping = ConfigurationManager.AppSettings["no_shipping"];
            obj.upload = ConfigurationManager.AppSettings["upload"];
            obj.currency_code = ConfigurationManager.AppSettings["currency_code"];
            obj.rm = ConfigurationManager.AppSettings["rm"];
            obj.item_name = "order";
            //invoice number should be different in every transaction
            obj.invoice = "5888965";
            obj.amount = "100";
            return View(obj);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PaypalSuccess()
        {
            return View();
        }

        public ActionResult PaypalFail()
        {
            return View();
        }

        public ActionResult PaypalIPN()
        {
            return View();
        }
        public string GetTransactionDetailsCode(string transactionID)
        {
            transactionID = "5DG937217W423530M";
            NVPCallerServices caller = new NVPCallerServices();
            IAPIProfile profile = ProfileFactory.createSignatureAPIProfile();
            /*
             WARNING: Do not embed plaintext credentials in your application code.
             Doing so is insecure and against best practices.
             Your API credentials must be handled securely. Please consider
             encrypting them for use in any production environment, and ensure
             that only authorized individuals may view or modify them.
             */

            // Set up your API credentials, PayPal end point, API operation and version.
            profile.APIUsername = "your email";
            profile.APIPassword = "password";
            profile.APISignature = "signature";
            profile.Environment = "sandbox";
            caller.APIProfile = profile;

            NVPCodec encoder = new NVPCodec();
            encoder["VERSION"] = "51.0";
            encoder["METHOD"] = "GetTransactionDetails";

            // Add request-specific fields to the request.
            encoder["TRANSACTIONID"] = transactionID;

            // Execute the API operation and obtain the response.
            string pStrrequestforNvp = encoder.Encode();
            string pStresponsenvp = caller.Call(pStrrequestforNvp);

            NVPCodec decoder = new NVPCodec();
            decoder.Decode(pStresponsenvp);
            return decoder["ACK"];
        }

    }
}
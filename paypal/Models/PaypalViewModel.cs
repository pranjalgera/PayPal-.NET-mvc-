using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paypal.Models
{
    public class PaypalViewModel
    {
        public int ID { get; set; }
        public string cmd { get; set; }
        public string notify_url { get; set; }
        public string business { get; set; }
        public string amount { get; set; }
        public string cancel_return { get; set; }
        public string no_shipping { get; set; }
        public string upload { get; set; }
        public string currency_code { get; set; }
        public string item_name { get; set; }
        public string custom { get; set; }
        public string login_email { get; set; }
        public string item_number { get; set; }
        public string @return { get; set; }
        public string rm { get; set; }
        public string invoice { get; set; }
        public Nullable<long> OperatorId { get; set; }
    }

    public class PaypalNotify
    {
        public string PCNDisplayId { get; set; }
        public string TransactionID { get; set; }
        public string TransactionStatus { get; set; }
        public decimal TranactionAmount { get; set; }
        public string msg { get; set; }
    }
}
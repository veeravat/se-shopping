using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingModule.DTOS
{
    public class CartDto : ICartDto
    {
        public int productID { get; set; }
        public int qty { get; set; }
    }
    public class PaymentDto : IPaymentDto
    {
        public string cardname { get; set; }
        public string cardNumber { get; set; }
        public string expityMonth { get; set; }
        public string expityYear { get; set; }
        public string cvCode { get; set; }
    }
}
﻿using BusinessObjects.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.PayOS
{
    public class CreatePaymentLinkRequest
    {
        public int bookingId { get; set; }
        public string returnUrl { get; set; }
        public string cancelUrl { get; set; }

    }
}

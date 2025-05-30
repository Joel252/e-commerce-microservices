﻿namespace Microservices.Web.Models
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = null!;
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

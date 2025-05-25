using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.CouponAPI.Models
{
    /// <summary>
    /// Coupon entity.
    /// </summary>
    public class Coupon
    {
        [Key] public int CouponId { get; init; }
        [Required] [MaxLength(10)] public string CouponCode { get; init; } = null!;
        [Required] public double DiscountAmount { get; init; }
        public int MinAmount { get; init; }
        public DateTime LastUpdated { get; init; } = DateTime.Now;
    }
}
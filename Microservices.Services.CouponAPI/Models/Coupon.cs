using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.CouponAPI.Models
{
    /// <summary>
    /// Coupon entity.
    /// </summary>
    public class Coupon
    {
        [Key]
        public int CouponId {  get; set; }
        [Required]
        [MaxLength(10)]
        public string CouponCode { get; set; } = null!;
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}

namespace Microservices.Services.CouponAPI.Models.DTO
{
    /// <summary>
    /// Data transfer object for coupons.
    /// </summary>
    public class CouponDto
    {
        public int CouponId { get; init; }
        public string CouponCode { get; init; } = null!;
        public double DiscountAmount { get; init; }
        public int MinAmount { get; init; }
    }
}
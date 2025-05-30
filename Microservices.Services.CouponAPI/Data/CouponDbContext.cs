﻿using Microservices.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.CouponAPI.Data
{
    public class CouponDbContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "100FF",
                DiscountAmount = 10,
                MinAmount = 20,
                LastUpdated = new DateTime(2025, 3, 1)
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "200FF",
                DiscountAmount = 20,
                MinAmount = 40,
                LastUpdated = new DateTime(2025, 3, 2)
            });
        }
    }
}
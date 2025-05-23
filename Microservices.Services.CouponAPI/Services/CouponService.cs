using AutoMapper;
using Microservices.Services.CouponAPI.Data;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;
using Microservices.Services.CouponAPI.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.CouponAPI.Services
{
    /// <summary>
    /// Service that provides methods for managing coupons in the system.
    /// </summary>
    public class CouponService : ICouponService
    {
        private readonly CouponDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponService"/> class.
        /// </summary>
        /// <param name="context">The database context used to access and manage coupon data.</param>
        /// <param name="mapper">The mapper used to transform data between entities and DTOs.</param>
        public CouponService(CouponDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Asynchronously creates a new coupon and saves it to the database.
        /// </summary>
        /// <param name="couponDto">The data transfer object containing the details of the coupon to be created.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If successful, the <see
        /// cref="ResponseDto.Result"/> property contains the created coupon as a <see cref="CouponDto"/>.  If an error
        /// occurs, <see cref="ResponseDto.IsSuccess"/> is set to <see langword="false"/> and  <see
        /// cref="ResponseDto.Message"/> contains the error message.</returns>
        public async Task<ResponseDto> CreateCouponAsync(CouponDto couponDto)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                await _context.Coupons.AddAsync(coupon);
                await _context.SaveChangesAsync();

                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Deletes a coupon with the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to delete.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If the coupon is successfully deleted,
        /// <see cref="ResponseDto.IsSuccess"/> is <see langword="true"/>  and <see cref="ResponseDto.Result"/> contains
        /// the deleted coupon's details.  If the coupon is not found, <see cref="ResponseDto.IsSuccess"/> is <see
        /// langword="false"/>  and <see cref="ResponseDto.Message"/> contains an error message.</returns>
        public async Task<ResponseDto> DeleteCouponAsync(int id)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == id);
                if (coupon == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Coupon not found.";
                    return response;
                }
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();

                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Retrieves all available coupons from the database.
        /// </summary>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the operation. The <c>Result</c> property will hold an
        /// <see cref="IEnumerable{T}"/> of <see cref="CouponDto"/> objects if the operation succeeds. If the operation
        /// fails, <c>IsSuccess</c> will be <see langword="false"/> and <c>Message</c> will contain the error details.</returns>
        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            var response = new ResponseDto();

            try
            {
                IEnumerable<Coupon> coupons = await _context.Coupons.ToListAsync();
                response.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Retrieves a coupon by its code asynchronously.
        /// </summary>
        /// <param name="code">The coupon code to search for. This parameter is case-insensitive.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If the coupon is found, the <see
        /// cref="ResponseDto.Result"/> property will contain a <see cref="CouponDto"/> object.  If the coupon is not
        /// found, <see cref="ResponseDto.IsSuccess"/> will be <see langword="false"/> and  <see
        /// cref="ResponseDto.Message"/> will contain an error message.</returns>
        public async Task<ResponseDto> GetCouponByCodeAsync(string code)
        {
            var response = new ResponseDto();

            try             {
                var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode.ToLower() == code.ToLower());
                if (coupon == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Coupon not found.";

                    return response;
                }

                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Retrieves a coupon by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to retrieve. Must be a positive integer.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the coupon details if found, or an error message if the coupon does
        /// not exist. The <see cref="ResponseDto.IsSuccess"/> property will be <see langword="true"/> if the operation
        /// succeeds; otherwise, <see langword="false"/>.</returns>
        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == id);
                if (coupon == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Coupon not found.";

                    return response;
                }

                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Updates an existing coupon in the database with the provided details.
        /// </summary>
        /// <param name="couponDto">The data transfer object containing the updated details of the coupon.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the update operation.  If successful, the <see
        /// cref="ResponseDto.Result"/> property contains the updated coupon details. If the operation fails, <see
        /// cref="ResponseDto.IsSuccess"/> is <see langword="false"/> and  <see cref="ResponseDto.Message"/> contains
        /// the error message.</returns>
        public async Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Update(coupon);
                await _context.SaveChangesAsync();

                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

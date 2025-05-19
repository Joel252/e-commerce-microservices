using AutoMapper;
using Microservices.Services.CouponAPI.Data;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.CouponAPI.Controllers
{
    /// <summary>
    /// Controller for managing coupon operations in the Microservices Coupon API.
    /// </summary>
    [Route("api/coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly CouponDbContext _context;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CouponApiController"/> class.
        /// </summary>
        /// <param name="context">The database context for coupon operations.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public CouponApiController(CouponDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all coupons from the database.
        /// </summary>
        /// <returns>A ResponseDTO containing a list of all coupons or error information</returns>
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _context.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        /// <summary>
        /// Retrieves a coupon by ID from the database.
        /// </summary>
        /// <param name="id">The unique indentifier of the coupon.</param>
        /// <returns>A ResponseDTO containing the requested coupon or error information.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(c => c.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        /// <summary>
        /// Retrieves a coupon by code from the database.
        /// </summary>
        /// <param name="code">The coupon code to search for (case-insensitive).</param>
        /// <returns>A ResponseDTO containing the matched coupon or error information.</returns>
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetBycode(string code)
        {
            try
            {
                Coupon obj = _context.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        
        /// <summary>
        /// Creates a new coupon in the database.
        /// </summary>
        /// <param name="couponDto">The CouponDTO containing the coupon information.</param>
        /// <returns>A ResponseDTO containing the created coupon or error information.</returns>
        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Add(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Updates an existing coupon in the database.
        /// </summary>
        /// <param name="couponDto">The CouponDTO containing the coupon information.</param>
        /// <returns>A ResponseDTO containing the updated coupon or error information.</returns>
        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _context.Coupons.Update(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        /// <summary>
        /// Deletes a coupon from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon.</param>
        /// <returns>A ResponseDTO containing the deleted coupon or error information.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _context.Coupons.First(c => c.CouponId == id);
                _context.Coupons.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}

using System.Net;
using System.Text;
using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Newtonsoft.Json;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
    /// <summary>
    /// Provides a base implementation for sending HTTP requests while supporting authentication requirements.
    /// </summary>
    /// <remarks>
    /// This service interacts with the underlying HTTP client factory to send requests
    /// and optionally handles token-based authentication based on configured defaults.
    /// </remarks>
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        /// <summary>
        /// Sends an asynchronous request and retrieves a response based on the specified parameters.
        /// </summary>
        /// <param name="requestDto">The request payload encapsulated as a <c>RequestDto</c> object.</param>
        /// <param name="isAuthRequired">A boolean flag indicating whether authentication is required for the request. Default value is <c>true</c>.</param>
        /// <returns>A task that represents the asynchronous operation, returning a <c>ResponseDto</c> object or <c>null</c> if the operation fails.</returns>
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool isAuthRequired = true)
        {
            try
            {
                // Create a new HTTP client using the configured client name
                var client = _httpClientFactory.CreateClient("MicroservicesAPI");

                // Set the request headers
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                if (isAuthRequired)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                // Set the request URI
                message.RequestUri = new Uri(requestDto.Url);

                // Set the request content
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8,
                    "application/json");

                // Set the request method based on the request type 
                switch (requestDto.RequestType)
                {
                    case RequestType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case RequestType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    case RequestType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                // Send the request
                var apiResponse = await client.SendAsync(message);

                // Check if the request was successful and return the response
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDto() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new ResponseDto() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDto() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
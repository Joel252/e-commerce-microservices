using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    /// <summary>
    /// Interface for base service.
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Sends an asynchronous request based on the given parameters and returns a response.
        /// </summary>
        /// <param name="requestDto">The request details containing the necessary parameters such as URL, request type, and data payload.</param>
        /// <param name="isAuthRequired">Specifies whether authentication is required for the request. Defaults to true.</param>
        /// <returns>A task representing the asynchronous operation, with a possible value of <see cref="ResponseDto"/> containing the result, success status, and message.</returns>
        public Task<ResponseDto?> SendAsync(RequestDto requestDto, bool isAuthRequired = true);
    }
}
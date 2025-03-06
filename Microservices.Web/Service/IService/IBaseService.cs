using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface IBaseService
    {
        public Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}

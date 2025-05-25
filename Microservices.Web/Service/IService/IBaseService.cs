using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface IBaseService
    {
        public Task<ResponseDto?> SendAsync(RequestDto requestDTO);
    }
}

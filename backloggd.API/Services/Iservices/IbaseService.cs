using backloggd.MVC.Models;
using backlogged.MVC.Models;

namespace backloggd.API.Services.Iservices
{
    public interface IbaseService
    {
        public Apiresponse ResponseModel { get; set; }
        Task<T> sendAsunc<T>(ApiRequest apiRequest);
    }
}

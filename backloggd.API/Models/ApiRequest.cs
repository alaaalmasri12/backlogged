
using static backlogged.Utility.StaticDetails;

namespace backloggd.MVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object data { get; set; }
    }
}

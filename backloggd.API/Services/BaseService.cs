﻿using backloggd.MVC.Models;
using backlogged.MVC.Models;
using Newtonsoft.Json;
using System.Text;
using backlogged.Utility;
using backloggd.API.Services.Iservices;

namespace backloggd.MVC.Services
{
    public class BaseService : IbaseService
       
    {
        private readonly IHttpClientFactory httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.ResponseModel = new Apiresponse();
        }
        public Apiresponse ResponseModel { get; set; }

        public async Task<T> sendAsunc<T>(ApiRequest apiRequest)
        {
            try
            {
                //var client = httpClient.CreateClient("backloggdApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if(apiRequest.data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.data),Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;

                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;

                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiresponse = null;
                apiresponse=await httpClient.CreateClient().SendAsync(message);
                var ApiContent= await apiresponse.Content.ReadAsStringAsync();
                var APIiResponse = JsonConvert.DeserializeObject<T>(ApiContent);
                return APIiResponse;
            }
            catch (Exception EX)
            {
                var DtoResponse = new Apiresponse();
                DtoResponse.ErrorMessages.Add(EX.Message);
                DtoResponse.IsSucssess = false;
                var Result = JsonConvert.SerializeObject(DtoResponse.ErrorMessages);
                var Resultobject = JsonConvert.DeserializeObject<T>(Result);
                return Resultobject;
            }
            throw new NotImplementedException();
        }
    }
}

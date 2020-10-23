using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Service
{

    public class HttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HttpClientService> logger;

        public HttpClientService(IHttpClientFactory clientFactory, ILogger<HttpClientService> _logger)
        {
            _clientFactory = clientFactory;
            logger = _logger;
        }

        public string GetUserInfoAsync(string i)
        {
            string res = "";
            try
            {
                //HttpResponseMessage response = _clientFactory.PostAsync("user", new JsonContent(new { token = 222, pf = "测试2" })).Result;
                //string result =await response.Content.ReadAsStringAsync();

                var client = _clientFactory.CreateClient(i);
                string url = $"http://192.168.0.118:1108/api/UserInfo/GetUserInfo";
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                httpRequest.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkeWI2MjgiLCJVSUQiOiI5OTkiLCJIRUFEIjoiIiwiTklDS05BTUUiOiLoj6Doj5zlpLQiLCJTRVgiOiIxIiwiZXhwIjoxNjAyNjc2NjczLCJpc3MiOiJMb2dpblNlcnZpY2UiLCJhdWQiOiJNaWNyb0dhbWVTZXJ2aWNlIn0.S2UI3lt-tK1xPW50o5b8AZbC7I-NDabj1KVVZ6_ng6M");
                httpRequest.Headers.Add("accept", "text/plain");

                var response = client.SendAsync(httpRequest).GetAwaiter().GetResult();
                res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();


            }
            catch (Exception e)
            {
                res = e.Message;
                logger.LogError(res);

            }

            return res;
        }
    }
}

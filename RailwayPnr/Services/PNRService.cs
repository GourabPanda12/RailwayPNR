using Newtonsoft.Json;
using RailwayPnr.Models;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RailwayPnr.Services
{
    public class PNRService : IPNRService
    {
        private const string BaseUrl = "https://irctc1.p.rapidapi.com/api/v3/getPNRStatus";
        private const string ApiKey = "4a853c2afamshe7c593a3d55d7f2p112b04jsn95d9aa4437ad";
        private const string ApiHost = "irctc1.p.rapidapi.com";

        public async Task<PNRResponse> GetPNRStatusAsync(string pnrNumber)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(BaseUrl);
            var request = new RestRequest();
            request.Method = Method.Get;

            request.AddHeader("x-rapidapi-key", ApiKey);
            request.AddHeader("x-rapidapi-host", ApiHost);
            request.AddParameter("pnrNumber", pnrNumber);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PNRResponse>(response.Content);
            }
            throw new Exception($"Error: {response.StatusCode} - {response.ErrorMessage}");
        }
    }
}
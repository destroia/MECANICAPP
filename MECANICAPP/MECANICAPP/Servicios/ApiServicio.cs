using MECANICAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Plugin.Connectivity;
using System.Net.Http;
using MECANICAPP.Models;
using Newtonsoft.Json;

namespace MECANICAPP.Servicios
{
    public class ApiServicio
    {
        public async Task<Rosponse> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Rosponse
                {
                    IsSuccess = false,
                    Message = "Por Favor verifique la coneccion a internet.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");
            if (!isReachable)
            {
                return new Rosponse
                {
                    IsSuccess = false,
                    Message = "Check you internet connection.",
                };
            }

            return new Rosponse
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }

        public async Task<TokenResponse> GetToken(
            string urlBase,
            string username,
            string password)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("Token",
                    new StringContent(string.Format(
                    "grant_type=password&username={0}&password={1}",
                    username, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(
                    resultJSON);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
    


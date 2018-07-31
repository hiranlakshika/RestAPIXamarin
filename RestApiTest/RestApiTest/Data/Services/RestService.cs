using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Newtonsoft.Json;

namespace Data.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient httpClient;

        public RestService()
        {
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<MovieResponse> RefreshDataAsync()
        {
            var movies = new MovieResponse();
            var uri = new Uri(Constants.RestUrl + Constants.APIKey);

            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<MovieResponse>(content);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"				ERROR {0}", ex.Message);
                }
            }
            return movies;
        }
    }
}

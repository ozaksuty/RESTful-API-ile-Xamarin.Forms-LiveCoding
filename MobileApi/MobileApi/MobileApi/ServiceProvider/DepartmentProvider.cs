using MobileApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApi.ServiceProvider
{
    public class DepartmentProvider
    {
        public string url { get; set; } = "http://localhost:50882/api/Department/";

        public async Task<List<Department>> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                string content = null;
                HttpResponseMessage response = await client.GetAsync(new Uri(url + "GetAll"));
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                content = responseBody;

                MobileResult mobileResult = JsonConvert.DeserializeObject<MobileResult>(content);
                var result = JsonConvert.DeserializeObject<List<Department>>(mobileResult.Data.ToString());

                return result;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileApi.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobileApi.ServiceProvider
{
    public class StudentProvider
    {
        public string url { get; set; } = "http://localhost:50882/api/Student/";

        public async Task<List<Student>> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                string content = null;
                HttpResponseMessage response = await client.GetAsync(new Uri(url + "GetAll"));
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                content = responseBody;

                MobileResult mobileResultType = JsonConvert.DeserializeObject<MobileResult>(content);
                var result = JsonConvert.DeserializeObject<List<Student>>(mobileResultType.Data.ToString());
                return result;
            }
        }

        public async Task<MobileResult> Insert(Student model)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(model);
                var response = await client.PostAsync(url + "Insert", new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                MobileResult mobileResult = JsonConvert.DeserializeObject<MobileResult>(content);
                return mobileResult;
            }
        }

        public async Task<MobileResult> Delete(int ID)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, url + "Delete?ID=" + ID.ToString());
                var response = await client.SendAsync(reqMessage);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                MobileResult mobileResult = JsonConvert.DeserializeObject<MobileResult>(content);
                return mobileResult;
            }
        }
    }
}
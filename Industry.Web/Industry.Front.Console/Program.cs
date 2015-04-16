using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Industry.Front.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:1380";
            const string login = "admin@ipositron.ru";
            const string pass = "123456";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Email", login));
            postData.Add(new KeyValuePair<string, string>("Password", pass));
            postData.Add(new KeyValuePair<string, string>("ConfirmPassword", pass));
            HttpContent content = new FormUrlEncodedContent(postData);

            var response = httpClient.PostAsync("Token", new StringContent("grant_type=password&username=" + login + "&password=" + pass, Encoding.UTF8)).Result;

            //HttpResponseMessage response = httpClient.PostAsync(baseAddress + "/api/Account/Register", content).Result;
            response.EnsureSuccessStatusCode();
            string AccessToken = response.Content.ReadAsStringAsync().Result;
            //AccessToken = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(AccessToken);

            //response = httpClient.GetAsync(baseAddress + "/api/customer").Result;

            System.Console.WriteLine(AccessToken);
            System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            
            System.Console.ReadLine();
        }
    }
}

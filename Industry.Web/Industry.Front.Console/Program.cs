using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Industry.Front.API.Models;
using Newtonsoft.Json;

namespace Industry.Front.ConsoleTest
{
    class Program
    {
        const string _login = "admin@ipositron.ru";
        const string _pass = "123456";
        const string _baseAddress = "http://localhost:1380";

        static void Main(string[] args)
        {
            
            
            string AccessToken = "";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseAddress);
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Email", _login));
            postData.Add(new KeyValuePair<string, string>("Password", _pass));
            postData.Add(new KeyValuePair<string, string>("ConfirmPassword", _pass));
            HttpContent content = new FormUrlEncodedContent(postData);

            var response = httpClient.PostAsync("Token", new StringContent("grant_type=password&username=" + _login + "&password=" + _pass, Encoding.UTF8)).Result;

            //HttpResponseMessage response = httpClient.PostAsync(baseAddress + "/api/Account/Register", content).Result;
            response.EnsureSuccessStatusCode();
            AccessToken = response.Content.ReadAsStringAsync().Result;
            var token = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponseModel>(AccessToken);

            //response = httpClient.GetAsync(baseAddress + "/api/customer").Result;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            response = httpClient.GetAsync(_baseAddress + "/api/customer").Result;

            System.Console.WriteLine(token.AccessToken);
            System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            
            System.Console.ReadLine();
        }
    }
}

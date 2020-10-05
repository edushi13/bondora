using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MVCClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace MVCClient.Services
{
    public class ServerApiProxy : IServerProxy
    {
        private string serverApiUrl;

        private List<Item> _cachedItems;

        public ServerApiProxy(IConfiguration config)
        {
            serverApiUrl = config.GetValue<string>("ServerApiUrl");        
        }

        public Invoice GenerateInvoiceAsync(Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(serverApiUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = serverApiUrl + "/order";
   

            //var response = await client.PostAsync(url, data);

            // List data response.
            var response = client.PostAsync(url, data).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            
                // Parse the response body.
                //var dataObjects = response.Content.ReadAsStringAsync();//.Content.ReadAsAsync<IEnumerable<Item>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                var invoice = JsonConvert.DeserializeObject<Invoice>(result);
                
                return invoice;
            //}
            //else
            //{
            //    //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //    return new Item[0];
            //}
        }

        public Item[] GetItems()
        {
            if (_cachedItems != null)
                return _cachedItems.ToArray();
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(serverApiUrl);

                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync("item").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsStringAsync();//.Content.ReadAsAsync<IEnumerable<Item>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(dataObjects.Result);
                    _cachedItems = items;
                    return items.ToArray();
                }
                else
                {
                    //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return new Item[0];
                }
            }
        }

        public Item GetItem(int id)
        {
            var found = _cachedItems.Find(i => i.ID == id);
            return found;
        }

    }
}

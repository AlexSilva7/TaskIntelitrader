using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using APP_Cadastro.Models;
using System.Text;

namespace APP_Cadastro.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
            
        }

        
        public async Task<List<User>> GetUsersAsync(string uri)
        {
            List<User> users = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return users;
        }


        public async Task PostUserAsync(User user, string uri)
        {
            
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await _client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\Usuario Inserido.");
            }

        }


        public async Task UpdateUserAsync(User user, string uri)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await _client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\t Usuario Atualizado.");
            }

        }


        public async Task DeleteUserAsync(string uri)
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\t Usuario deletado.");
            }
        }
    }
}

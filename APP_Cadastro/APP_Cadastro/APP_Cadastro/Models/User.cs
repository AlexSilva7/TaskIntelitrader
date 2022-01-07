using Newtonsoft.Json;
using System;

namespace APP_Cadastro.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; } = -1;

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_worker.Models
{
    public class JokeServiceSettingsModel
    {
        [JsonProperty("JokeEndpoint")]
        [Url]
        public string? JokeEndpoint { get; set; }

        [JsonProperty("Categories")]
        public List<string>? Categories { get; set; }

        [JsonProperty("BlackListCategories")]
        public List<string>? BlackListCategories { get; set; }
    }
}

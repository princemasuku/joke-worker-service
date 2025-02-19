using Newtonsoft.Json;
namespace learn_worker.Models
{

    public partial class JokeResponseModel
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("setup")]
        public string? Setup { get; set; }

        [JsonProperty("delivery")]
        public string? Delivery { get; set; }

        [JsonProperty("flags")]
        public Flags? Flags { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("safe")]
        public bool Safe { get; set; }

        [JsonProperty("lang")]
        public string? Lang { get; set; }
    }

    public partial class Flags
    {
        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("religious")]
        public bool Religious { get; set; }

        [JsonProperty("political")]
        public bool Political { get; set; }

        [JsonProperty("racist")]
        public bool Racist { get; set; }

        [JsonProperty("sexist")]
        public bool Sexist { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }
    }
}


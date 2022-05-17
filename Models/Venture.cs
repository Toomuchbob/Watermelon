namespace Watermelon.Models
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Venture
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participants")]
        public long Participants { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("key")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Key { get; set; }

        [JsonProperty("accessibility")]
        public long Accessibility { get; set; }
    }

    public partial class Venture
    {
        public static Venture FromJson(string json) => JsonConvert.DeserializeObject<Venture>(json, Converter.Settings);
    }
}
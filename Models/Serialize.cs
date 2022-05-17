using Newtonsoft.Json;

namespace Watermelon.Models
{
    public static class Serialize
    {
        public static string ToJson(this Venture self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

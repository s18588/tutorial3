using System.Text.Json.Serialization;

namespace Tutorial2
{
    public class Wrapper
    {
        [JsonPropertyName("university")]
            public University University { get; set; }
        
    }
}
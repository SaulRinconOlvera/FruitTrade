using System.Text.Json.Serialization;

public class CommodityRequestModel
{
    [JsonPropertyName("COMMODITY")]
    public string Commodity { get; set; }

    [JsonPropertyName("PRICE")]
    public double Price { get; set; }

    [JsonPropertyName("TONS")]
    public double Tons { get; set; }
}
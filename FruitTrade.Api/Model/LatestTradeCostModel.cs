using System.Text.Json.Serialization;

public class LatestTradeCostModel
{
    [JsonPropertyName("COUNTRY")]
    public string Country { get; set; }

    [JsonPropertyName("COMMODITY")]
    public string Commodity { get; set; }

    [JsonPropertyName("TRADE_COST")]
    public double Trade_Cost { get; set; }

    [JsonPropertyName("VARIABLE_COST")]
    public double Variable_Cost { get; set; }
}
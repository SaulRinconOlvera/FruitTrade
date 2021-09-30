using System.Text.Json.Serialization;

public class CommodityResponseModel
{
    [JsonPropertyName("COUNTRY")]
    public string Country { get; set; }

    [JsonPropertyName("TOTAL_COST")]
    public string Total_Cost
    {
        get { return TotalCost.ToString("F2"); }
        set {
            double _totalCost;
            if(double.TryParse(value, out _totalCost))
                TotalCost = _totalCost; 
        }
    }

    [JsonIgnore]
    public double TotalCost { get; set; }

    [JsonPropertyName("TRADE_COST")]
    public string Trade_Cost
    {
        get { return TradeCost.ToString("F2"); }
        set
        {
            double _tradeCost;
            if (double.TryParse(value, out _tradeCost))
                TradeCost = _tradeCost;
        }
    }

    [JsonIgnore]
    public double TradeCost { get; set; }

    [JsonPropertyName("VARIABLE_COST")]
    public string Variable_Cost
    {
        get { return VariableCost.ToString("F2"); }
        set
        {
            double _variableCost;
            if (double.TryParse(value, out _variableCost))
                VariableCost = _variableCost;
        }
    }

    [JsonIgnore]
    public double VariableCost { get; set; }

}
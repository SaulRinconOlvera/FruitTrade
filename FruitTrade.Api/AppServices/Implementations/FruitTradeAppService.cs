using System.Collections.Generic;
using System.Linq;

public class FruitTradeAppService : IFruitTradeAppService
{
    public IEnumerable<CommodityResponseModel> CalculateTrade(CommodityRequestModel requestModel)
    {
        List<CommodityResponseModel> result = new List<CommodityResponseModel>();

        GlobalValues.LatestTradeCosts
            .Where(t => t.Commodity == requestModel.Commodity).ToList()
            .ForEach(x => {
                result.Add(new CommodityResponseModel {
                    Country = x.Country,
                    TradeCost = x.Trade_Cost,
                    VariableCost= x.Variable_Cost,
                    TotalCost = (x.Variable_Cost*requestModel.Tons)+x.Trade_Cost,
                });
            });

        return result.OrderByDescending(x => x.TotalCost);
    }
}
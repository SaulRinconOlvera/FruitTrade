using System.Collections.Generic;

public interface IFruitTradeAppService
{
    IEnumerable<CommodityResponseModel> CalculateTrade(CommodityRequestModel requestModel);
}
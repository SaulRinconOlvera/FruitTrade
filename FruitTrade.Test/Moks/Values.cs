public class Values
{
    public static CommodityRequestModel InputModel => new CommodityRequestModel {
        Commodity = "mango",
        Price = 53,
        Tons = 405
    };

    public static CommodityRequestModel InputModelDoesntExits => new CommodityRequestModel
    {
        Commodity = "mango1",
        Price = 53,
        Tons = 405
    };
}
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class FruitTradeTest
{
    [Fact]
    public async Task GetTradeMagos_Ok() {
        // Arrange
        var json = JsonConvert.SerializeObject(Values.InputModel, Formatting.Indented);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ClientHttp.GetUrl("FruitTrade")),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };


        //  Act
        var response = await ClientHttp.GetClient().SendAsync(request);
        var data = ClientHttp.GetValues<CommodityResponseModel>(await response.Content.ReadAsStringAsync());
        
        //  Asert
        response.EnsureSuccessStatusCode();
        Assert.True(data != null);

        var values = data.ToList();
        Assert.True(values.Any());
        Assert.True(values[0].TotalCost == 22060.1);
    }

    [Fact]
    public async Task GetTradeMagos_No_Data()
    {
        // Arrange
        var json = JsonConvert.SerializeObject(Values.InputModelDoesntExits, Formatting.Indented);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ClientHttp.GetUrl("FruitTrade")),
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        //  Act
        var response = await ClientHttp.GetClient().SendAsync(request);

        //  Asert
        response.StatusCode = HttpStatusCode.NoContent;
    }
}
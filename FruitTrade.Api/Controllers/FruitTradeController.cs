
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class FruitTradeController : ControllerBase
{
    private readonly IFruitTradeAppService _service;

    public FruitTradeController(IFruitTradeAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(IEnumerable<CommodityResponseModel>), (int)HttpStatusCode.OK)]
    public ActionResult<IEnumerable<CommodityResponseModel>> Get([FromBody] CommodityRequestModel model) {
        try
        {
            var result = _service.CalculateTrade(model);
            if(result.Any()) return Ok(result);
            else return NoContent();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
}
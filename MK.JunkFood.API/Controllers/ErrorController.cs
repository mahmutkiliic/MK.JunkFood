using Microsoft.AspNetCore.Mvc;
using MK.JunkFood.API.Errors;

namespace MK.JunkFood.API.Controllers
{
    [Route("errors/{code}")]    

    /*This code below hides endpoint like in the WeatheForecastController*/
    [ApiExplorerSettings(IgnoreApi =true)]
    /*Fetch errorresponse status is 500 https://localhost:7000/swagger/v1/swagger.json*/

    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}

using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Microsoft.AspNetCore.Mvc;



namespace Erp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BaseController: ControllerBase
    {

        protected new ActionResult Response(BaseResponse response)
        {
            if(response == null)
                return NoContent();
            return Ok(response);
        }

        protected new ActionResult Response(dynamic response)
        {
            if (response == null)
                return NoContent();
            return Ok(response);
        }

    }

    class Response: BaseResponse
    {

    }
}

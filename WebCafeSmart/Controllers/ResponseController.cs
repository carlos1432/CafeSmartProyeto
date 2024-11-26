using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace Web.Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        //Se crea un objeto de tipo DefaultResponse (Data, Success, Message)
        public ResponseService response = new();

        [NonAction]
        public void SetDataResponse(object data)
        {
            response.Data = data;
        }

        [NonAction]
        public void SetMsgErrorResponse(Exception ex)
        {
            response.Message = GetExceptionMessage(ex);
            response.Success = false;
        }

        [NonAction]
        public void SetMessageResponse(string msg)
        {
            response.Message = msg;
        }

        [NonAction]
        public void SetErrorResponse(bool success)
        {
            response.Success = success;
        }

        [NonAction]
        public string GetExceptionMessage(Exception ex)
        {
            return ex.Message + $"{(ex.InnerException != null ? " => " + GetExceptionMessage(ex.InnerException) : "")}";
        }
    }
}

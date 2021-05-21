using Meadow.Foundation.Web.Maple.Server;
using Meadow.Foundation.Web.Maple.Server.Routing;
using MeadowServo.Mcu.Controllers;

namespace MeadowServo.Mcu.RequestHandlers
{
    public class ServoControllerRequestHandler : RequestHandlerBase
    {
        [HttpGet]
        public void Servo()
        {
            int angle = 0;
            int.TryParse(QueryString["angle"] as string, out angle);

            ServoController.Instance.SetAngle(angle);

            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.ContentType = ContentTypes.Application_Text;
            Context.Response.StatusCode = 200;
            Send($"{angle}").Wait();
        }
    }
}

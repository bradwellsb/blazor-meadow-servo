using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Web.Maple.Server;
using Meadow.Gateway.WiFi;
using MeadowServo.Mcu.Controllers;
using System;
using System.Threading.Tasks;

namespace MeadowServo.Mcu
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        MapleServer server;

        public MeadowApp()
        {            
            InitializeAsync().Wait();            
            server.Start();
            ServoController.Instance.SetAngle(0);
        }

        async Task InitializeAsync()
        {
            ServoController.Instance.InitializeServo();

            if (!Device.InitWiFiAdapter().Result)
            {
                throw new Exception("Could not initialize the WiFi adapter.");
            }

            var connectionResult = await Device.WiFiAdapter.Connect("SSID", "password");
            if (connectionResult.ConnectionStatus != ConnectionStatus.Success)
            {
                throw new Exception($"Cannot connect to network: {connectionResult.ConnectionStatus}");
            }

            server = new MapleServer(
                Device.WiFiAdapter.IpAddress, 5417
            );
        }        
    }
}

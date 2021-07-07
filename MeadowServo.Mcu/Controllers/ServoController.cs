using Meadow.Foundation.Servos;
using Meadow.Units;

namespace MeadowServo.Mcu.Controllers
{
    public class ServoController
    {
        Servo servo;

        public static ServoController Instance { get; private set; }

        private ServoController() { }

        static ServoController()
        {
            Instance = new ServoController();
        }

        public void InitializeServo()
        {
            servo = new Servo(
                MeadowApp.Device.CreatePwmPort(MeadowApp.Device.Pins.D08), NamedServoConfigs.SG90);            
        }

        public void SetAngle(int angle)
        {
            servo.RotateTo(new Angle(angle));
        }
    }
}

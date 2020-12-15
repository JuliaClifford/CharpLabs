using System;

namespace L11
{
    public class Automobile
    {
        public Automobile()
        {
            WheelAlignment = false;
            IsPainted = false;
            OilChanged = false;
            CarInspection = false;
            WheelChanged = false;
            BodyRepair = false;
        }
        public bool WheelAlignment { get; set; }
        public bool IsPainted { get; set; }
        public bool OilChanged { get; set; }
        public bool CarInspection { get; set; }
        public bool WheelChanged { get; set; }
        public bool BodyRepair { get; set; }

        public void ShowDoneWork()
        {
            Console.WriteLine($"<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>\n" +
                              $"WheelAlignment - {WheelAlignment}\n" +
                              $"Is Painted - {IsPainted}\n" +
                              $"Oil Changed - {OilChanged}\n" +
                              $"Car Inspection- {CarInspection}\n" +
                              $"Wheel Changed - {WheelChanged}\n" +
                              $"Body Repair - {BodyRepair}\n" +
                              $"<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>\n"); 
        }
    }
}
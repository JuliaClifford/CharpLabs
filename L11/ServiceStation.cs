namespace L11
{
    public class ServiceStation
    {
        public void RepairBody(Automobile auto)
        {
            auto.BodyRepair = true;
        }

        public void CarInspection(Automobile auto)
        {
            auto.CarInspection = true;
        }

        public void PaintCar(Automobile auto)
        {
            auto.IsPainted = true;
        }

        public void ChangeOil(Automobile auto)
        {
            auto.OilChanged = true;
        }

        public void AlignWheels(Automobile auto)
        {
            auto.WheelAlignment = true;
        }

        public void ChangeWheel(Automobile auto)
        {
            auto.WheelChanged = true;
        }
    }
}
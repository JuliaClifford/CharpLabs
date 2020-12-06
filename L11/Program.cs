namespace L11
{
    public delegate void AllRepairDelegate(Automobile a);
    public delegate void RepairDelegate(Automobile a);

    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Automobile jeep = new Automobile();
            ServiceStation station = new ServiceStation();
            
            RepairDelegate wheelAligment = new RepairDelegate(station.AlignWheels);
            RepairDelegate paint = new RepairDelegate(station.PaintCar);
            RepairDelegate changeOil = new RepairDelegate(station.ChangeOil);
            RepairDelegate carInspection = new RepairDelegate(station.CarInspection);
            RepairDelegate changeWheels = new RepairDelegate(station.ChangeWheel);
            RepairDelegate repairBody = new RepairDelegate(station.RepairBody);

            AllRepairDelegate allRepair = new AllRepairDelegate
                (wheelAligment + paint + changeOil + carInspection + changeWheels + repairBody);
            
            jeep.ShowDoneWork();

            paint(jeep);
            changeOil(jeep);
            repairBody(jeep);
            
            jeep.ShowDoneWork();

            allRepair(jeep);
            
            jeep.ShowDoneWork();
        }
    }
}
using System;
using System.Collections.Generic;

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
            Random rand = new Random();
            RepairDelegate wheelAligment = new RepairDelegate(station.AlignWheels);
            RepairDelegate paint = new RepairDelegate(station.PaintCar);
            RepairDelegate changeOil = new RepairDelegate(station.ChangeOil);
            RepairDelegate carInspection = new RepairDelegate(station.CarInspection);
            RepairDelegate changeWheels = new RepairDelegate(station.ChangeWheel);
            RepairDelegate repairBody = new RepairDelegate(station.RepairBody);

            AllRepairDelegate allRepair = new AllRepairDelegate
                (wheelAligment + paint + changeOil + carInspection + changeWheels + repairBody);
            
            jeep.ShowDoneWork();
            
            List<Student> students = new List<Student>();
            
            students.Add(new Student("Jack", "Klrakson", rand.Next(10, 30)));
            students.Add(new Student("Andrew", "Nicolas", rand.Next(10, 30)));
            students.Add(new Student("Lucas", "Andler", rand.Next(10, 30)));
            students.Add(new Student("Delorean", "Lysson", rand.Next(10, 30)));
            students.Add(new Student("Sheyla", "Chester", rand.Next(10, 30)));
            students.Add(new Student("July", "Dotter", rand.Next(10, 30)));
            students.Add(new Student("Alex", "Chack", rand.Next(10, 30)));
            students.Add(new Student("Michael", "Stanford", rand.Next(10, 30)));
            students.Add(new Student("Fernando", "Putin", rand.Next(10, 30)));
            students.Add(new Student("Eve", "Trump", rand.Next(10, 30)));
            students.Add(new Student("Ashot", "Obama", rand.Next(10, 30)));
            students.Add(new Student("Ann", "Franklin", rand.Next(10, 30)));
            
            Console.WriteLine("Age > 18");
            students.FindStudents(Student.IsEighteen).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("First letter of First name \"А\"");
            students.FindStudents(Student.NameStartsWithA).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("Last Name is Longer then 3");
            students.FindStudents(Student.SurnameLongerThanThree).ForEach(Console.WriteLine);
            Console.WriteLine();

            
            Console.WriteLine("Age > 18");
            students.FindStudents(s => s.Age >= 18).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("First letter of First name \"А\"");
            students.FindStudents(s => s.FirstName?[0] == 'A').ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("Last Name is Longer then 3");
            students.FindStudents(s => s.LastName?.Length > 3).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            //Anonymous methods
            Console.WriteLine("Age betwewn 20 and 25");
            students.FindStudents(s => s.Age >= 20 && s.Age <= 25).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("Name \"Andrew\"");
            students.FindStudents(s => s.FirstName.Equals("Andrew")).ForEach(Console.WriteLine);
            Console.WriteLine();
            
            Console.WriteLine("Surname \"Troelsen\"");
            students.FindStudents(s => s.LastName.Equals("Troelsen")).ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
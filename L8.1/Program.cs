using System;
using System.Collections.Generic;
using System.Linq;

namespace L8._1
{
    internal class Program
    {
        public class Car
        {
            public Car()
            {
            }

            public Car(string carModel, string color, double speed, int year)
            {
                CarModel = carModel;
                Color = color;
                Speed = speed;
                Year = year;
            }

            public string CarModel { get; }
            public string Color { get; }
            public double Speed { get; }
            public int Year { get; }
        }

        public class Garage : Car
        {
            private readonly List<Car> carsList;

            public Garage()
            {
                carsList = new List<Car>();
            }


            public void AddCar(string carModel, string color, double speed, int yearOfIssue)
            {
                var car = new Car(carModel, color, speed, yearOfIssue);
                carsList.Add(car);
            }

            public void ShowCars()
            {
                if (carsList.Count == 0)
                {
                    Console.WriteLine("Ваш гараж пуст!");
                }
                else
                {
                    var i = 1;
                    foreach (var car in carsList)
                    {
                        Console.WriteLine($"{i}|Model: {car.CarModel}, Color {car.Color}, " +
                                          $"Max Speed: {car.Speed}km/h, Year: {car.Year}");
                        i++;
                    }
                }
            }

            public void DeleteCar(int index)
            {
                carsList.Remove(carsList.ElementAt(index - 1));
            }

            public void RideCar(int index)
            {
                Console.Clear();
                var currentCar = carsList[index - 1];
                Console.WriteLine("Хорошо прокатиться на " +
                                  $"{currentCar.Color} {currentCar.CarModel} {currentCar.Year}" +
                                  " года выпуска");
                Console.ReadKey();
            }

            public int CountCars()
            {
                var counter = 0;
                foreach (var car in carsList)
                    counter++;
                return counter;
            }
        }

        public static void Main(string[] args)
        {
            var garage1 = new Garage();
            garage1.AddCar("Mersedes S63 AMG", "Pink", 320, 2020);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в ваш гараж, что хотите сделать?");
                Console.WriteLine(
                    "1)Вывести список автомобилей\n" +
                    "2)Добавить автомобиль\n" +
                    "3)Убрать автомобиль\n" +
                    "4)Прокатиться на автомобиле!\n" +
                    "5)Выход\n");
                int input;

                while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 5)
                    Console.Write("Некорректный ввод. Попробуйте снова: ");
                switch (input)
                {
                    //Показать автомобили
                    case 1:
                        Console.Clear();
                        garage1.ShowCars();
                        Console.ReadKey();
                        break;

                    //Добавить автомобиль
                    case 2:
                        Console.Clear();
                        string carModel, color;
                        float speed;
                        int yearOfIssue;
                        Console.Write("Введите марку автомобиля: ");
                        while (true)
                        {
                            carModel = Console.ReadLine();
                            if (string.IsNullOrEmpty(carModel))
                                Console.Write("Некорректный ввод. Попробуйте снова: ");
                            else break;
                        }

                        Console.Write("Введите цвет машины: ");
                        while (true)
                        {
                            color = Console.ReadLine();
                            if (string.IsNullOrEmpty(color))
                                Console.Write("Некорректный ввод. Попробуйте снова: ");
                            else break;
                        }

                        Console.Write("Введите скорость машины: ");
                        while (!float.TryParse(Console.ReadLine(), out speed) || speed <= 0)
                            Console.Write(
                                "Некорректный ввод. Скорость не может быть равна или меньше 0. Попробуйте снова: ");

                        Console.Write("Введите год выпуска машины: ");
                        while (!int.TryParse(Console.ReadLine(), out yearOfIssue) || yearOfIssue <= 0)
                            Console.Write(
                                "Некорректный ввод. Год выпуска не может быть равен или меньшим 0. Попробуйте снова: ");

                        garage1.AddCar(carModel, color, speed, yearOfIssue);
                        break;
                    //Удалить автомобиль
                    case 3:
                        Console.Clear();

                        if (garage1.CountCars() > 1)
                        {
                            int lowInput;
                            Console.WriteLine("Какой из автомобилей хотите убрать из гаража?");
                            garage1.ShowCars();

                            while (!int.TryParse(Console.ReadLine(), out lowInput) || lowInput <= 0 ||
                                   lowInput > garage1.CountCars())
                                Console.Write("Некорректный ввод. Попробуйте снова: ");
                            garage1.DeleteCar(lowInput);
                        }
                        else
                        {
                            garage1.DeleteCar(0);
                        }

                        break;
                    //Выехать на автомобиле
                    case 4:
                        if (garage1.CountCars() > 1)
                        {
                            int lowInput;
                            Console.WriteLine("На чём прокатимся?");
                            garage1.ShowCars();

                            while (!int.TryParse(Console.ReadLine(), out lowInput) || lowInput <= 0 ||
                                   lowInput > garage1.CountCars())
                                Console.Write("Некорректный ввод. Попробуйте снова: ");
                            garage1.RideCar(lowInput);
                        }
                        else
                        {
                            garage1.RideCar(0);
                        }

                        break;
                    case 5:
                        break;
                }

                if (input == 5) break;
            }
        }
    }
}
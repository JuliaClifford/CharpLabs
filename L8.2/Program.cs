using System;
using System.Collections.Generic;

namespace L8._2
{
    internal class DiscPhone
    {
        public DiscPhone()
        {
        }

        public DiscPhone(string phoneNum)
        {
            PhoneNum = phoneNum;
        }

        public string PhoneNum { get; set; }

        public virtual List<char> AllowedSymbs => new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        protected string EnterNumber()
        {
            Console.Write("Введите номер абонента: ");
            while (true)
            {
                var invalid = false;
                PhoneNum = Console.ReadLine();
                if (PhoneNum != null)
                {
                    foreach (var symbol in PhoneNum)
                        if (!AllowedSymbs.Contains(symbol))
                        {
                            invalid = true;
                            break;
                        }

                    if (invalid)
                    {
                        Console.Write("Некорректный ввод. Попробуйте снова: ");
                        continue;
                    }

                    return PhoneNum;
                }

                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
        }

        public virtual void Call()
        {
            Console.WriteLine($"Вызов номерa {EnterNumber()}");
        }

        public virtual void TakeCall(string callingNum)
        {
            Console.WriteLine("Входящий вызов");
        }
    }
    internal class ButtonPhone : DiscPhone
    {
        public ButtonPhone(string phoneNum) : base(phoneNum)
        {
        }

        public override List<char> AllowedSymbs => new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '*', '#'
        };

        public override void TakeCall(string callingNum)
        {
            Console.WriteLine($"Входящий вызов от {callingNum}");
        }
    }
    internal class ColorlessPhone : ButtonPhone
    {
        public ColorlessPhone(string phoneNum, int screenWidth, int screenHeight, int screenResolution,
            string phoneColor) : base(phoneNum)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            ScreenResolution = screenResolution;
            PhoneColor = phoneColor;
        }

        public override List<char> AllowedSymbs => new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '*', '#',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '+'
        };

        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenResolution { get; set; }
        public string PhoneColor { get; set; }

        public void SendSms(string sms, string recipientNumber)
        {
            Console.WriteLine($"Абоненту {recipientNumber} отправлено сообщение \"{sms}\"");
        }

        public void GetSms(string sms, string senderNumber)
        {
            Console.WriteLine($"Получено сообщение: \"{sms}\" от {senderNumber}");
        }
    }
    internal class ColorfulPhone : ColorlessPhone
    {
        public ColorfulPhone(string phoneNum, int screenWidth, int screenHeight, int screenResolution,
            string phoneColor,
            int colorAmount, bool isTwoSim, string secondPhoneNumber = null)
            : base(phoneNum, screenWidth, screenHeight, screenResolution, phoneColor)
        {
            ColorAmount = colorAmount;
            IsTwoSim = isTwoSim;
            SecondPhoneNumber = secondPhoneNumber;
        }

        public int ColorAmount { get; set; }
        public bool IsTwoSim { get; set; }
        public string SecondPhoneNumber { get; set; }

        public void SendMms(string recipientNumber)
        {
            Console.WriteLine($"Абоненту {recipientNumber} отправлено MMS");
        }

        public void GetMms(string senderNumber)
        {
            Console.WriteLine($"Получено сообщение: MMS от {senderNumber}");
        }
    }
    internal class SmartPhone : ColorfulPhone
    {
        public SmartPhone(string phoneNum, int screenWidth, int screenHeight, int screenResolution, string phoneColor,
            int colorAmount, bool isTwoSim, bool touchScreen, int touchCounter, int cameraQuantity,
            string secondPhoneNumber)
            : base(phoneNum, screenWidth, screenHeight, screenResolution, phoneColor, colorAmount, isTwoSim,
                secondPhoneNumber)
        {
        }

        public bool TouchScreen { get; set; }
        public int TouchCounter { get; set; }
        public int CameraQuantity { get; set; }

        public void TakePhoto()
        {
            Console.WriteLine("Сделано фото.");
        }

        public void RecordVideo()
        {
            Console.WriteLine("Записано видео.");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Дисковый телефон:");
            var discPhone = new DiscPhone("111");

            Console.Write("Доступные символы: ");
            foreach (var sym in discPhone.AllowedSymbs)
                Console.Write(sym + " ");
            Console.WriteLine();
            Console.WriteLine($"Номер: {discPhone.PhoneNum}");
            discPhone.Call();
            discPhone.TakeCall("101");

            Console.WriteLine(new string('_', 20));

            Console.WriteLine("Кнопочный телефон:");
            var bPhone = new ButtonPhone("222");

            Console.Write("Доступные символы: ");
            foreach (var sym in bPhone.AllowedSymbs)
                Console.Write(sym + " ");
            Console.WriteLine();
            Console.WriteLine($"Номер: {bPhone.PhoneNum}");
            bPhone.Call();
            bPhone.TakeCall("101");

            Console.WriteLine(new string('_', 20));

            Console.WriteLine("Телефон с черно-белым экраном:");
            var colorlessPhone = new ColorlessPhone("333", 50, 100, 2, "Черный");

            Console.Write("Доступные символы: ");
            foreach (var sym in colorlessPhone.AllowedSymbs)
                Console.Write(sym + " ");
            Console.WriteLine();
            Console.WriteLine($"Номер: {colorlessPhone.PhoneNum}");
            Console.WriteLine($"Ширина экрана (пиксели): {colorlessPhone.ScreenWidth}");
            Console.WriteLine($"Высота экрана (пиксели): {colorlessPhone.ScreenHeight}");
            Console.WriteLine($"Размер экрана (дюймы): {colorlessPhone.ScreenResolution}");
            Console.WriteLine($"Цвет телефона: {colorlessPhone.PhoneColor}");
            colorlessPhone.Call();
            colorlessPhone.TakeCall("101");
            colorlessPhone.SendSms("Привет, друг", "068");
            colorlessPhone.GetSms("Шабат шалом", "101");


            Console.WriteLine(new string('_', 20));

            Console.WriteLine("Телефон с цветным экраном:");
            var colorPhone = new ColorfulPhone("444", 200, 400, 5, "Черный", 16000000, true, "66666");

            Console.Write("Доступные символы: ");
            foreach (var sym in colorPhone.AllowedSymbs)
                Console.Write(sym + " ");
            Console.WriteLine();
            Console.WriteLine($"Номер: {colorPhone.PhoneNum}");
            Console.WriteLine($"Ширина экрана (пиксели): {colorPhone.ScreenWidth}");
            Console.WriteLine($"Высота экрана (пиксели): {colorPhone.ScreenHeight}");
            Console.WriteLine($"Размер экрана (дюймы): {colorPhone.ScreenResolution}");
            Console.WriteLine($"Цвет телефона: {colorPhone.PhoneColor}");
            Console.WriteLine($"Количество сим-карт: {(colorPhone.IsTwoSim ? 2 : 1)}");
            Console.WriteLine($"Второй номер: {(colorPhone.IsTwoSim ? colorPhone.SecondPhoneNumber : "-")}");
            colorPhone.Call();
            colorPhone.TakeCall("101");
            colorPhone.SendSms("Привет, друг", "068");
            colorPhone.GetSms("Шабат шалом", "101");
            colorPhone.SendMms("123123");
            colorPhone.GetMms("101");


            Console.WriteLine(new string('_', 20));

            Console.WriteLine("Смартфон:");
            var smartphone = new SmartPhone("555", 1080, 1920,
                6, "Черный", 16777216, true,
                true, 10, 3, "102");

            Console.Write("Доступные символы: ");
            foreach (var sym in smartphone.AllowedSymbs)
                Console.Write(sym + " ");
            Console.WriteLine();
            Console.WriteLine($"Номер: {smartphone.PhoneNum}");
            Console.WriteLine($"Ширина экрана (пиксели): {smartphone.ScreenWidth}");
            Console.WriteLine($"Высота экрана (пиксели): {smartphone.ScreenHeight}");
            Console.WriteLine($"Размер экрана (дюймы): {smartphone.ScreenResolution}");
            Console.WriteLine($"Цвет телефона: {smartphone.PhoneColor}");
            Console.WriteLine($"Количество сим-карт: {(smartphone.IsTwoSim ? 2 : 1)}");
            Console.WriteLine($"Второй номер: {(smartphone.IsTwoSim ? smartphone.SecondPhoneNumber : "-")}");
            Console.WriteLine($"Сенсорный экран: {(smartphone.TouchScreen ? "да" : "нет")}");
            Console.WriteLine($"Максимальное количество касаний: {smartphone.TouchCounter}");
            Console.WriteLine($"Количество камер: {smartphone.CameraQuantity}");
            colorPhone.Call();
            colorPhone.TakeCall("101");
            colorPhone.SendSms("Привет, друг", "068");
            colorPhone.GetSms("Шабат шалом", "101");
            colorPhone.SendMms("123123");
            colorPhone.GetMms("101");
            smartphone.TakePhoto();
            smartphone.RecordVideo();

            Console.ReadLine();
        }
    }
}
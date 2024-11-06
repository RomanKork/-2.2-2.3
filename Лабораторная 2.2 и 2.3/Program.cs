using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int ex;
        Console.WriteLine("Задание 1 - 1, задание 2 - 2");
        if (int.TryParse(Console.ReadLine(), out ex) && ex == 1)
        {
            Time time1 = new Time(Enterhours(), Enterminutes());
            Console.WriteLine("Вами введённое время" + time1.ToString());
            Console.WriteLine("Сколько хотите минут вычесть из этого времени?");
            uint x;
            if (uint.TryParse(Console.ReadLine(), out x))
            {
                Time timeculc = time1.calculate(x);
                Console.WriteLine("Время после вычета вами введнных минут: " + timeculc.ToString());
            }
        }
        if (ex == 2)
        {
            Time time1 = new Time(Enterhours(), Enterminutes());
            Time time2 = new Time(Enterhours(), Enterminutes());
            Time time3 = new Time(Enterhours(), Enterminutes());
            Console.WriteLine("Время 1: " + time1);
            Console.WriteLine("Время 2: " + time2);
            Console.WriteLine("Время 3: " + time3);
            Console.WriteLine("Время 1 и время 2 равны? " + (time1 == time2));
            Console.WriteLine("Время 1 и время 3 не равны? " + (time1 != time3));
            Time zeroedTime = -time1;
            Console.WriteLine("Время после обнуления: " + zeroedTime);
            Time onlyMinutesZeroed = --time1;
            Console.WriteLine("Время после обнуления минут(1-ое время): " + onlyMinutesZeroed);
            byte hoursOnly = time1;
            Console.WriteLine("Часы из времени 1 (приведение к byte): " + hoursOnly);
            bool isNotZero = (bool)time3;
            Console.WriteLine("Время 3 не нулевое? " + isNotZero);
        }
        else {
            Console.WriteLine("Вы ввели не номер задачи");
        }
        }
        public static byte Enterhours()
        {
            Console.WriteLine("Вам надо ввести час(0 - 23): ");
            byte y;
            if (byte.TryParse(Console.ReadLine(), out y) && y < 24)
                return y;
            Console.WriteLine("Вы ввели некорректное значение, попробуйте снова");
            return Enterhours();
        }
        public static byte Enterminutes()
        {
            Console.WriteLine("Вам надо ввести минуты(0 - 59): ");
            byte y;
            if (byte.TryParse(Console.ReadLine(), out y) && y < 60)
                return y;
            Console.WriteLine("Вы ввели некорректное значение, попробуйте снова");
            return Enterminutes();
        }
    } 

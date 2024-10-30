using System;

class Time
{
    private byte hours;
    private byte minutes;

    public byte hourscorrect
    {
        get => hours;
        set
        {
            if (value <= 23 && value >= 0)
                hours = value;
            else
                throw new ArgumentOutOfRangeException("Диапазон часов должен находиться от 0 до 23 включительно");
        }
    }

    public byte minutescorrect
    {
        get => minutes;
        set
        {
            if (value <= 59 && value >= 0)
                minutes = value;
            else
                throw new ArgumentOutOfRangeException("Диапазон минут должен находиться от 0 до 59 включительно");
        }
    }

    public Time()
    {
        hourscorrect = 0;
        minutescorrect = 0;
    }

    public Time(byte hours, byte minutes)
    {
        hourscorrect = hours;
        minutescorrect = minutes;
    }

    public override string ToString()
    {
        return $"Время {hourscorrect:D2}:{minutescorrect:D2}";
    }
    public Time calculate(uint time1)
    {
        int allminut = hourscorrect * 60 + minutescorrect - (int)time1;
        while (allminut < 0)
            allminut += 1440;
        byte hours1 = (byte)(allminut / 60);
        byte minutes1 = (byte)(allminut % 60);
        return new Time(hours1, minutes1);
    }
    public static Time operator -(Time time)
    {
        return new Time(0, 0);
    }

    public static Time operator --(Time time)
    {
        return new Time(time.hourscorrect, 0);
    }

    public static implicit operator byte(Time time)
    {
        return time.hourscorrect;
    }

    public static explicit operator bool(Time time)
    {
        return time.hourscorrect != 0 || time.minutescorrect != 0;
    }

    public static bool operator ==(Time t1, Time t2)
    {
        return t1.hourscorrect == t2.hourscorrect && t1.minutescorrect == t2.minutescorrect;
    }

    public static bool operator !=(Time t1, Time t2)
    {
        return !(t1 == t2);
    }
}


internal class program
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
         if ( ex == 2)
            {
                Time time1 = new Time(Enterhours(), Enterminutes());
                Time time2 = new Time(Enterhours(), Enterminutes());
                Time time3 = new Time(Enterhours(), Enterminutes());

                Console.WriteLine("Время 1: " + time1);
                Console.WriteLine("Время 2: " + time2);
                Console.WriteLine("Время 3: " + time3);

                Time zeroedTime = -time1;
                Console.WriteLine("Время после обнуления: " + zeroedTime);

                Time onlyMinutesZeroed = --time1;
                Console.WriteLine("Время после обнуления минут(1-ое время): " + onlyMinutesZeroed);

                byte hoursOnly = time1;
                Console.WriteLine("Часы из времени 1 (приведение к byte): " + hoursOnly);

                bool isNotZero = (bool)time3;
                Console.WriteLine("Время 3 не нулевое? " + isNotZero);

                Console.WriteLine("Время 1 и время 2 равны? " + (time1 == time2));
                Console.WriteLine("Время 1 и время 3 не равны? " + (time1 != time3));
                Console.WriteLine("Время 1 и время 2 равны? " + Equals(time1, time2));
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

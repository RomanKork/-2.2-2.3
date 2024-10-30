 class Time
{
    private byte hours;
    private byte minutes;
    public byte hourscorrect
    {
        get => hours;
        set
        {
            if(value <= 23 && value >= 0)
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
}
internal class program
{
    private static void Main(string[] args)
    {
        Time time1 = new Time(Enterhours(),Enterminutes());
        Console.WriteLine("Вами введённое время" + time1.ToString());
        Console.WriteLine("Сколько хотите минут вычесть из этого времени?");
        uint x;
        if (uint.TryParse(Console.ReadLine(), out x))
        {
            Time timeculc = time1.calculate(x);
            Console.WriteLine("Время после вычета вами введнных минут: " + timeculc.ToString());
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

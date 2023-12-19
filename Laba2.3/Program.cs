using System;

/// <summary>
/// Класс, представляющий дату (день, месяц, год)
/// </summary>
public class Date
{
    private int day;
    private int month;
    private int year;

    /// <summary>
    /// Конструктор класса Date
    /// </summary>
    /// <param name="day">День</param>
    /// <param name="month">Месяц</param>
    /// <param name="year">Год</param>
    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    /// <summary>
    /// Перегрузка оператора + для добавления дней к дате
    /// </summary>
    public static Date operator +(Date date, int daysToAdd)
    {
        return date.AddDays(daysToAdd);
    }

    /// <summary>
    /// Перегрузка оператора - для вычитания дней из даты
    /// </summary>
    public static Date operator -(Date date, int daysToSubtract)
    {
        return date.AddDays(-daysToSubtract);
    }

    /// <summary>
    /// Перегрузка оператора == для сравнения двух объектов даты
    /// </summary>
    public static bool operator ==(Date date1, Date date2)
    {
        return date1.Equals(date2);
    }

    /// <summary>
    /// Перегрузка оператора != для сравнения двух объектов даты
    /// </summary>
    public static bool operator !=(Date date1, Date date2)
    {
        return !date1.Equals(date2);
    }

    /// <summary>
    /// Метод для вывода даты в формате "дд.мм.гггг"
    /// </summary>
    public string ToShortDateString()
    {
        return $"{day:D2}.{month:D2}.{year:D4}";
    }

    /// <summary>
    /// Метод для вывода даты в формате "месяц день, год"
    /// </summary>
    public string ToLongDateString()
    {
        return $"{GetMonthName(month)} {day}, {year}";
    }

    /// <summary>
    /// Метод для добавления или вычитания дней из даты
    /// </summary>
    private Date AddDays(int days)
    {
        DateTime dateTime = new DateTime(year, month, day);
        dateTime = dateTime.AddDays(days);

        return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
    }

    /// <summary>
    /// Переопределение метода Equals для сравнения двух объектов Date
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj is Date)
        {
            Date otherDate = (Date)obj;
            return day == otherDate.day && month == otherDate.month && year == otherDate.year;
        }
        return false;
    }

    /// <summary>
    /// Переопределение метода GetHashCode
    /// </summary>
    public override int GetHashCode()
    {
        return day.GetHashCode() ^ month.GetHashCode() ^ year.GetHashCode();
    }

    /// <summary>
    /// Метод для получения названия месяца по его номеру
    /// </summary>
    private string GetMonthName(int monthNumber)
    {
        return new DateTime(year, monthNumber, 1).ToString("MMMM");
    }

    /// <summary>
    /// Статический метод для получения текущей даты
    /// </summary>
    public static Date Today()
    {
        DateTime currentDate = DateTime.Now;
        return new Date(currentDate.Day, currentDate.Month, currentDate.Year);
    }
}

/// <summary>
/// Класс для выполнения лабораторной работы 2.3
/// </summary>>
class Lab2_3
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main()
    {
        /// Пример использования класса Date ///
        Date date1 = Date.Today();
        Date date2 = date1 + 10;
        Date date3 = date2 - 5;

        Console.WriteLine("Дата 1: " + date1.ToShortDateString());
        Console.WriteLine("Дата 2: " + date2.ToLongDateString());
        Console.WriteLine("Дата 3: " + date3.ToShortDateString());

        /// Проверка операторов == и != ///
        Console.WriteLine("Даты равны: " + (date1 == date2));
        Console.WriteLine("Даты не равны: " + (date1 != date2));
    }
}

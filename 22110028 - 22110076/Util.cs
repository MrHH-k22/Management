
public class Util
{
    public static ConsoleColor CSTitle;
    public static ConsoleColor CSContent;

    static Util()
    {
        DayOfWeek now = DateTime.Now.DayOfWeek;

        switch (now)
        {
            case DayOfWeek.Monday: CSTitle = ConsoleColor.Red; CSContent = ConsoleColor.Magenta; break;
            case DayOfWeek.Tuesday: CSTitle = ConsoleColor.DarkBlue; CSContent = ConsoleColor.Cyan; break;
            case DayOfWeek.Wednesday: CSTitle = ConsoleColor.Green; CSContent = ConsoleColor.DarkGray; break;
            case DayOfWeek.Thursday: CSTitle = ConsoleColor.Gray; CSContent = ConsoleColor.Red; break;
            case DayOfWeek.Friday: CSTitle = ConsoleColor.Yellow; CSContent = ConsoleColor.Blue; break;
            case DayOfWeek.Saturday: CSTitle = ConsoleColor.Yellow; CSContent = ConsoleColor.Magenta; break;
            case DayOfWeek.Sunday: CSTitle = ConsoleColor.DarkMagenta; CSContent = ConsoleColor.DarkYellow; break;
        }
    }

}


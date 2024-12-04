public class Formatations
{
    public static string FormatarData(DateTime data)
    {
        return $"{data.Day.ToString().PadLeft(2, '0').Substring(0, 2)}/{data.Month.ToString().PadLeft(2, '0').Substring(0, 2)}/{data.Year}";
    }

    public static string FormatarDuracao(TimeSpan duracao)
    {
        return $"{duracao.Hours.ToString().PadLeft(2, '0').Substring(0, 2)}:{duracao.Minutes.ToString().PadLeft(2, '0').Substring(0, 2)}";
    }

    public static string FormatarHora(DateTime data)
    {
        return $"{data.Hour.ToString().PadLeft(2, '0').Substring(0, 2)}:{data.Minute.ToString().PadLeft(2, '0').Substring(0, 2)}";
    }
}
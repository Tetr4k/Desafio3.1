using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;
using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Functions
{
    public static int CalculaIdade(DateTime dataNascimento)
    {
        int qtdAnos = DateTime.Now.Year - dataNascimento.Year;
        return DateTime.Now > dataNascimento.AddYears(qtdAnos) ? qtdAnos : qtdAnos-1;
    }

    public static TimeSpan CalculaDuracao(DateTime inicio, DateTime fim)
    {
        return fim - inicio;
    }

    public static DateTime ConverteData(string data)
    {
        return DateTime.ParseExact(data, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime();
    }

    public static DateTime ConverteHorario(string hora)
    {
        return DateTime.ParseExact(hora, "HHmm", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime();
    }
}

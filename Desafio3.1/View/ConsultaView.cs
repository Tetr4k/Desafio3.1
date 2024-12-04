using System;

public class ConsultaView
{
    public static string CapturaCpf()
    {
        Console.Write("CPF: ");
        var cpf = Console.ReadLine().Trim();
        return cpf;
    }

    public static string CapturaData()
    {
        Console.Write("Data da consulta: ");
        var data = Console.ReadLine().Trim();
        return data;
    }

    public static string CapturaHoraInicial()
    {
        Console.Write("Hora inicial: ");
        var hora = Console.ReadLine().Trim();
        return hora;
    }

    public static string CapturaHoraFinal()
    {
        Console.Write("Hora final: ");
        var hora = Console.ReadLine().Trim();
        return hora;
    }

    public static string CapturaModo()
    {
        Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
        var modo = Console.ReadLine().Trim().ToUpper();
        return modo;
    }

    public static (string, string) CapturaPeriodo()
    {
        Console.Write("Data inicial: ");
        var dataInicial = Console.ReadLine().Trim();

        Console.Write("Data final: ");
        var dataFinal = Console.ReadLine().Trim();

        return (dataInicial, dataFinal);
    }
    public static string CapturaOperacao()
    {
        Console.WriteLine("Agenda");
        Console.WriteLine("1-Agendar consulta");
        Console.WriteLine("2-Cancelar agendamento");
        Console.WriteLine("3-Listar agenda");
        Console.WriteLine("4-Voltar p/ menu principal");
        return Console.ReadLine().Trim();
    }

    public static void ListarConsultas(List<Consulta> consultas, List<Paciente> pacientes)
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("   Data    H.Ini H.Fim Tempo Nome                  Dt.Nasc.");
        Console.WriteLine("-------------------------------------------------------------");
        
        foreach (var consulta in consultas)
        {
            var paciente = PacienteDAO.getByCPF(consulta.cpf);
            Console.WriteLine($"{Formatations.FormatarData(consulta.data)} {Formatations.FormatarHora(consulta.horaInicial)} {Formatations.FormatarHora(consulta.horaFinal)} {Formatations.FormatarDuracao(Functions.CalculaDuracao(consulta.horaInicial, consulta.horaFinal))} {paciente.nome.PadRight(21).Substring(0, 21)} {Formatations.FormatarData(paciente.dataNascimento)}");
        }
    }
}
using System;

public class PacienteView
{
    public static string CapturaCpf()
    {
        Console.Write("CPF: ");
        var cpf = Console.ReadLine().Trim();
        return cpf;
    }

    public static string CapturaNome()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine().Trim().ToUpper();
        return nome;
    }

    public static string CapturaDataNascimento()
    {
        Console.Write("Data de nascimento: ");
        return Console.ReadLine().Trim();
    }

    public static string CapturaOperacao()
    {
        Console.WriteLine("Menu do Cadastro de Pacientes");
        Console.WriteLine("1-Cadastrar novo paciente");
        Console.WriteLine("2-Excluir paciente");
        Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
        Console.WriteLine("4-Listar pacientes (ordenado por Nome)");
        Console.WriteLine("5-Voltar p/ menu principal");
        return Console.ReadLine().Trim();
    }

    public static void ListarPacientes(ICollection<Paciente> pacientes, ICollection<Consulta> consultas)
    {
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("CPF         Nome                             Dt.Nasc.  Idade");
        Console.WriteLine("------------------------------------------------------------");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente.ToString());
            foreach (var consulta in consultas.Where(c => c.cpf.Equals(paciente.cpf)).ToArray()){
                Console.WriteLine($"\t{consulta.ToString()}");
            }
        }
        Console.WriteLine("------------------------------------------------------------");
    }
}

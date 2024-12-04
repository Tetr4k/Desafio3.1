using System;
using System.Text.RegularExpressions;

public class Validations
{
    public static bool ValidaCPF(string cpf, List<Paciente> pacientes)
    {
        var regex = new Regex(@"\D");
        if (regex.IsMatch(cpf)) throw new Exception("Um CPF deve conter apenas numeros!");

        if (cpf.Length != 11) throw new Exception("O CPF deve ter 11 digitos!");

        string[] iguais = { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
        
        if (iguais.Contains(cpf)) throw new Exception("Os digitos não podem ser todos iguais!");

        var J = (int)char.GetNumericValue(cpf[9]);
        var K = (int)char.GetNumericValue(cpf[10]);

        var somaJ = cpf.Substring(0, 9).Select((digito, i) => (int)char.GetNumericValue(digito) * (10 - i)).Sum();
        var restoJ = somaJ % 11;
        if (restoJ >= 2)
        {
            if (J != 11 - restoJ) throw new Exception("CPF Invalido!");
        }
        else if (J != 0) throw new Exception("CPF Invalido!");

        var somaK = cpf.Substring(0, 10).Select((digito, i) => (int)char.GetNumericValue(digito) * (11 - i)).Sum();
        var restoK = somaK % 11;

        if (restoK >= 2)
        {
            if (K != 11 - restoK) throw new Exception("CPF Invalido!");
        }
        else if (K != 0) throw new Exception("CPF Invalido!");

        var paciente = PacienteDAO.getByCPF(cpf);
        if (paciente != null) throw new Exception("Ja existe um paciente com esse CPF");

        return true;
    }
    public static bool ValidaNome(string nome)
    {
        if (nome.Length < 5) throw new Exception("Nome Invalido");

        return true;
    }
    public static bool ValidaDataNascimento(DateTime data)
    {
        if (Functions.CalculaIdade(data) < 13) throw new Exception("O paciente deve ter mais que 13 anos de idade!");

        return true;
    }

    public static bool ValidaDataConsulta(DateTime data)
    {
        if (data < DateTime.Now) throw new Exception("A data deve ser futura!");

        return true;
    }

    public static bool ValidaHorario(string hora)
    {
        if (hora == null || hora.Length == 0) throw new Exception("Digite um horario");
        var regex = new Regex(@"\D");
        if (regex.IsMatch(hora)) throw new Exception("Um horario deve conter apenas numeros!");

        string[] validos = ["00", "15", "30", "45"];
        var minutos = hora.Substring(2, 2);
        if (!validos.Contains(minutos)) throw new Exception("O agendamento deve ser feito em intervalos de 15 em 15 minutos!");

        return true;
    }

    public static bool VerificaAgendamento(Paciente paciente, List<Consulta> consultas)
    {
        var consulta = ConsultaDAO.getByCPF(paciente.cpf);
        if (consulta != null) throw new Exception("Pacientes com consultas agendadas não podem ser excluidos");

        return true;
    }

    public static bool VerificaDisponibilidade(DateTime data, DateTime horaInicial, DateTime horaFinal, string cpf, List<Consulta> consultas)
    {
        DateTime abertura = DateTime.ParseExact("0800", "HHmm", System.Globalization.CultureInfo.InvariantCulture);
        DateTime encerramento = DateTime.ParseExact("1900", "HHmm", System.Globalization.CultureInfo.InvariantCulture);

        if (horaInicial < abertura || horaFinal > encerramento) throw new Exception("O agendamento deve ser feito dentro do horario de funcionamento do consultório!(8:00 - 19:00)");

        var consulta1 = ConsultaDAO.getByCPF(cpf);
        if (consulta1 != null) throw new Exception("O Paciente ja possui uma consulta marcada!");

        var consulta2 = consultas.Where(c => c.data == data && ((horaInicial > c.horaInicial && horaInicial < c.horaFinal) || (horaFinal > c.horaInicial && horaFinal < c.horaFinal)));

        return true;
    }

    public static bool VerificaConsulta(Consulta consulta)
    {
        if (consulta == null) throw new Exception("Não há consulta neste horario!");
        return true;
    }
}
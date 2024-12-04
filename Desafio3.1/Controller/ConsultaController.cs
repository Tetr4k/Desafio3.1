using System;

public class ConsultaController
{
	public List<Consulta> consultas;
	public ConsultaController()
	{
		consultas = ConsultaDAO.getAll();
	}

    public void CriarConsulta(List<Paciente> pacientes)
    {
        string cpf;
        DateTime dataConsulta, horaIncial, horaFinal;
        do
        {
            try
            {
                cpf = ConsultaView.CapturaCpf();
                //Validations.ExistePaciente(cpf);

                var paciente = PacienteDAO.getByCPF(cpf);
                if (paciente == null) throw new Exception($"Ja existe um paciente com o cpf: {cpf}");
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro {e.Message}");
                continue;
            }
        } while (true);

        do
        {
            try
            {
                var data = ConsultaView.CapturaData();
                dataConsulta = Functions.ConverteData(data);
                Validations.ValidaDataConsulta(dataConsulta);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro {e.Message}");
                continue;
            }
        } while (true);

        do
        {
            try
            {
                var hora = ConsultaView.CapturaHoraInicial();
                Validations.ValidaHorario(hora);
                horaIncial = Functions.ConverteHorario(hora);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro {e.Message}");
                continue;
            }
        } while (true);

        do
        {
            try
            {
                var hora = ConsultaView.CapturaHoraFinal();
                Validations.ValidaHorario(hora);
                horaFinal = Functions.ConverteHorario(hora);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro {e.Message}");
                continue;
            }
        } while (true);

        Validations.VerificaDisponibilidade(dataConsulta, horaIncial, horaFinal, cpf, consultas);
        var consulta = new Consulta(cpf, dataConsulta, horaIncial, horaFinal);
        ConsultaDAO.add(consulta);
        consultas = ConsultaDAO.getAll();
    }

    public bool ExcluirConsulta()
    {
        try
        {
            var cpf = ConsultaView.CapturaCpf();

            var data = ConsultaView.CapturaData();
            var dataConsulta = Functions.ConverteData(data);

            var hora = ConsultaView.CapturaHoraInicial();
            var horaInicial = Functions.ConverteHorario(hora);

            var consulta = consultas.Where(c => c.data == dataConsulta).First(c => c.horaInicial == horaInicial);

            Validations.VerificaConsulta(consulta);
            ConsultaDAO.delete(cpf, dataConsulta, horaInicial);
            consultas = ConsultaDAO.getAll();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro {e.Message}");
            return false;
        }
    }

    public void ListarAgenda(List<Paciente> pacientes)
    {
        var modo = ConsultaView.CapturaModo();
        if (modo == "P")
        {
            var (inicio, fim) = ConsultaView.CapturaPeriodo();

            var dataInicial = Functions.ConverteData(inicio);
            var dataFinal = Functions.ConverteData(fim);

            var periodo = ConsultaDAO.getPeriodo(dataInicial, dataFinal);
            ConsultaView.ListarConsultas(periodo, pacientes);
        }

        if (modo == "T")
        {
            consultas = ConsultaDAO.getAll();
            ConsultaView.ListarConsultas(consultas, pacientes);
        }
    }
    public void EscolheOperacao(PacienteController pacienteController)
    {
        string line = null;
        do
        {
            switch (line)
            {
                case "1":
                    this.CriarConsulta(pacienteController.pacientes);
                    break;
                case "2":
                    this.ExcluirConsulta();
                    break;
                case "3":
                    this.ListarAgenda(pacienteController.pacientes);
                    break;
            }

        } while ((line = ConsultaView.CapturaOperacao()) != null && line != "4");
    }
}

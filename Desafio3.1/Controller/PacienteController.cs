using System;
public class PacienteController
{
	public List<Paciente> pacientes { get; private set; }
	public PacienteController()
	{
		pacientes = PacienteDAO.getAll();
	}

    public void CriarPaciente()
    {
        string cpf, nome;
        DateTime dataNascimento;
        do
        {
            try
            {
                cpf = PacienteView.CapturaCpf();
                Validations.ValidaCPF(cpf, pacientes);
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
                nome = PacienteView.CapturaNome();
                Validations.ValidaNome(nome);
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
                var data = PacienteView.CapturaDataNascimento();
                dataNascimento = Functions.ConverteData(data);
                Validations.ValidaDataNascimento(dataNascimento);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro {e.Message}");
                continue;
            }
        } while (true);

        var paciente = new Paciente(cpf, nome, dataNascimento);
        PacienteDAO.add(paciente);
        pacientes = PacienteDAO.getAll();
    }

    public bool ExcluirPaciente(List<Consulta> consultas)
    {
        try
        {
            var cpf = PacienteView.CapturaCpf();

            var paciente = PacienteDAO.getByCPF(cpf);

            Validations.VerificaAgendamento(paciente, consultas);

            PacienteDAO.delete(cpf);
            pacientes = PacienteDAO.getAll();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro {e.Message}");
            return false;
        }
    }

    public void ListarPacientesPorCPF(List<Consulta> consultas)
    {
        var pacientesOrdenados = PacienteDAO.getOrderedByCPF();
        PacienteView.ListarPacientes(pacientesOrdenados, consultas);
    }

    public void ListarPacientesPorNome(List<Consulta> consultas)
    {
        var pacientesOrdenados = PacienteDAO.getOrderedByName();
        PacienteView.ListarPacientes(pacientesOrdenados, consultas);
    }

    public void EscolheOperacao(ConsultaController consultaController)
    {
        string line = null;
        do
        {
            switch (line)
            {
                case "1":
                    this.CriarPaciente();
                    break;
                case "2":
                    this.ExcluirPaciente(consultaController.consultas);
                    break;
                case "3":
                    this.ListarPacientesPorCPF(consultaController.consultas);
                    break;
                case "4":
                    this.ListarPacientesPorCPF(consultaController.consultas);
                    break;
            }

        } while ((line = PacienteView.CapturaOperacao()) != null && line != "5");
    }
}

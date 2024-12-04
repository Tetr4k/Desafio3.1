using System.ComponentModel.DataAnnotations;

public class Consulta
{
    [Key]
    public string cpf { get; private set; }
	public DateTime data { get; private set; }
	public DateTime horaInicial { get; private set; }
	public DateTime horaFinal { get; private set; }
	public Consulta(string cpf, DateTime data, DateTime horaInicial, DateTime horaFinal)
	{
        this.cpf = cpf;
        this.data = data;
        this.horaInicial = horaInicial;
		this.horaFinal = horaFinal;
	}

    public override string ToString()
    {
        return $"Agendado para: {Formatations.FormatarData(data)}\n\t\t {Formatations.FormatarHora(horaInicial)} às {Formatations.FormatarHora(horaFinal)}";
    }
}
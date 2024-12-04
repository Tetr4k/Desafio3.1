using System.ComponentModel.DataAnnotations;

public class Paciente
{
	[Key]
    public string cpf { get; private set; }
	public string nome { get; private set; }
	public DateTime dataNascimento { get; private set; }

	public int idade {
		get { return Functions.CalculaIdade(this.dataNascimento); }
	}

	public Paciente(string cpf, string nome, DateTime dataNascimento)
	{
		this.cpf = cpf;
		this.nome = nome;
		this.dataNascimento = dataNascimento;
	}

	public override string ToString()
	{
		return $"{cpf} {nome.PadRight(32).Substring(0, 32)} {Formatations.FormatarData(dataNascimento)}  {idade.ToString().PadLeft(3).Substring(0, 3)}";
	}
}

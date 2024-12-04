// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

PacienteController pacienteController = new PacienteController();
ConsultaController consultaController = new ConsultaController();

string line = null;

do
{
    switch (line)
    {
        case "1":
            pacienteController.EscolheOperacao(consultaController);
            break;
        case "2":
            consultaController.EscolheOperacao(pacienteController);
            break;
    }
    Console.WriteLine("Menu Principal");
    Console.WriteLine("1-Cadastro de pacientes");
    Console.WriteLine("2-Agenda");
    Console.WriteLine("3-Fim");
} while ((line = Console.ReadLine()) != null && line != "3");
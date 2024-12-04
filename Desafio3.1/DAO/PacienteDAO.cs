using System;

public class PacienteDAO
{
/*    public PacienteDAO()
    {

    }*/

    public static Paciente getByCPF(string cpf)
    {
        using (var context = new ConsultorioDbContext())
        {
            var paciente = (from p in context.Pacientes where p.cpf == cpf select p).ToList().FirstOrDefault();

            return paciente;
        }
    }

    public static List<Paciente> getAll()
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from p in context.Pacientes select p).ToList();
        }
    }

    public static List<Paciente> getOrderedByName()
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from p in context.Pacientes orderby p.nome select p).ToList();
        }
    }

    public static List<Paciente> getOrderedByCPF()
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from p in context.Pacientes orderby p.cpf select p).ToList();
        }
    }

    public static bool add(Paciente paciente)
    {
        using (var context = new ConsultorioDbContext())
        {
            context.Pacientes.Add(paciente);
            context.SaveChanges();
        }
        return true;
    }

    public static bool delete(string cpf)
    {
        using (var context = new ConsultorioDbContext())
        {
            var paciente = (from p in context.Pacientes where p.cpf == cpf select p).ToList().First();

            context.Pacientes.Remove(paciente);
            context.SaveChanges();
        }
        return true;
    }
}
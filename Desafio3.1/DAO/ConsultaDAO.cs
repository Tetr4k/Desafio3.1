using System;

public class ConsultaDAO
{
    public static Consulta getByCPF(string cpf)
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from c in context.Consultas where c.cpf == cpf select c).ToList().First();
        }
    }

    public static List<Consulta> getAll()
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from c in context.Consultas select c).ToList();
        }
    }
    public static List<Consulta> getPeriodo(DateTime inicio, DateTime fim)
    {
        using (var context = new ConsultorioDbContext())
        {
            return (from c in context.Consultas where c.data >= inicio && c.data <= fim select c).ToList();
        }
    }

    public static bool add(Consulta consulta)
    {
        using (var context = new ConsultorioDbContext())
        {
            Console.WriteLine(consulta);
            context.Consultas.Add(consulta);
            context.SaveChanges();
        }
        return true;
    }

    public static bool delete(string cpf, DateTime data, DateTime horaInicial)
    {
        using (var context = new ConsultorioDbContext())
        {
            var consulta = (from c in context.Consultas where c.cpf == cpf && c.data == data && c.horaInicial == horaInicial select c).ToList().First();

            context.Consultas.Remove(consulta);
            context.SaveChanges();
        }
        return true;
    }
}
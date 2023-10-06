using PlatzyAPI.Models;

namespace PlatzyAPI.Services.Implement;

public class TareaService: ITareaService
{
    readonly TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea) 
    {
        var tareaActual = context.Find<Tarea>(id);
        if (tareaActual != null) 
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            await context.SaveChangesAsync();
        } 
    }

    public async Task Delete(Guid id) 
    {
        var tareaActual = context.Find<Tarea>(id);
        if(tareaActual != null) 
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using PlatzyAPI.Models;
using PlatzyAPI.Services;

namespace PlatzyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareaController : ControllerBase
{
    readonly ITareaService tareaService;
   

    public TareaController(ITareaService tareaService)
    {
        this.tareaService = tareaService;                       
    }

    /// <summary>
    /// Metodo para obtener las tareas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Obtener() 
    {           
        return Ok(tareaService.Get());
    }

    /// <summary>
    /// Metodo para Insertar tareas
    /// </summary>
    /// <param name="tarea"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Insertar([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();

    }

    /// <summary>
    /// Metodo para actualizar las tareas
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tarea"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Actualizar(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }

    /// <summary>
    /// Metodo para eliminar tareas
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}

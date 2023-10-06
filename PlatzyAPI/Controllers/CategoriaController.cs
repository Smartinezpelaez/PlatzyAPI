using Microsoft.AspNetCore.Mvc;
using PlatzyAPI.Models;
using PlatzyAPI.Services;
using PlatzyAPI.Services.Implement;

namespace PlatzyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    readonly ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        this.categoriaService = categoriaService;
    }

    /// <summary>
    /// Metodo para obtener las categorias
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Obtener()
    {
        return Ok(categoriaService.Get());
    }

    /// <summary>
    /// Metodo para Insertar categorias
    /// </summary>
    /// <param name="tarea"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Insertar([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();

    }

    /// <summary>
    /// Metodo para actualizar las categorias
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tarea"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Actualizar(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok();
    }

    /// <summary>
    /// Metodo para eliminar categorias
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }

}

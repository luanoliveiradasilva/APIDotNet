using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Applications.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserServices iUserServices;

    public UsersController(IUserServices iUserServices)
    {
        this.iUserServices = iUserServices;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        //TODO Adicionar status code mais adequado Exemplo; StatusCode(StatusCodes.Status204NoContent, "Não foi encontrada a base de dados");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            return Ok(await iUserServices.GetAll());
        }
        catch (ArgumentException exception)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}

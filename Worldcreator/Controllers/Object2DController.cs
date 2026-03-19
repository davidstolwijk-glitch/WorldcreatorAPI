using Microsoft.AspNetCore.Mvc;
using Worldcreator.Models;
using Worldcreator.Repositories;
using Worldcreator.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Worldcreator.Controllers;

[ApiController]
[Route("environments/{environmentId}/objects")]
[Consumes("application/json")]
[Produces("application/json")]
public class Object2DController : ControllerBase
{
    private readonly I2D_ObjectRepositroy _Object2DRepository;
    private readonly IAuthenticationService _authenticationService;

    public Object2DController(I2D_ObjectRepositroy object2dRepo, IAuthenticationService authenticationService)
    {
        _Object2DRepository = object2dRepo;
        _authenticationService = authenticationService;
    }

    [HttpGet(Name = "Get2DObjects")]
    public async Task<ActionResult<List<Object2D>>> GetAsync()
    {
        var Object2d = await _Object2DRepository.SelectAsync();
        return Ok(Object2d);
    }

    [HttpGet("{1}", Name = "GetEnvironment_byID")]
    public async Task<ActionResult<Object2D>> GetByIdAsync(Guid Environmentid)
    {
        var Object2d = await _Object2DRepository.SelectAsync(Environmentid);
        

        if (Object2d == null)
            return NotFound(new ProblemDetails { Detail = $"2d Object {Environmentid} not found" });

        return Ok(Environmentid);
    }



    [HttpPost(Name = "Add2DObject")]
    public async Task<ActionResult<Object2D>> AddAsync(Guid environmentid,[FromBody] Object2D object2D)
    {
        object2D.EnvironmentId = environmentid;
        object2D.Id = Guid.NewGuid();

            
        await _Object2DRepository.InsertAsync(object2D);

        return Ok(object2D);
    }

    [HttpPut("{Object2D_id}", Name = "Update2DObject")]
    public async Task<ActionResult<Object2D>> UpdateAsync(Guid Object2D_id, Object2D object2D)
    {
        var Object2d = await _Object2DRepository.SelectAsync(Object2D_id);

        if (Object2d == null)
            return NotFound(new ProblemDetails { Detail = $"2D Object {Object2D_id} not found" });


        await _Object2DRepository.UpdateAsync(object2D);

        return Ok(object2D);
    }

    [HttpDelete("{Object2D_id}", Name = "Delete2DObject")]
    public async Task<ActionResult> DeleteAsync(Guid Object2D_id)
    {
        var object2D = await _Object2DRepository.SelectAsync(Object2D_id);


        if (object2D == null)
            return NotFound(new ProblemDetails { Detail = $"2D Object {Object2D_id} not found" });

        await _Object2DRepository.DeleteAsync(Object2D_id);

        return Ok();
    }

    private ActionResult Forbid(ProblemDetails problemDetails)
    {
        throw new NotImplementedException();
    }
}
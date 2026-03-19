using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Worldcreator.Models;
using Worldcreator.Repositories;
using Worldcreator.Services;

namespace Worldcreator.Controllers;

[Authorize] // geeft aan dat er een bepaalde authorizatie nodig om deze classe te gebruiken
[ApiController]
[Route("environments")]
[Consumes("application/json")]  // MAKES  sure that only json is accepted. It reduces the attack surface
[Produces("application/json")]

public class Environment2DController : ControllerBase
{
    private readonly IEnvironment2DRepository _environment2DRepository;
    private readonly IAuthenticationService _authenticationService;

    public Environment2DController(IEnvironment2DRepository enviorment2DRepository, IAuthenticationService authenticationService)
    {
        _environment2DRepository = enviorment2DRepository;
        _authenticationService = authenticationService;
    }


    /// <summary>
    ///  nog niet duidelijk
    /// </summary>

    [HttpGet(Name = "GetEnvironment")]
    public async Task<ActionResult<List<Environment2D>>> GetAsync()
    {
        var environment = await _environment2DRepository.SelectAsync();
        return Ok(environment);
    }


    /// <summary>
    ///  Zoeken van een enviorment
    /// </summary>


    [HttpGet("{environmentid}", Name = "GetEnvironmentId")]
    public async Task<ActionResult<Environment2D>> GetByIdAsync(Guid environmentid)
    {
        var environment = await _environment2DRepository.SelectAsync(environmentid);

        if (environment == null)
            return NotFound(new ProblemDetails { Detail = $"Environment {environmentid} not found" });

        return Ok(environment);
    }



    /// <summary>
    ///  toevoegen van een enviorment
    /// </summary>

    [HttpPost(Name = "CreateEnvironment")] 
    public async Task<ActionResult<Environment2D>> AddAsync(Environment2D environment)
    {
        _authenticationService.GetCurrentAuthenticatedUserId();
        environment.Id = Guid.NewGuid();
        environment.UserId = _authenticationService.GetCurrentAuthenticatedUserId(); // user id word gevuld door de token.


        await _environment2DRepository.InsertAsync(environment);

        return Ok (environment);
    }



    /// <summary>
    ///  update van een enviorment
    /// </summary>
    
    [HttpPut("{environmentid}", Name = "UpdateEnvironment")]
    public async Task<ActionResult<Environment2D>> UpdateAsync(Guid environmentId, Environment2D environment)
    {
        _authenticationService.GetCurrentAuthenticatedUserId();
        var existingEnviorment = await _environment2DRepository.SelectAsync(environmentId);
        var userId = _authenticationService.GetCurrentAuthenticatedUserId();


        if (existingEnviorment == null)
            return NotFound(new ProblemDetails { Detail = $"Environment {environmentId} not found" });

        if (environment.Id != environmentId)
            return Conflict(new ProblemDetails { Detail = "The id of the Environment in the route does not match the id of the Environment in the body" });

        await _environment2DRepository.UpdateAsync(environment);

        return Ok(environment);
    }


    /// <summary>
    ///  Deleten van een enviorment
    /// </summary>

    [HttpDelete("{environmentId}", Name = "DeleteEnvironment")]
    public async Task<ActionResult> DeleteAsync(Guid environmentId)
    {
        var environment = await _environment2DRepository.SelectAsync(environmentId);
        var userId = _authenticationService.GetCurrentAuthenticatedUserId();


        if (environment == null)
            return NotFound(new ProblemDetails { Detail = $"Environment {environmentId} not found" });

        if (environment.UserId != userId)
            return Forbid();

        await _environment2DRepository.DeleteAsync(environmentId);

        return Ok();
    }
}
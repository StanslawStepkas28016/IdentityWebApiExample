using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWebApi.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    public IdentityController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> FetchData()
    {
        var userClaims = HttpContext.User.Claims;
        return StatusCode(StatusCodes.Status200OK, String.Join(" ", userClaims));
    }
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRole([FromBody] string roleName)
    {
        await _roleService.AddRoleAsync(roleName);
        return Ok();
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
    {
        await _roleService.AssignRoleToUserAsync(dto.UserId, dto.RoleId);
        return Ok();
    }
}

public class AssignRoleDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

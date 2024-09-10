using Microsoft.EntityFrameworkCore;

public class RoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddRoleAsync(string roleName)
    {
        var role = new Role { Ad = roleName };
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
    }

    public async Task AssignRoleToUserAsync(int userId, int roleId)
    {
        var userRole = new UserRole { UserId = userId, RoleId = roleId };
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Role>> GetRolesForUserAsync(int userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role)
            .ToListAsync();
    }
}

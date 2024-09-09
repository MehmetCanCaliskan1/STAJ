public class UserService
{
    private readonly AppDbContext _context;
    private readonly EmailService _emailService;

    public UserService(AppDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task RegisterUserAsync(RegisterUserDto userDto)
    {
        if (userDto.Password != userDto.ConfirmPassword)
            throw new Exception("Passwords do not match.");

        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            IsActive = false // Email verification needed
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Send verification email
        _emailService.SendVerificationEmail(user.Email);
    }
}

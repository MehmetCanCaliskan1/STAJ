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
        if (userDto.Sifre != userDto.Tekrar_Sifre)
            throw new Exception("Passwords do not match.");

        var user = new User
        {
            Ad = userDto.Ad,
            Soyad = userDto.Soyad,
            Kullanıcı_Adı = userDto.Kullanıcı_Adı,
            Email = userDto.Email,
            TelNo = userDto.TelNo,
            HashPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Sifre),
            IsActive = false 
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        
        _emailService.SendVerificationEmail(user.Email);
    }
}

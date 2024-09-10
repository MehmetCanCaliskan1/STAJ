#pragma warning disable CA1050 // Declare types in namespaces
public class EmailService : IEmailService

{
    public void SendVerificationEmail(string email)
    {
        Console.WriteLine("Doğrulama Email'i");
    }
}

public interface IEmailService
{
}
using FluentValidation;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Sifre).NotEmpty().WithMessage("Password is required.");
        RuleFor(x => x.Tekrar_Sifre).Equal(x => x.Sifre).WithMessage("Passwords do not match.");
        
    }
}

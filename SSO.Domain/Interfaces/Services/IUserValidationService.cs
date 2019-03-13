using FluentValidation.Results;

namespace SSO.Domain.Interfaces.Services
{
    public interface IUserValidationService
    {
        ValidationResult Validation(string username, string password);
    }
}

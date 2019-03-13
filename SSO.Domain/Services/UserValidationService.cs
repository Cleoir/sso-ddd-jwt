using FluentValidation.Results;
using SSO.Domain.Entity;
using SSO.Domain.Interfaces.Services;
using SSO.Domain.Validation;

namespace SSO.Domain.Services
{
    public class UserValidationService: IUserValidationService
    {
        public ValidationResult Validation(string username, string password)
        {
            UserValidation validator = new UserValidation();

            return validator.Validate(new User { Name = username, Password = password });
        }
    }
}

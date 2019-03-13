using FluentValidation;
using SSO.Domain.Entity;
using System.Text.RegularExpressions;

namespace SSO.Domain.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        private const int MinName = 2;
        private const int MaxName = 250;

        private const int MinPassword = 6;
        private const int MaxPassword = 12;

        public UserValidation()
        {
            RuleFor(user => user.Name).NotNull().WithMessage("Please specify a name");
            RuleFor(user => user.Name).NotEmpty().WithMessage("Please specify a name");
            RuleFor(user => user.Name).Length(MinName, MaxName).WithMessage("Min 2 Max 250");
            RuleFor(user => user.Name).Must(IsValidName).WithMessage("Please specify a valid name");

            RuleFor(user => user.Password).NotNull().WithMessage("Please specify a password");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Please specify a password");
            RuleFor(user => user.Name).Length(MinPassword, MaxPassword).WithMessage("Min 6 Max 12");
            RuleFor(user => user.Password).Must(IsValidPassword).WithMessage("Please specify a valid password");
        }

        private bool IsValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,12}$");
            Match match = regex.Match(password);

            return match.Success;
        }

        private bool IsValidName(string username)
        {
            Regex regex = new Regex(@"[a-zA-Z\u00C0-\u00FF ]+$");
            Match match = regex.Match(username);

            return match.Success;
        }
    }

}

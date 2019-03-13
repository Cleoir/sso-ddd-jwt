using FluentValidation.Results;
using SSO.Domain.Interfaces.Repositories;
using SSO.Domain.Interfaces.Services;
using SSO.Domain.Services.Base;

namespace SSO.Domain.Services
{
    public class UserService: BaseService, IUserService
    {
        public bool CheckUser(string username, string password)
        {
            var _userValidationService = GetInstance<IUserValidationService>();

            ValidationResult objUser = _userValidationService.Validation(username, password);

            return objUser.IsValid ? ValidationExistDataBase(username, password) : false;
        }

        private bool ValidationExistDataBase(string username, string password)
        {
            var _userRepository = GetInstance<IUserRepository>();

            return _userRepository.ExistUser(username, password);
        }
    }
}

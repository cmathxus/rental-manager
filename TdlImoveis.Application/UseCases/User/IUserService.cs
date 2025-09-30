using tdlimoveis.Application.UseCases;
using tdlimoveis.Application.DTOs;

namespace TdlImoveis.Application.UseCases
{
    public interface IUserService
    {
        public Task<ServiceResult<UserReadDto>> Register(UserCreateDto userCreateDto);
        public Task<ServiceResult<string>> Login(UserLoginDto userLoginDto);
    }
}
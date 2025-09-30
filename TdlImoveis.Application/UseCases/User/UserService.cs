using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TdlImoveis.Application.UseCases
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserPasswordService _passwordService;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, IMapper mapper, IUserPasswordService passwordService, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordService = passwordService;
            _configuration = configuration;
        }

        public async Task<ServiceResult<UserReadDto>> Register(UserCreateDto userCreateDto)
        {
            try
            {
                var existingUser = await _repository.GetByEmailAsync(userCreateDto.Email);
                if (existingUser != null)
                    return ServiceResult<UserReadDto>.Fail($"Usuário com e-mail {userCreateDto.Email} já existe!");

                var user = _mapper.Map<User>(userCreateDto);

                user.PasswordHash = _passwordService.HashPassword(user, userCreateDto.Password);

                await _repository.AddAsync(user);
                
                return ServiceResult<UserReadDto>.Success(_mapper.Map<UserReadDto>(user));
            }
            catch (Exception ex)
            {
                return ServiceResult<UserReadDto>.Fail($"Não foi possivel criar o novo usuário! {ex.Message}");
            }
        }

        public async Task<ServiceResult<string>> Login(UserLoginDto userLoginDto)
        {
            try
            {
                // busca usuário pelo username (ou email)
                var user = await _repository.GetByUsernameAsync(userLoginDto.Username);
                if (user == null)
                    return ServiceResult<string>.Fail("Usuário não encontrado");

                // verifica senha
                var valid = _passwordService.VerifyPassword(user, user.PasswordHash, userLoginDto.Password);
                if (!valid)
                    return ServiceResult<string>.Fail("Senha inválida");

                // cria claims para o token
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserId", user.Id.ToString())
                };
                
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return ServiceResult<string>.Success(tokenString);
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.Fail($"Não foi possível realizar o login! {ex.Message}");
            }
        }
    }
}
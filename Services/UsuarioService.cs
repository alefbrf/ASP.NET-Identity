using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Usuarios_API.Data.Dtos;
using Usuarios_API.Models;

namespace Usuarios_API.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _siginInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> siginInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _siginInManager = siginInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            SignInResult result = await _siginInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado!");
            }

            var usuario = _siginInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}

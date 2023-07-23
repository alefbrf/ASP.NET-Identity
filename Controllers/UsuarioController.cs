using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Usuarios_API.Data.Dtos;
using Usuarios_API.Models;
using Usuarios_API.Services;

namespace Usuarios_API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);

        return Ok("Usuário cadastrado");

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);

        return Ok(token);
    }
}

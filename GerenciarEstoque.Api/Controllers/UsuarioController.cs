using GerenciarEstoque.Api.Models.Usuarios.Request;
using GerenciarEstoque.Api.Models.Usuarios.Response;
using GerenciarEstoque.Aplicacao;
using GerenciarEstoque.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarEstoque.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioAplicacao _usuarioAplicacao;

    public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
    {
        _usuarioAplicacao = usuarioAplicacao;
    }

    [HttpPost]
    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] UsuarioCriarRequest usuarioCriarRequest)
    {
        try
        {
            Usuario usuario = new Usuario(usuarioCriarRequest.Nome, usuarioCriarRequest.Email, usuarioCriarRequest.DataNascimento, usuarioCriarRequest.Senha);

            await _usuarioAplicacao.Criar(usuario);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Remover/{id}")]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        try
        {
            await _usuarioAplicacao.Remover(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<IActionResult> AtualizarSenha([FromBody] UsuarioAtualizarSenhaRequest usuario)
    {
        try
        {
            await _usuarioAplicacao.AtualizarSenha(usuario.Id, usuario.SenhaAntiga, usuario.SenhaNova);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("VerificarLogin")]
    public async Task<IActionResult> VerificarLogin([FromBody] UsuarioRequest usuarioRequest)
    {
        try
        {
            int id = await _usuarioAplicacao.ValidarLogin(usuarioRequest.Email, usuarioRequest.Senha);

            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ObterUsuario/{id}")]
    public async Task<IActionResult> ObterUsuario([FromRoute] int id)
    {
        try
        {
            Usuario usuarioTeste = await _usuarioAplicacao.ObterUsuario(id);

            UsuarioResponse usuario = new UsuarioResponse();

            usuario.Nome = usuarioTeste.Nome;
            usuario.Email = usuarioTeste.Email;
            usuario.DataNascimento = usuarioTeste.DataNascimento;

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("AtualizarInformacoes")]
    public async Task<IActionResult> AtualizarInformacoes([FromBody] UsuarioAtualizarRequest usuarioRequest)
    {
        try
        {
            await _usuarioAplicacao.AtualizarInformacoes(usuarioRequest.UsuarioId, usuarioRequest.Nome, usuarioRequest.DataNascimento);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("RemoverFoto/{id}")]
    public async Task<IActionResult> RemoverFoto([FromRoute] int id)
    {
        try
        {
            await _usuarioAplicacao.RemoverFoto(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("AtualizarFoto/{usuarioId}")]
    public async Task<IActionResult> AtualizarFoto([FromRoute] int usuarioId, [FromForm] IFormFile fotoPerfil)
    {
        try
        {
            if (fotoPerfil == null || fotoPerfil.Length == 0)
            {
                throw new Exception("Nenhuma foto foi enviada.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await fotoPerfil.CopyToAsync(memoryStream);
                byte[] fotoBytes = memoryStream.ToArray();

                await _usuarioAplicacao.AtualizarFoto(usuarioId, fotoBytes);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ObterFotoPerfil/{id}")]
    public async Task<IActionResult> ObterFotoPerfil([FromRoute] int id)
    {
        try
        {
            var usuario = await _usuarioAplicacao.ObterUsuario(id);

            if (usuario.FotoPerfil == null)
            {
                return Ok(null);
            }

            return File(usuario.FotoPerfil, "image/jpeg");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
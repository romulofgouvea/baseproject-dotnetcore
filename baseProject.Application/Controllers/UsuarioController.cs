using BaseProject.Application.Helpers;
using BaseProject.Domain.Entities;
using BaseProject.Domain.Models;
using BaseProject.Services.Services;
using BaseProject.Services.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BaseProject.Application.Controllers
{
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly NHibernate.ISession Sessao;
        public UsuarioController(NHibernate.ISession sessao)
        {
            Sessao = sessao;
        }

        /// <summary>
        /// Exemplo de método GET.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET
        ///     /v1/Generic/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Expecificação do retorno do método</returns>
        /// <response code="200">Requisição efetuada com sucesso</response>
        /// <response code="400">Erro ao processar a requisição</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("v1/[controller]/{id:int}")]
        [ProducesResponseType(typeof(MResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Id inválido.");
                }
                var usuarioService = new BaseService<Usuario>(Sessao);
                var usuario = usuarioService.Get(id);

                if (usuario == null)
                {
                    return StatusCode(
                        (int)HttpStatusCode.NotFound,
                        ResponseHelper.Create("Usuário não encontrado")
                    );
                }

                return StatusCode((int)HttpStatusCode.OK, ResponseHelper.Create("Sucesso", usuario.ToModel()));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ResponseHelper.Create(e.Message));
            }
        }


        /// <summary>
        /// Exemplo de método POST.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST 
        ///     /v1/Generic
        ///     {
        ///        "nome": "Nome usuário",
        ///        "cpf": "00000000000",
        ///        "dataNascimento": "01/01/2000",
        ///        "senha": "123",
        ///     }
        ///
        /// </remarks>
        /// <param name="novoUsuario"></param>
        /// <returns>Expecificação do retorno do método</returns>
        /// <response code="201">Entidade persistida no banco</response>
        /// <response code="400">Erro ao processar a requisição</response>
        [HttpPost("v1/[controller]")]
        [ProducesResponseType(typeof(MResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]MUsuario novoUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(novoUsuario.Cpf))
                {
                    throw new Exception("Cpf inválido.");
                }

                var usuario = new Usuario
                {
                    Cpf = novoUsuario.Cpf,
                    DataNascimento = novoUsuario.DataNascimento.Date,
                    Nome = novoUsuario.Nome,
                    Senha = novoUsuario.Senha
                };

                var usuarioService = new BaseService<Usuario>(Sessao);
                using (var transaction = Sessao.BeginTransaction())
                {
                    try
                    {
                        usuarioService.Save<GenericValidator<Usuario>>(usuario);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao salvar usuário.");
                    }

                }

                return StatusCode(
                    (int)HttpStatusCode.OK,
                    ResponseHelper.Create("Sucesso", novoUsuario)
                );
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ResponseHelper.Create(e.Message));
            }
        }
    }
}

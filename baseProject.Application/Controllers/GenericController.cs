using BaseProject.Application.Helpers;
using BaseProject.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BaseProject.Application.Controllers
{
    [Produces("application/json")]
    public class GenericController : Controller
    {
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
        [HttpGet("v1/[controller]/{id:int}")]
        [ProducesResponseType(typeof(MResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var teste = new MResult { Message = "teste" };
                if (id == 0)
                {
                    throw new Exception("Id inválido.");
                }
                return StatusCode((int)HttpStatusCode.OK, ResponseHelper.Create("Sucesso"));
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
        ///        "id": 1,
        ///        "nome": "Item1",
        ///        "ativo": true
        ///     }
        ///
        /// </remarks>
        /// <param name="paramExample"></param>
        /// <returns>Expecificação do retorno do método</returns>
        /// <response code="201">Entidade persistida no banco</response>
        /// <response code="400">Erro ao processar a requisição</response>
        [HttpPost("v1/[controller]")]
        [ProducesResponseType(typeof(MResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]MGenerico paramExample)
        {
            try
            {
                if (paramExample.Id == 0)
                {
                    throw new Exception("Id inválido.");
                }
                return StatusCode(
                    (int)HttpStatusCode.OK,
                    ResponseHelper.Create("Sucesso", paramExample)
                );
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ResponseHelper.Create(e.Message));
            }
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.EnterpriseCommands;
using SkillsCore.Domain.Models.Response;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [ApiController]
    [Route("Enterprise")]
    public class EnterpriseController : ControllerBase
    {
        #region Properties

        public readonly IEnterpriseQuery _enterpriseQuery;
        public readonly IMediator _mediator;

        #endregion

        #region Constructor

        public EnterpriseController(IEnterpriseQuery enterpriseQuery, IMediator mediator)
        {
            _enterpriseQuery = enterpriseQuery;
            _mediator = mediator;
        }   

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos as empresas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getEnterprises", Name = "GetAllEnterprise")]
        public async Task<IActionResult> GetEnterprises()
        {
            var result = await _enterpriseQuery.GetAllEnterprises();

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "Enterprises not found", null));

            return new OkObjectResult(new ResponseApi(true, "Enterprises retrieved successul.", result));
        }

        #endregion

        #region Post

        /// <summary>
        /// Cria uma nova empresa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createEnterprises", Name = "CreateEnterprise")]
        public async Task<IActionResult> GetEnterprises([FromBody] CreateEnterpriseCommand createEnterprise)
        {
            var result = await _mediator.Send(createEnterprise);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita uma empresa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateEnterprises", Name = "UpdateEnterprise")]
        public async Task<IActionResult> UpdateEnterprises([FromBody] UpdateEnterpriseCommand updateEnterprise)
        {
            var result = await _mediator.Send(updateEnterprise);

            return Ok(result);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Remove (logicamente) uma empresa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("deleteEnterprises/{idEnterprise}", Name = "DeleteEnterprise")]
        public async Task<IActionResult> DeleteEnterprises([FromRoute] DeleteEnterpriseCommand deleteEnterprise)
        {
            var result = await _mediator.Send(deleteEnterprise);

            return Ok(result);
        }

        #endregion

    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.AcademicFormationCommands;
using SkillsCore.Domain.Models.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [ApiController]
    [Route("AcademicFormation")]
    public class AcademicFormationController : ControllerBase
    {
        #region Properties

        public readonly IAcademicFormationQuery _academicFormationQuery;
        public readonly IMediator _mediator;

        #endregion

        #region Constructor

        public AcademicFormationController(IAcademicFormationQuery academicFormationQuery, IMediator mediator)
        {
            _academicFormationQuery = academicFormationQuery;
            _mediator = mediator;
        }

        #endregion

        #region Get

        /// <summary>
        /// Retorna todas as formações do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getAcademic/{idUser}", Name = "GetAllAcademicFormationByUser")]
        public async Task<IActionResult> GetAllAcademicFormationByUser([FromRoute] Guid idUser)
        {
            var result = await _academicFormationQuery.GetUserFormationById(idUser);

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "Academic formation not found", null));

            return new OkObjectResult(new ResponseApi(true, "Academic formation retrieved successful.", result));
        }

        #endregion

        #region Post

        /// <summary>
        /// Adiciona uma nova formação acadêmica do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createAcademicFormation", Name = "CreateAademicFormation")]
        public async Task<IActionResult> CreateAcademicFormation([FromBody] CreateListAcademicFormationCommand createFormation)
        {
            var result = await _mediator.Send(createFormation);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Atualiza a formação acadêmica do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateAcademicFormation", Name = "UpdateAademicFormation")]
        public async Task<IActionResult> UpdateAcademicFormation([FromBody] UpdateListAcademicFormationCommand updateFormation)
        {
            var result = await _mediator.Send(updateFormation);

            return Ok(result);
        }

        #endregion

        #region

        /// <summary>
        /// Remove uma formação acadêmica do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("deleteAcademicFormation/{idUser}/{idAcademicFormation}", Name = "DeleteAcademicFormation")]
        public async Task<IActionResult> DeleteAcademicFormation([FromRoute] DeleteAcademicFormationCommand deleteFormation)
        {
            var result = await _mediator.Send(deleteFormation);

            return Ok(result);
        }

        #endregion
    }
}

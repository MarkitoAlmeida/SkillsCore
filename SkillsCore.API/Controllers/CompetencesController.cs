using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.CompetenceCommands;
using SkillsCore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [Route("Competences")]
    [ApiController]
    public class CompetencesController : ControllerBase
    {
        #region Properties

        private readonly ICompetenceQuery _competencesQuery;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public CompetencesController(ICompetenceQuery competencesQuery, IMediator mediator)
        {
            _competencesQuery = competencesQuery;
            _mediator = mediator;
        }

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos as competências técnicas do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUserCompetences/{idUser}", Name = "GetAllCompetencesByUser")]
        public async Task<IActionResult> GetUserCompetences([FromRoute] Guid idUser)
        {
            var result = await _competencesQuery.GetAllCompetencesByUser(idUser);

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "User competences not found", null));

            return new OkObjectResult(new ResponseApi(true, "Users competences retrieved successul.", result));
        }

        #endregion

        #region Post

        /// <summary>
        /// Cria uma ou mais competências do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createCompetence", Name = "CreateCompetence")]
        public async Task<IActionResult> CreateCompetences([FromBody] CreateListCompetenceCommand createCompetence)
        {
            var result = await _mediator.Send(createCompetence);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita uma ou mais competências do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateCompetence", Name = "UpdateCompetence")]
        public async Task<IActionResult> UpdateCompetences([FromBody] UpdateListCompetenceCommand updateCompetence)
        {
            var result = await _mediator.Send(updateCompetence);

            return Ok(result);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Remove uma competência do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("deleteCompetence/{idUser}/{idCompetence}", Name = "DeleteAademicFormation")]
        public async Task<IActionResult> DeleteAcademicFormation([FromRoute] DeleteCompetenceCommand deleteFormation)
        {
            var result = await _mediator.Send(deleteFormation);

            return Ok(result);
        }

        #endregion

    }
}

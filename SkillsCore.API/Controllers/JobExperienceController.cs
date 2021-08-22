using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.JobExperienceCommands;
using SkillsCore.Domain.Models.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [Route("JobExperience")]
    [ApiController]
    public class JobExperienceController : ControllerBase
    {
        #region Properties

        private readonly IJobExperienceQuery _jobExperienceQuery;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public JobExperienceController(IJobExperienceQuery jobExperienceQuery, IMediator mediator)
        {
            _jobExperienceQuery = jobExperienceQuery;
            _mediator = mediator;
        }

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos as experiencias de trabalho do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUserJobExperiences/{idUser}", Name = "GetAllJobExperiencesByUser")]
        public async Task<IActionResult> GetUserCompetences([FromRoute] Guid idUser)
        {
            var result = await _jobExperienceQuery.GetAllJobExperiencesByUser(idUser);

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "User competences not found", null));

            return new OkObjectResult(new ResponseApi(true, "Users competences retrieved successul.", result));
        }

        #endregion

        #region Post

        /// <summary>
        /// Cria uma ou mais experiencias de trabalho do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createJobExperience", Name = "createJobExperience")]
        public async Task<IActionResult> CreateLanguage([FromBody] CreateListJobExperiencesCommand createCompetence)
        {
            var result = await _mediator.Send(createCompetence);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita uma ou mais experiencias de trabalho do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateJobExperience", Name = "updateJobExperience")]
        public async Task<IActionResult> UpdateLanguage([FromBody] UpdateListJobExperiencesCommand createCompetence)
        {
            var result = await _mediator.Send(createCompetence);

            return Ok(result);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Remove uma experiencia de trabalho do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("deleteJobExperience/{idUser}/{idJobExperience}", Name = "DeleteJobExperience")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] DeleteJobExperienceCommand deleteLanguage)
        {
            var result = await _mediator.Send(deleteLanguage);

            return Ok(result);
        }

        #endregion
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        /// Retorna todos as línguas do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUserLanguages/{idUser}", Name = "GetAllLanguagesByUser")]
        public async Task<IActionResult> GetUserCompetences([FromRoute] Guid idUser)
        {
            var result = await _languageQuery.GetAllLanguagesByUser(idUser);

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "User competences not found", null));

            return new OkObjectResult(new ResponseApi(true, "Users competences retrieved successul.", result));
        }

        #endregion
    }
}

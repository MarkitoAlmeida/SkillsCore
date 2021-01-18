using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.LanguageCommands;
using SkillsCore.Domain.Models.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [Route("Language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        #region Properties

        private readonly ILanguageQuery _languageQuery;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public LanguageController(ILanguageQuery languageQuery, IMediator mediator)
        {
            _languageQuery = languageQuery;
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

        #region Post

        /// <summary>
        /// Cria uma ou mais linguas do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createLanguage", Name = "CreateLanguage")]
        public async Task<IActionResult> CreateLanguage([FromBody] CreateListLanguagesCommand createCompetence)
        {
            var result = await _mediator.Send(createCompetence);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita uma ou mais linguas do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("updateLanguage", Name = "UpdateLanguage")]
        public async Task<IActionResult> UpdateLanguage([FromBody] UpdateListLanguagesCommand createCompetence)
        {
            var result = await _mediator.Send(createCompetence);

            return Ok(result);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Remove uma língua do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("deleteCompetence/{idUser}/{idLanguage}", Name = "DeleteLanguage")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] DeleteLanguageCommand deleteLanguage)
        {
            var result = await _mediator.Send(deleteLanguage);

            return Ok(result);
        }

        #endregion
    }
}

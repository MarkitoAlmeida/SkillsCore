using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [Route("SkillsDossier")]
    [ApiController]
    public class SkillsDossierController : ControllerBase
    {
        #region Properties

        private readonly ISkillsDossierService _skillsDossierService;

        #endregion

        #region Constructor

        public SkillsDossierController(ISkillsDossierService skillsDossierService) =>
            _skillsDossierService = skillsDossierService;

        #endregion

        #region Post

        /// <summary>
        /// Cria o Dossier de Compentências em PDF do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createSkillsDossier/{idUserRequested}/{idUserCreated}", Name = "CreateSkillsDossier")]
        public async Task<IActionResult> CreateSkillsDossier([FromRoute] Guid idUserRequested, Guid idUserCreated)
        {
            var result = await _skillsDossierService.CreateDossier(idUserRequested, idUserCreated);

            return Ok(result);
        }

        #endregion
    }
}

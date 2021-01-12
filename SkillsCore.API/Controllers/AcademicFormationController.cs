using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Commands.AcademicFormationCommands;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;
using System;
using System.Linq;

namespace SkillsCore.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AcademicFormationController : ControllerBase
    {
        #region Properties

        public readonly IAcademicFormationService _academicFormationServices;

        #endregion

        #region Constructor

        public AcademicFormationController(IAcademicFormationService academicFormationServices) =>
            _academicFormationServices = academicFormationServices;

        #endregion

        #region Get

        /// <summary>
        /// Retorna todas as formações do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getAcademic", Name = "GetAllAcademicFormationByUser")]
        public IActionResult GetAllAcademicFormationByUser([FromQuery] Guid id)
        {
            var result = _academicFormationServices.GetFormationByUser(id);

            if (result == null)
                return BadRequest(
                    new ResultViewModel
                    {
                        Success = false,
                        Message = "Academic formation not found",
                        Data = null
                    }
                );

            return new OkObjectResult(
                new ResultViewModel
                {
                    Success = true,
                    Message = "Academic formation retrieved successul.",
                    Data = result
                });
        }

        #endregion

        #region Post

        /// <summary>
        /// Adiciona uma nova formação acadêmica do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createAcademicFormation", Name = "CreateAademicFormation")]
        public IActionResult CreateAcademicFormation([FromBody] CreateListAcademicFormationCommand createFormation)
        {
            var result = _academicFormationServices.CreateAcademicFormation(createFormation);

            return result.Select(x => x.Success).FirstOrDefault() ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Atualiza a formação acadêmica do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("updateAcademicFormation", Name = "UpdateAademicFormation")]
        public IActionResult UpdateAcademicFormation([FromBody] UpdateListAcademicFormationCommand updateFormation)
        {
            var result = _academicFormationServices.UpdateAcademicFormation(updateFormation);

            return result.Select(x => x.Success).FirstOrDefault() ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion

        #region



        #endregion
    }
}

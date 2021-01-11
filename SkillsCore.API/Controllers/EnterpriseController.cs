using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;

namespace SkillsCore.API.Controllers
{
    public class EnterpriseController : ControllerBase
    {
        #region Properties

        public readonly IEnterpriseService _enterpriseService;

        #endregion

        #region Constructor

        public EnterpriseController(IEnterpriseService enterpriseService) =>
            _enterpriseService = enterpriseService;

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos as empresas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getEnterprises", Name = "GetAllEnterprise")]
        public IActionResult GetEnterprises()
        {
            var result = _enterpriseService.GetEnterprises();

            if (result == null)
                return BadRequest(
                    new ResultViewModel
                    {
                        Success = false,
                        Message = "Enterprises not found",
                        Data = null
                    }
                );

            return new OkObjectResult(
                new ResultViewModel
                {
                    Success = true,
                    Message = "Enterprises retrieved successul.",
                    Data = result
                });
        }

        #endregion

        #region Post

        /// <summary>
        /// Cria uma nova empresa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createEnterprises", Name = "CreateEnterprise")]
        public IActionResult GetEnterprises([FromBody] CreateEnterpriseViewModel createEnterprise)
        {
            var result = _enterpriseService.CreateEnterprise(createEnterprise);

            return result.Success ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita uma empresa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateEnterprises", Name = "UpdateEnterprise")]
        public IActionResult UpdateEnterprises([FromBody] UpdateEnterpriseViewModel updateEnterprise)
        {
            var result = _enterpriseService.UpdateEnterprise(updateEnterprise);

            return result.Success ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion

        #region Delete



        #endregion

    }
}

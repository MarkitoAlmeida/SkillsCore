using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Services;

namespace SkillsCore.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        #region Properties

        public readonly IUserService _userServices;

        #endregion

        #region Constructor

        public UserController(IUserService userServices) => _userServices = userServices;

        #endregion

        #region GET


        #endregion
    }
}

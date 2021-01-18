using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Domain.Commands.UserCommands;
using SkillsCore.Domain.Models.Response;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsCore.API.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IUserQuery _userQuery;
        private readonly IMediator _mediator; 

        #endregion

        #region Constructor

        public UserController(IUserQuery userQuery, IMediator mediator)
        {
            _userQuery = userQuery;
            _mediator = mediator;
        }

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUsers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userQuery.GetAllUsers();

            if (result.Count() == 0)
                return BadRequest(new ResponseApi(false, "Users not found", null));

            return new OkObjectResult(new ResponseApi(true, "Users retrieved successul.", result));
        }

        /// <summary>
        /// Retorna usuário com base no FiscalNr
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUser/{fiscalNr}", Name = "GetUserByFiscalNr")]
        public async Task<IActionResult> GetUserByFiscalNr([FromRoute] int fiscalNr)
        {
            var result = await _userQuery.GetUserByFiscalNr(fiscalNr);

            if (result == null)
                return BadRequest(new ResponseApi(false, "User not found", null));

            return new OkObjectResult(new ResponseApi(true, "User retrieved successul.", result));
        }

        #endregion

        #region Post

        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createUser", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUser)
        {
            var result = await _mediator.Send(createUser);

            return Ok(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateUser", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUser)
        {
            var result = await _mediator.Send(updateUser);

            return Ok(result);
        }

        #endregion
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using SkillsCore.Application.Commands.UserCommands;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;

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

        public UserController(IUserService userServices) =>
            _userServices = userServices;

        #endregion

        #region Get

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUsers", Name = "GetAllUsers")]
        public IActionResult GetUsers()
        {
            var result = _userServices.GetUsers();

            if (result == null)
                return BadRequest(
                    new ResultViewModel
                    {
                        Success = false,
                        Message = "Users not found",
                        Data = null
                    }
                );

            return new OkObjectResult(
                new ResultViewModel
                {
                    Success = true,
                    Message = "Users retrieved successul.",
                    Data = result
                });
        }

        /// <summary>
        /// Retorna usuário com base no FiscalNr
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getUser", Name = "GetUserByFiscalNr")]
        public IActionResult GetUserByFiscalNr([FromBody] int fiscalNr)
        {
            var result = _userServices.GetUserByFiscalNr(fiscalNr);

            if (result == null)
                return BadRequest(
                    new ResultViewModel
                    {
                        Success = false,
                        Message = "User not found.",
                        Data = result
                    });

            return new OkObjectResult(
                new ResultViewModel
                {
                    Success = true,
                    Message = "User retrieved successul.",
                    Data = result
                });
        }

        #endregion

        #region Post

        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createUser", Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserCommand createUser)
        {
            var result = _userServices.CreateUser(createUser);

            return result.Success ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion

        #region Put

        /// <summary>
        /// Edita um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("updateUser", Name = "UpdateUser")]
        public IActionResult CreateUser([FromBody] UpdateUserCommand updateUser)
        {
            var result = _userServices.UpdateUser(updateUser);

            return result.Success ? new ObjectResult(result) : BadRequest(result);
        }

        #endregion
    }
}

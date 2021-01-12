using AutoMapper;
using SkillsCore.Application.Commands.UserCommands;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Models;
using System.Collections.Generic;

namespace SkillsCore.Application.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private readonly IUserRepository _userRepository;
        private readonly IUserQuery _userQuery;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserService(IUserRepository userRepository, IUserQuery userQuery, IMapper mapper)
        {
            _userRepository = userRepository;
            _userQuery = userQuery;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public IEnumerable<UserViewModel> GetUsers()
        {
            var data = _userQuery.GetAllUsers();

            return data;
        }

        public UserViewModel GetUserByFiscalNr(int fiscalNr)
        {
            var data = _userQuery.GetUserByFiscalNr(fiscalNr);

            return data;
        }

        public ResultViewModel CreateUser(CreateUserCommand createUser)
        {
            createUser.Validate();
            if (createUser.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Ops, something is wrong...",
                    Data = createUser.Notifications
                };

            var userExists = _userRepository.Get(createUser.FiscalNr);
            if (userExists != null)
                return new ResultViewModel
                { 
                    Success = false,
                    Message = "User already exists.",
                    Data = userExists
                };

            User user = _mapper.Map<User>(createUser);
            _userRepository.Insert(user);

            return new ResultViewModel
            {
                Success = true,
                Message = "User created sucessfuly",
                Data = new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    FiscalNr = user.FiscalNr,
                    Email = user.Email,
                    BirthDay = user.BirthDay,
                    Gender = user.Gender,
                    Phone = user.Phone,
                    Street = user.Street,
                    StateProvince = user.StateProvince,
                    City = user.City,
                    Country = user.Country,
                    CityOfBirth = user.CityOfBirth,
                    ExperienceTime = user.ExperienceTime,
                    Summary = user.Summary,
                    Active = user.Active,
                    Excluded = user.Excluded,
                    CreationDate = user.CreationDate
                }
            };
        }

        public ResultViewModel UpdateUser(UpdateUserCommand updateUser)
        {
            User user = _mapper.Map<User>(_userQuery.GetUserById(updateUser.Id));

            updateUser.Validate();
            if (updateUser.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Ops, something is wrong...",
                    Data = updateUser.Notifications
                };

            user.UpdateFields(_mapper.Map<User>(updateUser));
            _userRepository.Update(user);

            return new ResultViewModel
            {
                Success = true,
                Message = "User updated sucessfuly",
                Data = new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Gender = user.Gender,
                    Phone = user.Phone,
                    Street = user.Street,
                    StateProvince = user.StateProvince,
                    City = user.City,
                    Country = user.Country,
                    ExperienceTime = user.ExperienceTime,
                    Summary = user.Summary,
                    Active = user.Active,
                    Excluded = user.Excluded
                }
            };
        }

        #endregion
    }
}

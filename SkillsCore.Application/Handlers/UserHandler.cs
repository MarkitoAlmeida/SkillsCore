using AutoMapper;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.UserViewModel;
using SkillsCore.Domain.Commands.UserCommands;
using SkillsCore.Domain.Interfaces.Handlers;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkillsCore.Application.Handlers
{
    public class UserHandler : IUserHandler
    {
        #region Properties

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateUserCommand request, CancellationToken cancelationToken)
        {
            try
            {
                request.Validate();
                if (request.Invalid)
                    return new ResponseApi(false, "Ops, something is wrong...", request.Notifications);

                //var userExists = _userRepository.GetUserByFiscalNr(request.FiscalNr);
                //if (userExists != null)
                //    return new ResponseApi(false, "User already exists.", userExists);

                User user = _mapper.Map<User>(request);
                await _userRepository.Insert(user);

                var response = new UserViewModel
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
                };

                return new ResponseApi(true, "User created sucessfuly", response);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = _mapper.Map<User>(await _userRepository.Get(request.Id));

                request.Validate();
                if (request.Invalid)
                    return new ResponseApi(false, "Ops, something is wrong...", request.Notifications);

                user.UpdateFields(_mapper.Map<User>(request));
                await _userRepository.Update(user);

                var response = new UserViewModel
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
                    CreationDate = user.CreationDate,
                    LastUpdate = user.LastUpdate
                };

                return new ResponseApi(true, "User updated sucessfuly", response);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}

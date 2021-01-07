using AutoMapper;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;

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


        #endregion
    }
}

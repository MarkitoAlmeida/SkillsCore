using AutoMapper;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Domain.Models;
using System.Collections.Generic;

namespace SkillsCore.Application.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        #region Properties

        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IEnterpriseQuery _enterpriseQuery;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public EnterpriseService(IEnterpriseRepository enterpriseRepository, IEnterpriseQuery enterpriseQuery, IMapper mapper)
        {
            _enterpriseRepository = enterpriseRepository;
            _enterpriseQuery = enterpriseQuery;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public IEnumerable<EnterpriseViewModel> GetEnterprises()
        {
            var data = _enterpriseQuery.GetAllEnterprises();

            return data;
        }

        public ResultViewModel CreateEnterprise(CreateEnterpriseViewModel createEnterprise)
        {
            createEnterprise.Validate();
            if (createEnterprise.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Ops... Something is wrong",
                    Data = createEnterprise.Notifications
                };

            var enterpriseExists = _enterpriseQuery.GetEnterpriseByFiscalNr(createEnterprise.FiscalNr);
            if (enterpriseExists != null)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "The enterprise already exists.",
                    Data = enterpriseExists
                };

            Enterprise enterprise = _mapper.Map<Enterprise>(createEnterprise);
            _enterpriseRepository.Insert(enterprise);

            return new ResultViewModel
            {
                Success = true,
                Message = "Enterprise created sucessfuly",
                Data = new EnterpriseViewModel
                {
                    Id = enterprise.Id,
                    Name = enterprise.Name,
                    FiscalNr = enterprise.FiscalNr,
                    Email = enterprise.Email,
                    Phone = enterprise.Phone,
                    Street = enterprise.Street,
                    StateProvince = enterprise.StateProvince,
                    City = enterprise.City,
                    Country = enterprise.Country,
                    Active = enterprise.Active,
                    Excluded = enterprise.Excluded,
                    CreationDate = enterprise.CreationDate
                }
            };
        }

        public ResultViewModel UpdateEnterprise(UpdateEnterpriseViewModel updateEnterprise)
        {
            Enterprise enterprise = _mapper.Map<Enterprise>(_enterpriseQuery.GetEnterpriseById(updateEnterprise.Id));

            updateEnterprise.Validate();
            if (updateEnterprise.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Ops, something is wrong...",
                    Data = updateEnterprise.Notifications
                };

            enterprise.UpdateFields(_mapper.Map<Enterprise>(updateEnterprise));
            _enterpriseRepository.Update(enterprise);

            return new ResultViewModel
            {
                Success = true,
                Message = "User updated sucessfuly",
                Data = new EnterpriseViewModel
                {
                    Id = enterprise.Id,
                    Name = enterprise.Name,
                    Email = enterprise.Email,
                    Phone = enterprise.Phone,
                    Street = enterprise.Street,
                    StateProvince = enterprise.StateProvince,
                    City = enterprise.City,
                    Country = enterprise.Country,
                    Active = enterprise.Active,
                    Excluded = enterprise.Excluded
                }
            };
        }

        #endregion
    }
}

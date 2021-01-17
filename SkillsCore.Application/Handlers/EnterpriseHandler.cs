using AutoMapper;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.EnterpriseViewModels;
using SkillsCore.Domain.Commands.EnterpriseCommands;
using SkillsCore.Domain.Interfaces.Handlers;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkillsCore.Application.Handlers
{
    public class EnterpriseHandler : IEnterpriseHandler
    {
        #region Properties

        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public EnterpriseHandler(IEnterpriseRepository enterpriseRepository, IMapper mapper)
        {
            _enterpriseRepository = enterpriseRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateEnterpriseCommand request, CancellationToken cancelationToken)
        {
            try
            {
                request.Validate();
                if (request.Invalid)
                    return new ResponseApi(false, "Ops... Something is wrong", request.Notifications);

                var enterpriseExists = await _enterpriseRepository.GetEnterpriseByFiscalNr(request.FiscalNr);
                if (enterpriseExists != null)
                    return new ResponseApi(false, "The enterprise already exists.", enterpriseExists);

                Enterprise enterprise = _mapper.Map<Enterprise>(request);
                await _enterpriseRepository.Insert(enterprise);

                var response = new EnterpriseViewModel
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
                    CreationDate = enterprise.CreationDate,
                    LastUpdate = enterprise.LastUpdate
                };

                return new ResponseApi(true, "Enterprise created sucessfuly", response);
            }
            catch (Exception e)
            {
                return new ResponseApi(true, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(UpdateEnterpriseCommand request, CancellationToken cancelationToken)
        {
            try
            {
                request.Validate();
                if (request.Invalid)
                    return new ResponseApi(false, "Ops, something is wrong...", request.Notifications);

                Enterprise enterprise = _mapper.Map<Enterprise>(await _enterpriseRepository.Get(request.Id));

                enterprise.UpdateFields(_mapper.Map<Enterprise>(request));
                await _enterpriseRepository.Update(enterprise);

                var response = new EnterpriseViewModel
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
                    CreationDate = enterprise.CreationDate,
                    LastUpdate = enterprise.LastUpdate
                };

                return new ResponseApi(true, "User updated sucessfuly", response);
            }
            catch (Exception e)
            {
                return new ResponseApi(true, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(DeleteEnterpriseCommand request, CancellationToken cancelationToken)
        {
            try
            {
                Enterprise enterprise = await _enterpriseRepository.Get(request.IdEnterprise);
                if (enterprise != null)
                    return new ResponseApi(false, "The enterprise already exists.", enterprise);

                enterprise.Delete();
                await _enterpriseRepository.Update(enterprise);

                return new ResponseApi(true, "Enterprise deleted sucessfuly", enterprise);
            }
            catch (Exception e)
            {
                return new ResponseApi(true, "Error...", e);
            }
        }

        #endregion

    }
}

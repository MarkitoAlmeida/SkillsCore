using AutoMapper;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.CompetenceViewModels;
using SkillsCore.Domain.Commands.CompetenceCommands;
using SkillsCore.Domain.Interfaces.Handlers;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkillsCore.Application.Handlers
{
    public class CompetenceHandler : ICompetenceHandler
    {
        #region Properties

        private readonly ICompetenceRepository _competenceRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CompetenceHandler(ICompetenceRepository competenceRepository, IMapper mapper)
        {
            _competenceRepository = competenceRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateListCompetenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var competence in request.Competences)
                {
                    competence.Validate();
                    if (competence.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", competence.Notifications);
                }

                List<CompetenceViewModel> result = new List<CompetenceViewModel>();

                for (int i = 0; i < request.Competences.Count; i++)
                {
                    request.Competences[i].IdUser = request.IdUser;

                    Competences competence = _mapper.Map<Competences>(request.Competences[i]);
                    await _competenceRepository.Insert(competence);

                    var createResult = new CompetenceViewModel
                    {
                        Id = competence.Id,
                        CompetenceName = competence.CompetenceName,
                        CompetenceExperienceTime = competence.CompetenceExperienceTime,
                        TimeType = competence.TimeType,
                        Active = competence.Active,
                        Excluded = competence.Excluded,
                        CreationDate = competence.CreationDate,
                        LastUpdate = competence.LastUpdate,
                        IdUser = competence.IdUser
                    };

                    result.Add(createResult);
                }

                return new ResponseApi(true, "Competences created sucessfuly.", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(UpdateListCompetenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var competence in request.Competences)
                {
                    competence.Validate();
                    if (competence.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", competence.Notifications);
                }

                List<CompetenceViewModel> result = new List<CompetenceViewModel>();

                for (int i = 0; i < request.Competences.Count; i++)
                {
                    Competences competence = _mapper.Map<Competences>(await _competenceRepository.Get(request.Competences[i].Id));

                    competence.UpdateFields(_mapper.Map<Competences>(request.Competences[i]));
                    await _competenceRepository.Update(competence);

                    var updateResult = new CompetenceViewModel
                    {
                        Id = competence.Id,
                        CompetenceName = competence.CompetenceName,
                        CompetenceExperienceTime = competence.CompetenceExperienceTime,
                        TimeType = competence.TimeType,
                        Active = competence.Active,
                        Excluded = competence.Excluded,
                        CreationDate = competence.CreationDate,
                        LastUpdate = competence.LastUpdate,
                        IdUser = competence.IdUser
                    };

                    result.Add(updateResult);
                }

                return new ResponseApi(true, "Competences updated sucessfuly", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(DeleteCompetenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Competences competence = _mapper.Map<Competences>(await _competenceRepository.Get(request.IdCompetence));

                await _competenceRepository.Delete(competence);

                return new ResponseApi(true, "Competência deleted sucessfuly", null);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}

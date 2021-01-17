using AutoMapper;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using SkillsCore.Domain.Commands.AcademicFormationCommands;
using SkillsCore.Domain.Interfaces.Handlers;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkillsCore.Application.Handlers
{
    public class AcademicFormationHandler : IAcademicFormationHandler
    {
        #region Properties

        private readonly IAcademicFormationRepository _academicFormationRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public AcademicFormationHandler(IAcademicFormationRepository academicFormationRepository, IMapper mapper)
        {
            _academicFormationRepository = academicFormationRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateListAcademicFormationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var formation in request.AcademicFormations)
                {
                    formation.Validate();
                    if (formation.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", formation.Notifications);
                }

                List<AcademicFormationViewModel> result = new List<AcademicFormationViewModel>();

                for (int i = 0; i < request.AcademicFormations.Count; i++)
                {
                    request.AcademicFormations[i].IdUser = request.IdUser;

                    AcademicFormation academicFormation = _mapper.Map<AcademicFormation>(request.AcademicFormations[i]);
                    await _academicFormationRepository.Insert(academicFormation);

                    var createResult = new AcademicFormationViewModel
                    {
                        Id = academicFormation.Id,
                        InstituitionName = academicFormation.InstituitionName,
                        CourseTitle = academicFormation.CourseTitle,
                        ConclusionDate = academicFormation.ConclusionDate,
                        FinalPaperTitle = academicFormation.FinalPaperTitle,
                        Active = academicFormation.Active,
                        Excluded = academicFormation.Excluded,
                        CreationDate = academicFormation.CreationDate,
                        LastUpdate = academicFormation.LastUpdate,
                        IdUser = academicFormation.IdUser
                    };

                    result.Add(createResult);
                }

                return new ResponseApi(true, "Academic formation created sucessfuly.", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(UpdateListAcademicFormationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var formation in request.AcademicFormations)
                {
                    formation.Validate();
                    if (formation.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", formation.Notifications);
                }

                List<AcademicFormationViewModel> result = new List<AcademicFormationViewModel>();

                for (int i = 0; i < request.AcademicFormations.Count; i++)
                {
                    AcademicFormation academicFormation = _mapper.Map<AcademicFormation>(await _academicFormationRepository.Get(request.AcademicFormations[i].Id));

                    academicFormation.UpdateFields(_mapper.Map<AcademicFormation>(request.AcademicFormations[i]));
                    await _academicFormationRepository.Update(academicFormation);

                    var updateResult = new AcademicFormationViewModel
                    {
                        Id = academicFormation.Id,
                        InstituitionName = academicFormation.InstituitionName,
                        CourseTitle = academicFormation.CourseTitle,
                        ConclusionDate = academicFormation.ConclusionDate,
                        FinalPaperTitle = academicFormation.FinalPaperTitle,
                        Active = academicFormation.Active,
                        Excluded = academicFormation.Excluded,
                        CreationDate = academicFormation.CreationDate,
                        LastUpdate = academicFormation.LastUpdate,
                        IdUser = academicFormation.IdUser
                    };

                    result.Add(updateResult);
                }

                return new ResponseApi(true, "Academic formation updated sucessfuly", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(DeleteAcademicFormationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AcademicFormation academicFormation = _mapper.Map<AcademicFormation>(await _academicFormationRepository.Get(request.IdAcademicFormation));

                await _academicFormationRepository.Delete(academicFormation);
                
                return new ResponseApi(true, "Formação acadêmica deletada com sucesso", null);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}

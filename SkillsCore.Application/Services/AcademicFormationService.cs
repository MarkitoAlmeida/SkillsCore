using AutoMapper;
using SkillsCore.Application.Commands.AcademicFormationCommands;
using SkillsCore.Application.Interfaces.Queries;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.Interfaces.Services;
using SkillsCore.Application.ViewModels;
using SkillsCore.Application.ViewModels.AcademicFormationViewModels;
using SkillsCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillsCore.Application.Services
{
    public class AcademicFormationService : IAcademicFormationService
    {
        #region Properties

        private readonly IAcademicFormationQuery _academicFormationQuery;
        private readonly IAcademicFormationRepository _academicFormationRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public AcademicFormationService(IAcademicFormationQuery academicFormationQuery, IAcademicFormationRepository academicFormationRepository,
            IMapper mapper)
        {
            _academicFormationQuery = academicFormationQuery;
            _academicFormationRepository = academicFormationRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public IEnumerable<AcademicFormationViewModel> GetFormationByUser(Guid id)
        {
            var data = _academicFormationQuery.GetUserFormationById(id);

            return data;
        }

        public List<ResultViewModel> CreateAcademicFormation(CreateListAcademicFormationCommand createFormation)
        {
            List<ResultViewModel> result = new List<ResultViewModel>();
            int invalidQty = 0;

            foreach (var formation in createFormation.AcademicFormations)
            {
                formation.Validate();
                if (formation.Invalid)
                    invalidQty += 1;

                if (invalidQty > 0)
                {
                    result.Add(new ResultViewModel
                    {
                        Success = false,
                        Message = "Something is wrong...",
                        Data = formation.Notifications
                    }); 

                    return result;
                }
            }

            for (int i = 0; i < createFormation.AcademicFormations.Count(); i++)
            {
                AcademicFormation academicFormation = _mapper.Map<AcademicFormation>(createFormation.AcademicFormations[i]);
                _academicFormationRepository.Insert(academicFormation);

                var createResult = new ResultViewModel
                {
                    Success = true,
                    Message = "User created sucessfuly",
                    Data = new AcademicFormationViewModel
                    {
                        Id = academicFormation.Id,
                        InstituitionName = academicFormation.InstituitionName,
                        CourseTitle = academicFormation.CourseTitle,
                        ConclusionDate = academicFormation.ConclusionDate,
                        FinalPaperTitle = academicFormation.FinalPaperTitle,
                        Active = academicFormation.Active,
                        Excluded = academicFormation.Excluded,
                        CreationDate = academicFormation.CreationDate,
                        LastUpdate = academicFormation.LastUpdate
                    }
                };

                result.Add(createResult);
            }

            return result;
        }

        public List<ResultViewModel> UpdateAcademicFormation(UpdateListAcademicFormationCommand updateFormation)
        {
            List<ResultViewModel> result = new List<ResultViewModel>();
            int invalidQty = 0;

            foreach (var formation in updateFormation.AcademicFormations)
            {
                formation.Validate();
                if (formation.Invalid)
                    invalidQty += 1;

                if (invalidQty > 0)
                {
                    result.Add(new ResultViewModel
                    {
                        Success = false,
                        Message = "Something is wrong...",
                        Data = formation.Notifications
                    });

                    return result;
                }
            }

            for (int i = 0; i <= updateFormation.AcademicFormations.Count(); i++)
            {
                AcademicFormation academicFormation = _mapper.Map<AcademicFormation>(_academicFormationQuery.GetAcamicFormationById(updateFormation.AcademicFormations[i].Id));

                academicFormation.UpdateFields(_mapper.Map<AcademicFormation>(updateFormation.AcademicFormations[i]));
                _academicFormationRepository.Update(academicFormation);

                var updateResult = new ResultViewModel
                {
                    Success = true,
                    Message = "Academic formation updated sucessfuly",
                    Data = new AcademicFormationViewModel
                    {
                        Id = academicFormation.Id,
                        InstituitionName = academicFormation.InstituitionName,
                        CourseTitle = academicFormation.CourseTitle,
                        ConclusionDate = academicFormation.ConclusionDate,
                        FinalPaperTitle = academicFormation.FinalPaperTitle,
                        Active = academicFormation.Active,
                        Excluded = academicFormation.Excluded,
                        CreationDate = academicFormation.CreationDate,
                        LastUpdate = academicFormation.LastUpdate
                    }
                };

                result.Add(updateResult);
            }

            return result;
        }

        #endregion

        #region Delete

        public ResultViewModel DeleteAcademicFormation(Guid academicFormationId)
        {

            return new ResultViewModel
            {
                Success = true,
                Message = "Academic Formation was sucessfuly erased.",
                Data = null
            };
    
        }

        #endregion
    }
}

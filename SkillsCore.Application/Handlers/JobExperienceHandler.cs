using AutoMapper;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.JobExperienceViewModels;
using SkillsCore.Domain.Commands.JobExperienceCommands;
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
    public class JobExperienceHandler : IJobExperienceHandler
    {
        #region Properties

        private readonly IJobExperienceRepository _jobExperienceRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public JobExperienceHandler(IJobExperienceRepository jobExperienceRepository, IMapper mapper)
        {
            _jobExperienceRepository = jobExperienceRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateListJobExperiencesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var job in request.JobExperiences)
                {
                    job.Validate();
                    if (job.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", job.Notifications);
                }

                List<JobExperienceViewModel> result = new List<JobExperienceViewModel>();

                for (int i = 0; i < request.JobExperiences.Count; i++)
                {
                    request.JobExperiences[i].IdUser = request.IdUser;

                    JobExperience jobExperience = _mapper.Map<JobExperience>(request.JobExperiences[i]);
                    await _jobExperienceRepository.Insert(jobExperience);

                    var createResult = new JobExperienceViewModel
                    {
                        Id = jobExperience.Id,
                        EnterpriseName = jobExperience.EnterpriseName,
                        BeginDate = jobExperience.BeginDate,
                        FinalDate = jobExperience.FinalDate,
                        JobTitle = jobExperience.JobTitle,
                        ProjectDescription = jobExperience.ProjectDescription,
                        ProjectResponsabilities = jobExperience.ProjectResponsabilities,
                        TecnologiesUsed = jobExperience.TecnologiesUsed,
                        Active = jobExperience.Active,
                        Excluded = jobExperience.Excluded,
                        CreationDate = jobExperience.CreationDate,
                        LastUpdate = jobExperience.LastUpdate,
                        IdUser = jobExperience.IdUser
                    };

                    result.Add(createResult);
                }

                return new ResponseApi(true, "Job experiences created sucessfuly.", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e.Message);
            }
        }

        public async Task<ResponseApi> Handle(UpdateListJobExperiencesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var job in request.JobExperiences)
                {
                    job.Validate();
                    if (job.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", job.Notifications);
                }

                List<JobExperienceViewModel> result = new List<JobExperienceViewModel>();

                for (int i = 0; i < request.JobExperiences.Count; i++)
                {
                    JobExperience jobExperience = _mapper.Map<JobExperience>(await _jobExperienceRepository.Get(request.JobExperiences[i].Id));

                    jobExperience.UpdateFields(_mapper.Map<JobExperience>(request.JobExperiences[i]));
                    await _jobExperienceRepository.Update(jobExperience);

                    var updateResult = new JobExperienceViewModel
                    {
                        Id = jobExperience.Id,
                        EnterpriseName = jobExperience.EnterpriseName,
                        BeginDate = jobExperience.BeginDate,
                        FinalDate = jobExperience.FinalDate,
                        JobTitle = jobExperience.JobTitle,
                        ProjectDescription = jobExperience.ProjectDescription,
                        ProjectResponsabilities = jobExperience.ProjectResponsabilities,
                        TecnologiesUsed = jobExperience.TecnologiesUsed,
                        Active = jobExperience.Active,
                        Excluded = jobExperience.Excluded,
                        CreationDate = jobExperience.CreationDate,
                        LastUpdate = jobExperience.LastUpdate,
                        IdUser = jobExperience.IdUser
                    };

                    result.Add(updateResult);
                }

                return new ResponseApi(true, "Job experiences updated sucessfuly", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e.Message);
            }
        }

        public async Task<ResponseApi> Handle(DeleteJobExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JobExperience jobExperience = _mapper.Map<JobExperience>(await _jobExperienceRepository.Get(request.IdJobExperience));

                await _jobExperienceRepository.Delete(jobExperience);

                return new ResponseApi(true, "Job experience deleted sucessfuly", null);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}

using AutoMapper;
using SkillsCore.Application.Interfaces.Repositories;
using SkillsCore.Application.ViewModels.LanguageViewModels;
using SkillsCore.Domain.Commands.LanguageCommands;
using SkillsCore.Domain.Interfaces.Handlers;
using SkillsCore.Domain.Models;
using SkillsCore.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkillsCore.Application.Handlers
{
    public class LanguageHandler : ILanguageHandler
    {
        #region Properties

        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public LanguageHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResponseApi> Handle(CreateListLanguagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var language in request.Languages)
                {
                    language.Validate();
                    if (language.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", language.Notifications);
                }

                List<LanguageViewModel> result = new List<LanguageViewModel>();

                for (int i = 0; i < request.Languages.Count; i++)
                {
                    request.Languages[i].IdUser = request.IdUser;

                    Language language = _mapper.Map<Language>(request.Languages[i]);
                    await _languageRepository.Insert(language);

                    var createResult = new LanguageViewModel
                    {
                        Id = language.Id,
                        LanguageName = language.LanguageName,
                        LanguageUnderstanding = language.LanguageUnderstanding,
                        LanguageWriting = language.LanguageWriting,
                        LanguageSpeaking = language.LanguageSpeaking,
                        Active = language.Active,
                        Excluded = language.Excluded,
                        CreationDate = language.CreationDate,
                        LastUpdate = language.LastUpdate,
                        IdUser = language.IdUser
                    };

                    result.Add(createResult);
                }

                return new ResponseApi(true, "Languages created sucessfuly.", result);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        public async Task<ResponseApi> Handle(UpdateListLanguagesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int invalidQty = 0;

                foreach (var language in request.Languages)
                {
                    language.Validate();
                    if (language.Invalid)
                        invalidQty += 1;

                    if (invalidQty > 0)
                        return new ResponseApi(false, "Something is wrong...", language.Notifications);
                }

                List<LanguageViewModel> result = new List<LanguageViewModel>();

                for (int i = 0; i < request.Languages.Count; i++)
                {
                    Language language = _mapper.Map<Language>(await _languageRepository.Get(request.Languages[i].Id));

                    language.UpdateFields(_mapper.Map<Language>(request.Languages[i]));
                    await _languageRepository.Update(language);

                    var updateResult = new LanguageViewModel
                    {
                        Id = language.Id,
                        LanguageName = language.LanguageName,
                        LanguageUnderstanding = language.LanguageUnderstanding,
                        LanguageWriting = language.LanguageWriting,
                        LanguageSpeaking = language.LanguageSpeaking,
                        Active = language.Active,
                        Excluded = language.Excluded,
                        CreationDate = language.CreationDate,
                        LastUpdate = language.LastUpdate,
                        IdUser = language.IdUser
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

        public async Task<ResponseApi> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Language language = _mapper.Map<Language>(await _languageRepository.Get(request.IdLanguage));

                await _languageRepository.Delete(language);

                return new ResponseApi(true, "Language deleted sucessfuly", null);
            }
            catch (Exception e)
            {
                return new ResponseApi(false, "Error...", e);
            }
        }

        #endregion
    }
}

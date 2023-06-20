using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Sureze.LIS.Application.Contracts.Dtos.Commons;
using Sureze.LIS.Application.Contracts.Services;
using Sureze.LIS.Commons;
using Sureze.LIS.Dtos.Patients;
using Sureze.LIS.Patients;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sureze.LIS.Services;

public class PatientAppService : CrudAppService<Patient, PatientDto, int, PagedAndSortedResultRequestDto, CreatePatientDto, UpdatePatientDto>, IPatientAppService
{
    private readonly IRepository<AlternateIDType, int> _alternateIDTypeRep;
    private readonly IRepository<Citizen, int> _citizenRep;
    private readonly IRepository<EducationLevel, int> _educationLevelRep;
    private readonly IRepository<Ethnicity, int> _ethnicityRep;
    private readonly IRepository<InActiveStatus, int> _inActiveStatusRep;
    private readonly IRepository<Language, int> _languageRep;
    private readonly IRepository<MaritalStatus, int> _maritalStatusRep;
    private readonly IRepository<Nationality, int> _nationalityRep;
    private readonly IRepository<PatientCategory, int> _patientCategoryRep;
    private readonly IRepository<PrimaryProvider, int> _primaryProviderRep;
    private readonly IRepository<Race, int> _raceRep;
    private readonly IRepository<Religion, int> _religionRep;
    private readonly IRepository<Gender, int> _genderRep;

    public PatientAppService(
        IRepository<Patient, int> repository,

        IRepository<AlternateIDType, int> alternateIDTypeRep,
        IRepository<Citizen, int> citizenRep,
        IRepository<EducationLevel, int> educationLevelRep,
        IRepository<Ethnicity, int> ethnicityRep,
        IRepository<InActiveStatus, int> inActiveStatusRep,
        IRepository<Language, int> languageRep,
        IRepository<MaritalStatus, int> maritalStatusRep,
        IRepository<Nationality, int> nationalityRep,
        IRepository<PatientCategory, int> patientCategoryRep,
        IRepository<PrimaryProvider, int> primaryProviderRep,
        IRepository<Race, int> raceRep,
        IRepository<Religion, int> religionRep,
        IRepository<Gender, int> genderRep
        ) : base(repository)
    {



        _alternateIDTypeRep = alternateIDTypeRep;
        _citizenRep = citizenRep;
        _educationLevelRep = educationLevelRep;
        _ethnicityRep = ethnicityRep;
        _inActiveStatusRep = inActiveStatusRep;
        _languageRep = languageRep;
        _maritalStatusRep = maritalStatusRep;
        _nationalityRep = nationalityRep;
        _patientCategoryRep = patientCategoryRep;
        _primaryProviderRep = primaryProviderRep;
        _raceRep = raceRep;
        _religionRep = religionRep;
        _genderRep = genderRep;
    }

    public async Task<ListResultDto<AlternateIDTypeLookupDto>> GetAlternateIDTypeLookupAsync()
    {
        return await GetAllLookupAsync<AlternateIDType, AlternateIDTypeLookupDto, int>(_alternateIDTypeRep);
    }

    public async Task<ListResultDto<CitizenLookupDto>> GetCitizenLookupAsync()
    {
        return await GetAllLookupAsync<Citizen, CitizenLookupDto, int>(_citizenRep);
    }

    public async Task<ListResultDto<EducationLevelLookupDto>> GetEducationLevelLookupAsync()
    {
        return await GetAllLookupAsync<EducationLevel, EducationLevelLookupDto, int>(_educationLevelRep);
    }

    public async Task<ListResultDto<EthnicityLookupDto>> GetEthnicityLookupAsync()
    {
        return await GetAllLookupAsync<Ethnicity, EthnicityLookupDto, int>(_ethnicityRep);
    }

    public async Task<ListResultDto<InActiveStatusLookupDto>> GetInActiveStatusLookupAsync()
    {

        return await GetAllLookupAsync<InActiveStatus, InActiveStatusLookupDto, int>(_inActiveStatusRep);
    }

    public async Task<ListResultDto<LanguageLookupDto>> GetLanguageLookupAsync()
    {
        return await GetAllLookupAsync<Language, LanguageLookupDto, int>(_languageRep);
    }

    public async Task<ListResultDto<MaritalStatusLookupDto>> GetMaritalStatusLookupAsync()
    {
        return await GetAllLookupAsync<MaritalStatus, MaritalStatusLookupDto, int>(_maritalStatusRep);
    }

    public async Task<ListResultDto<NationalityLookupDto>> GetNationalityLookupAsync()
    {
        return await GetAllLookupAsync<Nationality, NationalityLookupDto, int>(_nationalityRep);
    }

    public async Task<ListResultDto<PatientCategoryLookupDto>> GetPatientCategoryLookupAsync()
    {
        return await GetAllLookupAsync<PatientCategory, PatientCategoryLookupDto, int>(_patientCategoryRep);
    }

    public async Task<ListResultDto<PrimaryProviderLookupDto>> GetPrimaryProviderLookupAsync()
    {
        return await GetAllLookupAsync<PrimaryProvider, PrimaryProviderLookupDto, int>(_primaryProviderRep);
    }

    public async Task<ListResultDto<RaceLookupDto>> GetRaceLookupAsync()
    {
        return await GetAllLookupAsync<Race, RaceLookupDto, int>(_raceRep);
    }

    public async Task<ListResultDto<ReligionLookupDto>> GetReligionLookupAsync()
    {
        return await GetAllLookupAsync<Religion, ReligionLookupDto, int>(_religionRep);
    }

    public async Task<ListResultDto<GenderLookupDto>> GetGenderLookupAsync()
    {
        return await GetAllLookupAsync<Gender, GenderLookupDto, int>(_genderRep);
    }


    private async Task<ListResultDto<TEntityLookupDto>> GetAllLookupAsync<TEntity, TEntityLookupDto, TKey>(IRepository<TEntity, TKey> rep) where TEntity : class, IEntity<TKey> where TEntityLookupDto : class, IEntityDto<TKey>
    {
        var items = await rep.GetListAsync();
        return new ListResultDto<TEntityLookupDto>(
           ObjectMapper.Map<List<TEntity>, List<TEntityLookupDto>>(items)
       );
    }

    public async override  Task<PatientDto> CreateAsync(CreatePatientDto input)
    {
       
      return  await base.CreateAsync(input);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Sureze.LIS.Application.Contracts.Dtos.Commons;
using Sureze.LIS.Application.Contracts.Services;
using Sureze.LIS.Commons;
using Sureze.LIS.Dtos.Patients;
using Sureze.LIS.Patients;
using Sureze.LIS.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Sureze.LIS.Services;

public class PatientAppService : CrudAppService<Patient, PatientDto, int, PatientRequestDto, CreatePatientDto, UpdatePatientDto>, IPatientAppService
{
    private readonly IPatientRepository _repository;
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
    private readonly IRepository<NamePrefix, int> _namePrefixRep;

    public PatientAppService(
        IPatientRepository repository,

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
        IRepository<Gender, int> genderRep,
        IRepository<NamePrefix, int> namePrefixRep


        ) : base(repository)
    {
        _repository = repository;
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
        _namePrefixRep = namePrefixRep;




        GetPolicyName = LISPermissions.Patients.Default;
        GetListPolicyName = LISPermissions.Patients.Default;
        CreatePolicyName = LISPermissions.Patients.Create;
        UpdatePolicyName = LISPermissions.Patients.Edit;
        DeletePolicyName = LISPermissions.Patients.Delete;
    }

    public async override Task<PatientDto> GetAsync(int id)
    {
        var patient = await base.GetAsync(id);
        var status = await _inActiveStatusRep.GetAsync(patient.InActiveStatusId);
        patient.InActiveStatus = status.Title;
        return patient;
    }
    protected async override Task<IQueryable<Patient>> CreateFilteredQueryAsync(PatientRequestDto input)
    {
        return await _repository.CreateFilteredQueryAsync(ObjectMapper.Map<PatientRequestDto, PatientFilter>(input));


    }
    public async override Task<PagedResultDto<PatientDto>> GetListAsync(PatientRequestDto input)
    {

        // because I sure that the " _inActiveStatusRep.GetListAsync()" returns less than 10 items
        var statuses = await _inActiveStatusRep.GetListAsync();

        var patients = await base.GetListAsync(input);


        var newPatients = patients.Items.Join(statuses, p => p.InActiveStatusId, s => s.Id, (p, s) =>
        {
            p.InActiveStatus = s.Title;
            return p;
        });
        patients.Items = newPatients.ToList();
        return patients;




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
    public async Task<ListResultDto<NamePrefixLookupDto>> GetNamePrefixLookupAsync()
    {
        return await GetAllLookupAsync<NamePrefix, NamePrefixLookupDto, int>(_namePrefixRep);
    }


    private async Task<ListResultDto<TEntityLookupDto>> GetAllLookupAsync<TEntity, TEntityLookupDto, TKey>(IRepository<TEntity, TKey> rep) where TEntity : class, IEntity<TKey> where TEntityLookupDto : class, IEntityDto<TKey>
    {
        var items = await rep.GetListAsync();
        return new ListResultDto<TEntityLookupDto>(
           ObjectMapper.Map<List<TEntity>, List<TEntityLookupDto>>(items)
       );
    }

    public async override Task<PatientDto> CreateAsync(CreatePatientDto input)
    {
        return await base.CreateAsync(input);
    }
}
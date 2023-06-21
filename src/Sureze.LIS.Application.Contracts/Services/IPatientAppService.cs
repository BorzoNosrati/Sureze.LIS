using Sureze.LIS.Application.Contracts.Dtos.Commons;
using Sureze.LIS.Dtos.Patients;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sureze.LIS.Application.Contracts.Services;

public interface IPatientAppService : ICrudAppService<
    PatientDto,
    int,
    PatientRequestDto,
    CreatePatientDto,
    UpdatePatientDto>
{

    Task<ListResultDto<PrimaryProviderLookupDto>> GetPrimaryProviderLookupAsync();
    Task<ListResultDto<InActiveStatusLookupDto>> GetInActiveStatusLookupAsync();
    Task<ListResultDto<AlternateIDTypeLookupDto>> GetAlternateIDTypeLookupAsync();
    Task<ListResultDto<GenderLookupDto>> GetGenderLookupAsync();
    Task<ListResultDto<RaceLookupDto>> GetRaceLookupAsync();
    Task<ListResultDto<LanguageLookupDto>> GetLanguageLookupAsync();
    Task<ListResultDto<EthnicityLookupDto>> GetEthnicityLookupAsync();
    Task<ListResultDto<EducationLevelLookupDto>> GetEducationLevelLookupAsync();
    Task<ListResultDto<NationalityLookupDto>> GetNationalityLookupAsync();
    Task<ListResultDto<CitizenLookupDto>> GetCitizenLookupAsync();
    Task<ListResultDto<ReligionLookupDto>> GetReligionLookupAsync();
    Task<ListResultDto<MaritalStatusLookupDto>> GetMaritalStatusLookupAsync();
    Task<ListResultDto<PatientCategoryLookupDto>> GetPatientCategoryLookupAsync();
    Task<ListResultDto<NamePrefixLookupDto>> GetNamePrefixLookupAsync();
}
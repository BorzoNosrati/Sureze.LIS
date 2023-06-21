using AutoMapper;
using Sureze.LIS.Application.Contracts.Dtos.Commons;
using Sureze.LIS.Commons;
using Sureze.LIS.Dtos.Patients;
using Sureze.LIS.Patients;

namespace Sureze.LIS;

public class LISApplicationAutoMapperProfile : Profile
{
    public LISApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Patient, PatientDto>();
        CreateMap<CreatePatientDto, Patient>();
        CreateMap<UpdatePatientDto, Patient>();
        CreateMap<PatientDto, UpdatePatientDto>();


        /// common lookups
        /// 

        CreateMap<PrimaryProvider,PrimaryProviderLookupDto>();
        CreateMap<InActiveStatus ,InActiveStatusLookupDto >();
        CreateMap<AlternateIDType,AlternateIDTypeLookupDto>();
        CreateMap<Gender         ,GenderLookupDto         >();
        CreateMap<Race           ,RaceLookupDto           >();
        CreateMap<Language       ,LanguageLookupDto       >();
        CreateMap<Ethnicity      ,EthnicityLookupDto      >();
        CreateMap<EducationLevel ,EducationLevelLookupDto >();
        CreateMap<Nationality    ,NationalityLookupDto    >();
        CreateMap<Citizen        ,CitizenLookupDto        >();
        CreateMap<Religion       ,ReligionLookupDto       >();
        CreateMap<MaritalStatus  ,MaritalStatusLookupDto  >();
        CreateMap<PatientCategory,PatientCategoryLookupDto>();
        CreateMap<NamePrefix     ,NamePrefixLookupDto>();
    }
}

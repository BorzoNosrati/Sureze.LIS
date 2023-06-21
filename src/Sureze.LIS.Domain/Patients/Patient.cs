using Sureze.LIS.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Sureze.LIS.Patients;

public class Patient : AggregateRoot<int>,IPatientFilter
{

    [Required]
    public string MRN { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public string NationalIDNumber { get; set; }

    public int? NamePrefixId { get; set; }
    public string? Suffix { get; set; }

    public string? AlternateIDNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int? PrimaryProviderId { get; set; }
    public int InActiveStatusId { get; set; }
    public int? AlternateIDTypeId { get; set; }
    public int? SexId { get; set; }
    public int? RaceId { get; set; }
    public int? LanguageId { get; set; }
    public int? EthnicityId { get; set; }
    public int? EducationLevelId { get; set; }
    public int? NationalityId { get; set; }
    public int? CitizenId { get; set; }
    public int? ReligionId { get; set; }
    public int? MaritalStatusId { get; set; }
    public int? PatientCategoryId { get; set; }
    public byte[] ProfilePicture { get; set; }





    public PrimaryProvider? PrimaryProvider { get; set; }
    public InActiveStatus InActiveStatus { get; set; }
    public AlternateIDType? AlternateIDType { get; set; }
    public Gender? Sex { get; set; }
    public Race? Race { get; set; }
    public Language? Language { get; set; }
    public Ethnicity? Ethnicity { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public Nationality? Nationality { get; set; }
    public Citizen? Citizen { get; set; }
    public Religion? Religion { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }
    public PatientCategory? PatientCategory { get; set; }
    public NamePrefix? NamePrefix { get; set; }
    
}

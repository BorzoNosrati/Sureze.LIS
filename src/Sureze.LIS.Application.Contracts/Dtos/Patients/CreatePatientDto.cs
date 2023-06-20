using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Sureze.LIS.Dtos.Patients;

public class CreatePatientDto: AuditedEntityDto<int>
{

    [Required]
    public string MRN { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string FirstName { get; set; }
    [StringLength(30, MinimumLength = 3)]
    public string LastName { get; set; }
    [Required]
    public string NationalIDNumber { get; set; }

    public int? PrimaryProviderId { get; set; }
    public int InActiveStatusId { get; set; }

    public int? NamePrefixId { get; set; }
    public string Suffix { get; set; }

    public int? AlternateIDTypeId { get; set; }
    public string AlternateIDNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
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




}
public class UpdatePatientDto: AuditedEntityDto<int>
{

    [Required]
    public string MRN { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string FirstName { get; set; }
    [StringLength(30, MinimumLength = 3)]
    public string LastName { get; set; }
    [Required]
    public string NationalIDNumber { get; set; }

    public int? PrimaryProviderId { get; set; }
    public int InActiveStatusId { get; set; }
    public int? NamePrefixId { get; set; }
    public string Suffix { get; set; }

    public int? AlternateIDTypeId { get; set; }
    public string AlternateIDNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public int? SexId { get; set; }
    public int? RaceId { get; set; }
    public int? LanguageId { get; set; }
    public int? EthnicityId { get; set; }
    public int? EducationLevelId { get; set; }
    public int? NationalityId { get; set; }
    public int CitizenId { get; set; }
    public int? ReligionId { get; set; }
    public int? MaritalStatusId { get; set; }
    public int? PatientCategoryId { get; set; }




}

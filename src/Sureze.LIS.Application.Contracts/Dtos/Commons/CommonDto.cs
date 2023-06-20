using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using Volo.Abp.Application.Dtos;

namespace Sureze.LIS.Application.Contracts.Dtos.Commons;

public abstract class CommonLookupDto:EntityDto<int>
{
    public string Name { get; set; }
    public string Title { get; set; }
}


public class PrimaryProviderLookupDto   : CommonLookupDto { }
public class InActiveStatusLookupDto    : CommonLookupDto { }
public class AlternateIDTypeLookupDto   : CommonLookupDto { }
public class GenderLookupDto            : CommonLookupDto { }
public class RaceLookupDto              : CommonLookupDto { }
public class LanguageLookupDto          : CommonLookupDto { }
public class EthnicityLookupDto         : CommonLookupDto { }
public class EducationLevelLookupDto    : CommonLookupDto { }
public class NationalityLookupDto       : CommonLookupDto { }
public class CitizenLookupDto           : CommonLookupDto { }
public class ReligionLookupDto          : CommonLookupDto { }
public class MaritalStatusLookupDto     : CommonLookupDto { }
public class PatientCategoryLookupDto   : CommonLookupDto { }
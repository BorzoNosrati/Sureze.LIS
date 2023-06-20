using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Sureze.LIS.Commons
{
    public abstract class CommonEntity : AggregateRoot<int>
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
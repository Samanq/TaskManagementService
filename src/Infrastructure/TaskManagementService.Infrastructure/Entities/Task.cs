using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementService.Infrastructure.Entities
{
    public record Task
    {
        [Key]
        [Range(1,99999)]
        public int Id { get; set; }

        [Range(1,99999)]
        public int? ParentTaskId { get; set; }

        [StringLength(30)]
        public string Title { get; set; } = string.Empty;

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Range(1,999)]
        public int EffortEstimation { get; set; }

        [Range(1,999)]
        public int AggregatedEfforEstimation
        {
            get { return SubTasks.Sum(a => a.EffortEstimation) + EffortEstimation; }
            set { value = SubTasks.Sum(a => a.EffortEstimation) + EffortEstimation; }
        }

        [StringLength(24)]
        public string CreationDate { get; set; } = string.Empty;

        [StringLength(11)]
        public string Status { get; set; } = string.Empty;


        // Navigation Properties
        [ForeignKey("ParentTaskId")]
        public virtual Task? ParentTask { get; set; }
        public ICollection<Task>? SubTasks { get; set; } = new HashSet<Task>();
    }
}

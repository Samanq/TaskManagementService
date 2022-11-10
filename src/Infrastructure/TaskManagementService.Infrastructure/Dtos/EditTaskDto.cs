using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Infrastructure.Dtos
{
    public record EditTaskDto
    {
        [StringLength(30)]
        public string Title { get; set; } = string.Empty;

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Precision(3)]
        public int EffortEstimation { get; set; }

        [StringLength(11)]
        public string Status { get; set; } = string.Empty;
    }
}

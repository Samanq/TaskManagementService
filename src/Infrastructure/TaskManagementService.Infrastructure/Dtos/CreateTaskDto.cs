using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Infrastructure.Dtos
{
    public record CreateTaskDto
    {
        [StringLength(30)]
        public string Title { get; set; } = string.Empty;

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Precision(3)]
        public int EffortEstimation { get; set; }
    }
}

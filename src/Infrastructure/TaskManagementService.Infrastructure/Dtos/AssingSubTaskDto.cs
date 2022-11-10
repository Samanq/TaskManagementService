using Microsoft.EntityFrameworkCore;

namespace TaskManagementService.Infrastructure.Dtos
{
    public record AssingSubTaskDto
    {
        [Precision(5)]
        public int ParentId { get; set; }
    }
}

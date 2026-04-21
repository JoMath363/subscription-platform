using System.ComponentModel.DataAnnotations;

namespace Api.Solution.Models
{
    public class UpMonitor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Url]
        public required string Url { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public required Guid ProjectId { get; set; }
        public required Project Project { get; set; }
    }
}

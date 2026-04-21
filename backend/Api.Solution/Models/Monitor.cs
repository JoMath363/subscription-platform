using System.ComponentModel.DataAnnotations;

namespace Api.Solution.Models
{
    public class Monitor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLengthAttribute(50, ErrorMessage = "{0} cannot exceed 50 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [UrlAttribute]
        public required string Url { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public required Guid WatcherColletionId { get; set; }
        public required Project WatcherColletion { get; set; }
    }
}

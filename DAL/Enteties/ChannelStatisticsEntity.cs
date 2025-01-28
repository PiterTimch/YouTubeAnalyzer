using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Enteties
{
    [Table("channel_statistics_tbl")]
    public class ChannelStatisticsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ChannelName { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string Url { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string AvatarUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ViewsCount { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int SubsCount { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosCount { get; set; }
    }
}

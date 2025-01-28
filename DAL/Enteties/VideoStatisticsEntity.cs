using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Enteties
{
    [Table("video_statistics_tbl")]
    public class VideoStatisticsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Url { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ChannelUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ViewsCount { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int LikesCount { get; set; }

        [Range(0, int.MaxValue)]
        public int CommentsCount { get; set; }

        [Required]
        [MaxLength(255)]
        public string PreviewUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("Channel")]
        public int? ChannelId { get; set; }
        public ChannelStatisticsEntity? Channel { get; set; }
    }
}

namespace DTO_WinformsYoutube
{
    public class YTVideoDTO
    {
        public string VideoId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ChannelTitle { get; set; } = string.Empty;
        public long ViewCount { get; set; }
        public string ThumbnailUrl { get; set; } = string.Empty;
        public long LikeCount { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

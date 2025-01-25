using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enteties.API_Entities.Channel
{
    public class ChannelItemResponseEntity
    {
        public string Id { get; set; } = string.Empty;
        public SnippetChannelEntity Snippet { get; set; }
        public StatisticsChannelEntity Statistics { get; set; }
    }

    public class SnippetChannelEntity 
    {
        public string Title { get; set; } = string.Empty;
    }

    public class StatisticsChannelEntity
    {
        public string ViewCount { get; set; } = string.Empty;
        public string SubscriberCount { get; set; } = string.Empty;
        public string VideoCount { get; set; } = string.Empty;
    }
}

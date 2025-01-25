using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enteties.API_Entities.Channel
{
    public class ChannelResponseEntity
    {
        public string Kind { get; set; } = string.Empty;
        public string Etag { get; set; } = string.Empty;
        public object PageInfo { get; set; } = new object();
        public ICollection<ChannelItemResponseEntity> Items { get; set; }
    }
}

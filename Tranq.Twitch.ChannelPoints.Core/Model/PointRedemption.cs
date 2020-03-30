using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranq.Twitch.ChannelPoints.Core.Model
{
    public class PointRedemption
    {
        public DateTime TimeStamp { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
        public Guid RewardId { get; set; }
        public string RewardName { get; set; }
    }
}

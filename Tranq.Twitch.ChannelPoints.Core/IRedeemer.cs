using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.Core
{
    public interface IRedeemer
    {
        OptionAction RedemptionType { get; }
        void Handle(PointRedemption pointRedemption, RedemptionOption redemptionOption);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.TwitchIntegration.Events;

namespace Tranq.Twitch.ChannelPoints.TwitchIntegration
{
    public interface ITwitchClientIntegration : ISimpleTwitchClient
    {
        event EventHandler<RewardRedeemedEvent> OnRewardRedeemed;

        Task ConnectAndSubscribe();
        void Disconnect();
    }
}

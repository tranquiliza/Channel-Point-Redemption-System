using System;
using TwitchLib.PubSub.Events;

namespace Tranq.Twitch.ChannelPoints.TwitchIntegration.Events
{
    public class RewardRedeemedEvent
    {
        public DateTime TimeStamp { get; set; }
        public string ChannelId { get; set; }
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
        public Guid RewardId { get; set; }
        public string RewardTitle { get; set; }
        public string RewardPrompt { get; set; }
        public int RewardCost { get; set; }
        public string Status { get; set; }

        internal static RewardRedeemedEvent Create(OnRewardRedeemedArgs e)
            => new RewardRedeemedEvent
            {
                ChannelId = e.ChannelId,
                DisplayName = e.DisplayName,
                Login = e.Login,
                Message = e.Message,
                RewardCost = e.RewardCost,
                RewardId = e.RewardId,
                RewardPrompt = e.RewardPrompt,
                RewardTitle = e.RewardTitle,
                Status = e.Status,
                TimeStamp = e.TimeStamp
            };
    }
}

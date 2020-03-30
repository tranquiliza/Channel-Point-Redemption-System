using System.Collections.Generic;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.Core
{
    public interface IRepository
    {
        void Save(PointRedemption pointRedemption);
        void Save(RedemptionOption redemptionOption);
        RedemptionOption GetRedemptionOption(string rewardName);
        List<RedemptionOption> GetRedemptionOptions();
        ApplicationSettings GetSettings();
        void DeleteRedemptionOption(string rewardName);
    }
}

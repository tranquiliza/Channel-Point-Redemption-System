using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.Core
{
    public interface IChannelPointsService
    {
        event EventHandler<PointRedemption> OnRewardRedeemed;
        event EventHandler<string> OnNewRedemptionRewardDetected;
        event EventHandler<string> OnExistingRedemptionRewardNeedingSetup;

        Task Connect();
        List<RedemptionOption> GetOptions();
        void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction, string audioFileName);
        void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction, string command, bool requiresInput, bool executeOnRedeemer, bool respondInChat, string chatResponse);
        void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction);
        void DeleteRewardOption(RedemptionOption redemptionOption);
    }
}

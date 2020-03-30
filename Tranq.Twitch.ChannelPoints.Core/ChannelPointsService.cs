using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.Core.Model;
using Tranq.Twitch.ChannelPoints.TwitchIntegration;
using Tranq.Twitch.ChannelPoints.TwitchIntegration.Events;

namespace Tranq.Twitch.ChannelPoints.Core
{
    public class ChannelPointsService : IChannelPointsService
    {
        private readonly ITwitchClientIntegration twitchClient;
        private readonly IRepository repository;
        private readonly RedeemerOchestrator redeemerOchestrator;

        public ChannelPointsService(ITwitchClientIntegration twitchClient, IRepository repository, RedeemerOchestrator redeemerOchestrator)
        {
            this.twitchClient = twitchClient;
            this.repository = repository;
            this.redeemerOchestrator = redeemerOchestrator;

            this.twitchClient.OnRewardRedeemed += TwitchClient_OnRewardRedeemed;
        }

        public event EventHandler<PointRedemption> OnRewardRedeemed;
        public event EventHandler<string> OnNewRedemptionRewardDetected;
        public event EventHandler<string> OnExistingRedemptionRewardNeedingSetup;

        // Message status returns: 
        // UNFULFILLED
        private void TwitchClient_OnRewardRedeemed(object sender, RewardRedeemedEvent e)
        {
            // TODO make proper mitigation of this issue.
            if (!string.Equals(e.Status, "UNFULFILLED", StringComparison.OrdinalIgnoreCase))
                return;

            var pointRedemption = new PointRedemption
            {
                DisplayName = e.DisplayName,
                Message = e.Message,
                RewardId = e.RewardId,
                RewardName = e.RewardTitle,
                TimeStamp = e.TimeStamp
            };

            var redemptionOption = repository.GetRedemptionOption(e.RewardTitle);
            if (redemptionOption == null)
            {
                redemptionOption = new RedemptionOption(e.RewardTitle);
                repository.Save(redemptionOption);
                OnNewRedemptionRewardDetected?.Invoke(this, "NEW REWARD DETECTED; NEEDS SETUP!");
            }
            else if (redemptionOption.OptionAction == OptionAction.NoAction)
            {
                OnExistingRedemptionRewardNeedingSetup?.Invoke(this, "EXISTING REWARD DETECTED, STILL NEED SETUP!");
            }
            else
            {
                // REDEEM THAT FUCKERRR!
                var redeemer = redeemerOchestrator.GetRedeemer(redemptionOption.OptionAction);
                redeemer.Handle(pointRedemption, redemptionOption);
            }

            repository.Save(pointRedemption);
            OnRewardRedeemed?.Invoke(this, pointRedemption);
        }

        public Task Connect() => twitchClient.ConnectAndSubscribe();

        public List<RedemptionOption> GetOptions()
        {
            return repository.GetRedemptionOptions();
        }

        public void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction, string audioFileName)
        {
            redemptionOption.SetOptionAction(optionAction);
            if (audioFileName != string.Empty)
                redemptionOption.SetAudioFile(audioFileName);

            repository.Save(redemptionOption);
        }

        public void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction, string command, bool requiresInput, bool executeOnRedeemer, bool respondInChat, string chatResponse)
        {
            redemptionOption.SetOptionAction(optionAction);
            if (command != string.Empty)
                redemptionOption.SetChatCommand(command, requiresInput, executeOnRedeemer);

            if (chatResponse != string.Empty)
                redemptionOption.SetChatResponse(chatResponse, respondInChat);

            repository.Save(redemptionOption);
        }

        public void UpdateRedemptionOption(RedemptionOption redemptionOption, OptionAction optionAction)
        {
            redemptionOption.SetOptionAction(optionAction);

            repository.Save(redemptionOption);
        }

        public void DeleteRewardOption(RedemptionOption redemptionOption)
        {
            repository.DeleteRedemptionOption(redemptionOption.RewardName);
        }
    }
}

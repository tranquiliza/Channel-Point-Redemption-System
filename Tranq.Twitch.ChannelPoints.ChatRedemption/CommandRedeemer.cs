using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.Core.Model;
using Tranq.Twitch.ChannelPoints.TwitchIntegration;

namespace Tranq.Twitch.ChannelPoints.ChatRedemption
{
    public class CommandRedeemer : IRedeemer
    {
        private readonly ISimpleTwitchClient twitchClient;
        public OptionAction RedemptionType => OptionAction.TwitchCommand;

        private readonly TimeSpan ResponseDelay = TimeSpan.FromSeconds(2);

        public CommandRedeemer(ISimpleTwitchClient twitchClient)
        {
            this.twitchClient = twitchClient;
        }

        public void Handle(PointRedemption pointRedemption, RedemptionOption redemptionOption)
        {
            if (redemptionOption.ExecuteOnRedeemer)
                twitchClient.SendChatMessage($"{redemptionOption.ChatCommand} {pointRedemption.DisplayName}");
            else if (redemptionOption.UsesInput)
                twitchClient.SendChatMessage($"{redemptionOption.ChatCommand} {pointRedemption.Message}");
            else
                twitchClient.SendChatMessage($"{redemptionOption.ChatCommand}");

            if (redemptionOption.RespondInChat)
            {
                // Not happy about blocking thread. Hmm 
                Thread.Sleep(ResponseDelay);
                twitchClient.SendChatMessage($"{redemptionOption.ChatResponse}");
            }

            // Could add a way to log that a redemption was successful
        }
    }
}

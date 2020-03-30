using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranq.Twitch.ChannelPoints.Core.Model
{
    public enum OptionAction
    {
        NoAction = 0,
        TwitchCommand = 1,
        AudioCommand = 2
    }

    public class RedemptionOption
    {
        [JsonProperty]
        public string RewardName { get; private set; }

        [JsonProperty]
        public OptionAction OptionAction { get; private set; }

        [JsonProperty]
        public string AudioFile { get; private set; }

        [JsonProperty]
        public bool UsesInput { get; private set; }

        [JsonProperty]
        public string ChatCommand { get; private set; }

        [JsonProperty]
        public string ChatResponse { get; private set; }

        [JsonProperty]
        public bool RespondInChat { get; private set; }

        [JsonProperty]
        public bool ExecuteOnRedeemer { get; private set; }

        public RedemptionOption(string rewardName)
        {
            RewardName = rewardName;
            OptionAction = OptionAction.NoAction;
        }

        public override string ToString()
        {
            return $"{RewardName} {(OptionAction == OptionAction.NoAction ? ": No Action" : "")}";
        }

        internal void SetOptionAction(OptionAction optionAction)
        {
            OptionAction = optionAction;
        }

        internal void SetAudioFile(string audioFileName)
        {
            AudioFile = audioFileName;
        }

        internal void SetChatCommand(string command, bool requiresInput, bool executeOnRedeemer)
        {
            ChatCommand = command;
            UsesInput = requiresInput;
            ExecuteOnRedeemer = executeOnRedeemer;
        }

        internal void SetChatResponse(string response, bool respondInChat)
        {
            ChatResponse = response;
            RespondInChat = respondInChat;
        }
    }
}

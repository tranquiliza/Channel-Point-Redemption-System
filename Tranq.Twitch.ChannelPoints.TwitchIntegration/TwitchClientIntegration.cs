using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.TwitchIntegration.Events;
using TwitchLib.Api;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;

namespace Tranq.Twitch.ChannelPoints.TwitchIntegration
{
    public class TwitchClientIntegration : ITwitchClientIntegration
    {
        private readonly TwitchPubSub twitchPubSub;
        private readonly TwitchAPI twitchAPI;
        private readonly TwitchClient twitchClient;
        private readonly string oathToken;
        private readonly string username;

        /// <summary>
        /// https://twitchtokengenerator.com/ for the token.
        /// Currently needs:
        /// channel_read
        /// chat_login
        /// chat:read
        /// chat:edit
        /// channel:moderate
        /// channel:read:redemptions
        /// </summary>
        /// <param name="oathToken"></param>
        public TwitchClientIntegration(string username, string oathToken)
        {
            this.oathToken = oathToken;
            this.username = username;
            this.twitchPubSub = new TwitchPubSub();
            this.twitchAPI = new TwitchAPI();

            var credentials = new ConnectionCredentials(username, oathToken);
            this.twitchClient = new TwitchClient();
            this.twitchClient.Initialize(credentials);

            twitchPubSub.OnPubSubServiceConnected += TwitchPubSub_OnPubSubServiceConnected;
            twitchPubSub.OnRewardRedeemed += TwitchPubSub_OnRewardRedeemed;

            twitchClient.OnConnected += TwitchClient_OnConnected;
        }

        private void TwitchPubSub_OnRewardRedeemed(object sender, OnRewardRedeemedArgs e)
        {
            OnRewardRedeemed?.Invoke(this, RewardRedeemedEvent.Create(e));
        }

        private TaskCompletionSource<bool> _pubSubConnectionCompletionTask = new TaskCompletionSource<bool>();

        private void TwitchPubSub_OnPubSubServiceConnected(object sender, EventArgs e)
        {
            twitchPubSub.OnPubSubServiceConnected -= TwitchPubSub_OnPubSubServiceConnected;

            _pubSubConnectionCompletionTask.SetResult(true);
            _pubSubConnectionCompletionTask = new TaskCompletionSource<bool>();
        }

        public event EventHandler<RewardRedeemedEvent> OnRewardRedeemed;

        private TaskCompletionSource<bool> _clientConnectionCompletionTask = new TaskCompletionSource<bool>();

        private void TwitchClient_OnConnected(object sender, OnConnectedArgs e)
        {
            twitchClient.OnConnected -= TwitchClient_OnConnected;

            _clientConnectionCompletionTask.SetResult(true);
            _clientConnectionCompletionTask = new TaskCompletionSource<bool>();
        }

        public async Task ConnectAndSubscribe()
        {
            twitchPubSub.Connect();
            await _pubSubConnectionCompletionTask.Task.ConfigureAwait(false);

            twitchClient.Connect();
            await _clientConnectionCompletionTask.Task.ConfigureAwait(false);

            await SubscribeToTopics().ConfigureAwait(false);

            await JoinChatChannel().ConfigureAwait(false);
        }

        private async Task SubscribeToTopics()
        {
            var channel = await twitchAPI.V5.Channels.GetChannelAsync(oathToken).ConfigureAwait(false);
            if (channel == null)
                throw new Exception("Unable to fetch channel");

            twitchPubSub.ListenToRewards(channel.Id);
            twitchPubSub.SendTopics(oathToken);
        }

        private async Task JoinChatChannel()
        {
            twitchClient.OnJoinedChannel += TwitchClient_OnJoinedChannel;
            twitchClient.JoinChannel(username);

            await _joinChannelCompletionTask.Task.ConfigureAwait(false);
        }

        private TaskCompletionSource<bool> _joinChannelCompletionTask = new TaskCompletionSource<bool>();

        private void TwitchClient_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            twitchClient.OnJoinedChannel -= TwitchClient_OnJoinedChannel;

            _joinChannelCompletionTask.SetResult(true);
            _joinChannelCompletionTask = new TaskCompletionSource<bool>();
        }

        public void Disconnect()
        {
            twitchPubSub.Disconnect();
            twitchClient.Disconnect();
        }

        public void SendChatMessage(string message)
        {
            twitchClient.SendMessage(username, message);
        }
    }
}

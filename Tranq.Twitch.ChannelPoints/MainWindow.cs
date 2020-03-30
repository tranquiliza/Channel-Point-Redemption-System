using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.SoundRedemption;
using Tranq.Twitch.ChannelPoints.TwitchIntegration;
using Tranq.Twitch.ChannelPoints.TwitchIntegration.Events;

namespace Tranq.Twitch.ChannelPoints
{
    public partial class MainWindow : Form
    {
        private readonly IChannelPointsService channelPointsService;

        public MainWindow(IChannelPointsService channelPointsService)
        {
            InitializeComponent();
            this.channelPointsService = channelPointsService;

            this.channelPointsService.OnRewardRedeemed += ChannelPointsService_OnRewardRedeemed;
            this.channelPointsService.OnNewRedemptionRewardDetected += ChannelPointsService_OnNewRedemptionRewardDetected;
            this.channelPointsService.OnExistingRedemptionRewardNeedingSetup += ChannelPointsService_OnExistingRedemptionRewardNeedingSetup;
        }

        private void ChannelPointsService_OnExistingRedemptionRewardNeedingSetup(object sender, string e)
        {
            Invoke((MethodInvoker)(() => richTextBox1.Text += Environment.NewLine + ($"NEEDS SETUP (EXISTING) {e}")));
        }

        private void ChannelPointsService_OnNewRedemptionRewardDetected(object sender, string e)
        {
            this.redemptionOptionsUserControl1.LoadOptions();

            Invoke((MethodInvoker)(() => richTextBox1.Text += Environment.NewLine + ($"NEEDS SETUP (FIRST) {e}")));
        }

        private void ChannelPointsService_OnRewardRedeemed(object sender, Core.Model.PointRedemption e)
        {
            Invoke((MethodInvoker)(() => richTextBox1.Text += Environment.NewLine + ($"{e.DisplayName} REDEEMED {e.RewardName}: {e.Message}")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            await channelPointsService.Connect();
            richTextBox1.Text += Environment.NewLine + ("CONNECTED!");
            this.redemptionOptionsUserControl1.RedemptionOptionsWindow_Load(channelPointsService);
        }

        //private void redemptionOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //var optionsForm = new RedemptionOptionsWindow(channelPointsService);
        //    //optionsForm.ShowDialog();
        //}
    }
}

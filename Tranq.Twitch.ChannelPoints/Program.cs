using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tranq.Twitch.ChannelPoints.ChatRedemption;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.Repository;
using Tranq.Twitch.ChannelPoints.SoundRedemption;
using Tranq.Twitch.ChannelPoints.TwitchIntegration;

namespace Tranq.Twitch.ChannelPoints
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var fileRepository = new FileRepository("settings");
            var settings = fileRepository.GetSettings();
            if (string.IsNullOrEmpty(settings.OAuthToken) || string.IsNullOrEmpty(settings.Username))
            {
                MessageBox.Show("You need to enter settings into settings file. Find it in settings/applicationSettings.json");
                Application.Exit();
                return;
            }

            var twitchClient = new TwitchClientIntegration(settings.Username, settings.OAuthToken);
            var soundRedeemer = new SoundRedeemer();
            var commandRedeemer = new CommandRedeemer(twitchClient);
            var redeemerOrchestrator = RedeemerOchestrator
                                        .CreateWith(soundRedeemer)
                                        .With(commandRedeemer);

            var channelPointService = new ChannelPointsService(twitchClient, fileRepository, redeemerOrchestrator);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(channelPointService));
        }
    }
}

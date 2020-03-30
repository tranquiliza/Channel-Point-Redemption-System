using NAudio.Wave;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.SoundRedemption
{
    public class SoundRedeemer : IRedeemer
    {
        private readonly IWavePlayer waveOutDevice;

        public SoundRedeemer()
        {
            waveOutDevice = new WaveOut();
        }

        public OptionAction RedemptionType => OptionAction.AudioCommand;

        public void Handle(PointRedemption pointRedemption, RedemptionOption redemptionOption)
        {
            if (redemptionOption == null)
                return;

            var audioFileReader = new AudioFileReader(redemptionOption.AudioFile);

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();

            // Could add a way to log that a redemption was successful
        }
    }
}

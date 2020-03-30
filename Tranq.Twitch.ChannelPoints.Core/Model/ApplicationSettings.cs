using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranq.Twitch.ChannelPoints.Core.Model
{
    public class ApplicationSettings
    {
        [JsonProperty]
        public string Username { get; private set; }

        [JsonProperty]
        public string OAuthToken { get; private set; }

        public ApplicationSettings()
        {
            Username = string.Empty;
            OAuthToken = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.Core
{
    public sealed class RedeemerOchestrator
    {
        private readonly List<IRedeemer> RegisteredRedeemers;

        private RedeemerOchestrator(IRedeemer redeemer)
        {
            RegisteredRedeemers = new List<IRedeemer>() { redeemer };
        }

        public static RedeemerOchestrator CreateWith(IRedeemer redeemer)
        {
            return new RedeemerOchestrator(redeemer);
        }

        public RedeemerOchestrator With(IRedeemer redeemer)
        {
            if (RegisteredRedeemers.Any(x => x.RedemptionType == redeemer.RedemptionType))
                throw new Exception("This type of redemption has already been registered");

            RegisteredRedeemers.Add(redeemer);

            return this;
        }

        public IRedeemer GetRedeemer(OptionAction optionAction)
            => RegisteredRedeemers.First(x => x.RedemptionType == optionAction);
    }
}

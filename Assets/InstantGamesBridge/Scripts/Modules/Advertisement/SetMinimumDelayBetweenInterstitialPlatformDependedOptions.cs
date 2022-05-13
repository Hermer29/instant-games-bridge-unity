namespace InstantGamesBridge.Modules.Advertisement
{
    public abstract class SetMinimumDelayBetweenInterstitialPlatformDependedOptions : PlatformDependedOptionsBase
    {
        public int seconds;

        protected SetMinimumDelayBetweenInterstitialPlatformDependedOptions(int seconds)
        {
            this.seconds = seconds;
        }
    }
}
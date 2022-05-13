namespace InstantGamesBridge.Modules.Advertisement
{
    public abstract class ShowInterstitialPlatformDependedOptions : PlatformDependedOptionsBase
    {
        public bool ignoreDelay;

        protected ShowInterstitialPlatformDependedOptions(bool ignoreDelay)
        {
            this.ignoreDelay = ignoreDelay;
        }
    }
}
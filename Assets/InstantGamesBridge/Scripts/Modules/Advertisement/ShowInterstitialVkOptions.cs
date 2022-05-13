namespace InstantGamesBridge.Modules.Advertisement
{
    public class ShowInterstitialVkOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialVkOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
        }
    }
}
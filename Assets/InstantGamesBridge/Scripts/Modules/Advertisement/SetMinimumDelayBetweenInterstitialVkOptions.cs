namespace InstantGamesBridge.Modules.Advertisement
{
    public class SetMinimumDelayBetweenInterstitialVkOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialVkOptions(int seconds) : base(seconds)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
        }
    }
}
namespace InstantGamesBridge.Modules.Advertisement
{
    public class SetMinimumDelayBetweenInterstitialYandexOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialYandexOptions(int seconds) : base(seconds)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
        }
    }
}
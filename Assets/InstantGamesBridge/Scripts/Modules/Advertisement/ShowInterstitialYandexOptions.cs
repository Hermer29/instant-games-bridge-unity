namespace InstantGamesBridge.Modules.Advertisement
{
    public class ShowInterstitialYandexOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialYandexOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
        }
    }
}
namespace InstantGamesBridge.Modules.Player
{
    public class AuthorizeYandexOptions : AuthorizePlatformDependedOptions
    {
        public bool scopes;

        public AuthorizeYandexOptions(bool scopes)
        {
            _targetPlatform = OptionsTargetPlatform.Yandex;
            this.scopes = scopes;
        }
    }
}
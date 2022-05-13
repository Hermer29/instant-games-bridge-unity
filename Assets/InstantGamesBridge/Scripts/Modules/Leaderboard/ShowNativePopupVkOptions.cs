namespace InstantGamesBridge.Modules.Leaderboard
{
    public class ShowNativePopupVkOptions : ShowNativePopupPlatformDependedOptions
    {
        public int userResult;

        public bool global;

        public ShowNativePopupVkOptions(int userResult, bool global)
        {
            _targetPlatform = OptionsTargetPlatform.VK;
            this.userResult = userResult;
            this.global = global;
        }
    }
}
#if UNITY_WEBGL
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class Platform
    {
#if !UNITY_EDITOR
        public string id { get; } = InstantGamesBridgeGetPlatformId();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformId();
#else
        public string id { get; } = "mock";
#endif
    }
}
#endif
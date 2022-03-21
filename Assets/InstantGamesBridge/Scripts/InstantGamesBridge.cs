#if UNITY_WEBGL
using System;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class InstantGamesBridge : Singleton<InstantGamesBridge>
    {
        public const string version = "1.0.2";

        public static bool isInitialized { get; private set; }

        public static Advertisement advertisement { get; private set; }

        public static Game game { get; private set; }

        public static Platform platform { get; private set; }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInitialize();
#endif

        private Action<bool> _initializationCallback;


        public static void Initialize(Action<bool> onComplete = null)
        {
            if (isInitialized)
            {
                onComplete?.Invoke(true);
                return;
            }

            instance._initializationCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeInitialize();
#else
            instance.OnInitializationCompleted("true");
#endif
        }


        // Called from JS
        private void OnInitializationCompleted(string result)
        {
            isInitialized = result == "true";

            if (isInitialized)
            {
                advertisement = gameObject.AddComponent<Advertisement>();
                game = gameObject.AddComponent<Game>();
                platform = new Platform();
            }

            _initializationCallback?.Invoke(isInitialized);
            _initializationCallback = null;
        }
    }
}
#endif
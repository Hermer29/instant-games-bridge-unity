#if UNITY_WEBGL
using System;
#if !UNITY_EDITOR
using UnityEngine;
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class InstantGamesBridge : Singleton<InstantGamesBridge>
    {
        public static bool isInitialized { get; private set; }

        public static Advertisement advertisement { get; private set; }

        public static Game game { get; private set; }

        public static Platform platform { get; private set; }

        public static Social social { get; private set; }

        public static Player player { get; private set; }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInitialize(string settings);
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
            var settings = Resources.Load<InstantGamesBridgeSettings>("InstantGamesBridgeSettings");
            var settingsJson = string.Empty;

            if (settings)
                settingsJson = JsonUtility.ToJson(settings);

            InstantGamesBridgeInitialize(settingsJson);
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
                platform = new Platform();
                player = gameObject.AddComponent<Player>();
                game = gameObject.AddComponent<Game>();
                advertisement = gameObject.AddComponent<Advertisement>();
                social = gameObject.AddComponent<Social>();
            }

            _initializationCallback?.Invoke(isInitialized);
            _initializationCallback = null;
        }
    }
}
#endif
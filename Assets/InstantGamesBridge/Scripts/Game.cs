#if UNITY_WEBGL
using System;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class Game : MonoBehaviour
    {
#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeGetGameData(string key);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeSetGameData(string key, string value);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeDeleteGameData(string key);
#else
        private const string _gameDataPlayerPrefsPrefix = "game_data";
#endif

        private Action<string> _getDataCallback;

        private Action<bool> _setDataCallback;

        private Action<bool> _deleteDataCallback;


        public void GetData(string key, Action<string> onComplete)
        {
            _getDataCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeGetGameData(key);
#else
            var data = PlayerPrefs.GetString($"{_gameDataPlayerPrefsPrefix}_{key}", null);
            OnGetGameDataCompleted(data);
#endif
        }

        public void SetData(string key, string value, Action<bool> onComplete = null)
        {
            _setDataCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeSetGameData(key, value);
#else
            PlayerPrefs.SetString($"{_gameDataPlayerPrefsPrefix}_{key}", value);
            OnSetGameDataCompleted("true");
#endif
        }

        public void SetData(string key, int value, Action<bool> onComplete = null)
        {
            SetData(key, value.ToString(), onComplete);
        }

        public void SetData(string key, bool value, Action<bool> onComplete = null)
        {
            SetData(key, value.ToString(), onComplete);
        }

        public void DeleteData(string key, Action<bool> onComplete = null)
        {
            _deleteDataCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeDeleteGameData(key);
#else
            PlayerPrefs.DeleteKey($"{_gameDataPlayerPrefsPrefix}_{key}");
            OnDeleteGameDataCompleted("true");
#endif
        }


        // Called from JS
        private void OnGetGameDataCompleted(string result)
        {
            _getDataCallback?.Invoke(string.IsNullOrEmpty(result) ? null : result);
            _getDataCallback = null;
        }

        private void OnSetGameDataCompleted(string result)
        {
            var isSuccess = result == "true";
            _setDataCallback?.Invoke(isSuccess);
            _setDataCallback = null;
        }

        private void OnDeleteGameDataCompleted(string result)
        {
            var isSuccess = result == "true";
            _deleteDataCallback?.Invoke(isSuccess);
            _deleteDataCallback = null;
        }
    }
}
#endif
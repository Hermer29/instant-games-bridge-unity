using System;
using UnityEngine;
#if UNITY_WEBGL
#if !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Game
{
    public class GameModule : MonoBehaviour
    {
        public event Action<VisibilityState> visibilityStateChanged;

        public VisibilityState visibilityState { get; private set; }

        // Called from JS
        private void OnVisibilityStateChanged(string value)
        {
            if (Enum.TryParse<VisibilityState>(value, true, out var state))
            {
                visibilityState = state;
                visibilityStateChanged?.Invoke(visibilityState);
            }
        }
    }
}
#endif
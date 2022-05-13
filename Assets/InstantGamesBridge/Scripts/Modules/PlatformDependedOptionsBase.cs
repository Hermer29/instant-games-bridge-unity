using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules
{
    public abstract class PlatformDependedOptionsBase
    {
        protected OptionsTargetPlatform _targetPlatform;

        public OptionsTargetPlatform GetTargetPlatform()
        {
            return _targetPlatform;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this).SurroundWithKey(_targetPlatform.ToString().ToLower());
        }
    }
}
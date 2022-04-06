using UnityEngine;

namespace MewtonGames
{
    [CreateAssetMenu(fileName = "InstantGamesBridgeSettings", menuName = "InstantGamesBridge/Settings")]
    public class InstantGamesBridgeSettings : ScriptableObject
    {
        public PlatformsSettings platforms;
    }
}
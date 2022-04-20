#if UNITY_WEBGL
using System;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class Advertisement : MonoBehaviour
    {
        public event Action<InterstitialState> interstitialStateChanged;

        public event Action<RewardedState> rewardedStateChanged;

        public InterstitialState interstitialState { get; private set; }

        public RewardedState rewardedState { get; private set; }

        public int minimumDelayBetweenInterstitial
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeMinimumDelayBetweenInterstitial();
#else
                return 60;
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern int InstantGamesBridgeMinimumDelayBetweenInterstitial();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeSetMinimumDelayBetweenInterstitial(int seconds);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowInterstitial(bool ignoreDelay);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowRewarded();
#endif

        private Action<bool> _showInterstitialCallback;

        private Action<bool> _showRewardedCallback;


        public void SetMinimumDelayBetweenInterstitial(int seconds)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeSetMinimumDelayBetweenInterstitial(seconds);
#endif
        }

        public void ShowInterstitial(bool ignoreDelay = false, Action<bool> onComplete = null)
        {
            _showInterstitialCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeShowInterstitial(ignoreDelay);
#else
            OnShowInterstitialCompleted("true");
            OnInterstitialStateChanged(InterstitialState.Opened.ToString());
            OnInterstitialStateChanged(InterstitialState.Closed.ToString());
#endif
        }

        public void ShowRewarded(Action<bool> onComplete = null)
        {
            _showRewardedCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeShowRewarded();
#else
            OnShowRewardedCompleted("true");
            OnRewardedStateChanged(RewardedState.Opened.ToString());
            OnRewardedStateChanged(RewardedState.Rewarded.ToString());
            OnRewardedStateChanged(RewardedState.Closed.ToString());
#endif
        }


        // Called from JS
        private void OnShowInterstitialCompleted(string result)
        {
            var isSuccess = result == "true";
            _showInterstitialCallback?.Invoke(isSuccess);
            _showInterstitialCallback = null;
        }

        private void OnShowRewardedCompleted(string result)
        {
            var isSuccess = result == "true";
            _showRewardedCallback?.Invoke(isSuccess);
            _showRewardedCallback = null;
        }

        private void OnInterstitialStateChanged(string value)
        {
            if (Enum.TryParse<InterstitialState>(value, true, out var state))
            {
                interstitialState = state;
                interstitialStateChanged?.Invoke(interstitialState);
            }
        }

        private void OnRewardedStateChanged(string value)
        {
            if (Enum.TryParse<RewardedState>(value, true, out var state))
            {
                rewardedState = state;
                rewardedStateChanged?.Invoke(rewardedState);
            }
        }
    }
}
#endif
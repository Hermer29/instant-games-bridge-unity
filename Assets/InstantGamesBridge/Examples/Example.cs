using UnityEngine;
using UnityEngine.UI;

namespace MewtonGames
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;

        [SerializeField] private Text _text;

        [SerializeField] private Button _showInterstitialButton;

        [SerializeField] private Button _showInterstitialWithIgnoringDelayButton;

        [SerializeField] private Button _showRewardedButton;

        [SerializeField] private Button _incrementCoinsButton;

        private const string _coinsKey = "coins";

        private int _coins;


        private void Start()
        {
            InstantGamesBridge.Initialize(OnInstantGamesBridgeInitializationCompleted);
        }

        private void OnInstantGamesBridgeInitializationCompleted(bool result)
        {
            Log("OnInstantGamesBridgeInitializationCompleted, result: " + result);

            if (result)
            {
                _showInterstitialButton.onClick.AddListener(OnShowInterstitialButtonClicked);
                _showInterstitialWithIgnoringDelayButton.onClick.AddListener(OnShowInterstitialWithIgnoringDelayButtonClicked);
                _showRewardedButton.onClick.AddListener(OnShowRewardedButtonClicked);
                _incrementCoinsButton.onClick.AddListener(OnIncrementCoinsButtonClicked);

                InstantGamesBridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
                InstantGamesBridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;

                InstantGamesBridge.advertisement.SetMinimumDelayBetweenInterstitial(5);
                InstantGamesBridge.game.GetData(_coinsKey, OnGetGameDataCompleted);

                Log($"Platform ID: { InstantGamesBridge.platform.id }, language: { InstantGamesBridge.platform.language }, payload: { InstantGamesBridge.platform.payload }");
            }
        }


        private void OnShowInterstitialButtonClicked()
        {
            Log("Show Interstitial");
            InstantGamesBridge.advertisement.ShowInterstitial(false, OnShowInterstitialCompleted);
        }

        private void OnShowInterstitialWithIgnoringDelayButtonClicked()
        {
            Log("Show Interstitial (ignore delay)");
            InstantGamesBridge.advertisement.ShowInterstitial(true, OnShowInterstitialCompleted);
        }

        private void OnShowRewardedButtonClicked()
        {
            Log("Show Rewarded");
            InstantGamesBridge.advertisement.ShowRewarded();
        }

        private void OnIncrementCoinsButtonClicked()
        {
            _coins++;
            Log($"Increment Coins, coins: {_coins}");
            InstantGamesBridge.game.SetData(_coinsKey, _coins.ToString(), OnSetGameDataCompleted);
        }


        private void OnShowInterstitialCompleted(bool result)
        {
            Log($"OnShowInterstitialCompleted, result: { result }");
        }

        private void OnInterstitialStateChanged(InterstitialState state)
        {
            Log($"OnInterstitialStateChanged, state: { state }");
        }

        private void OnRewardedStateChanged(RewardedState state)
        {
            Log($"OnRewardedStateChanged, state: { state }");
        }

        private void OnGetGameDataCompleted(string result)
        {
            if (result != null)
            {
                int.TryParse(result, out _coins);
                Log($"OnGetGameDataCompleted, coins: { result }");
            }
            else
                Log("OnGetGameDataCompleted, coins: null");
        }

        private void OnSetGameDataCompleted(bool result)
        {
            Log($"OnSetGameDataCompleted, result: { result }");
        }


        private void Log(string text)
        {
            _text.text += $"\n{text}";
            _scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}
using System;
using System.Collections.Generic;
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

        [SerializeField] private Button _shareButton;

        [SerializeField] private Button _inviteFriendsButton;

        [SerializeField] private Button _joinCommunityButton;

        [SerializeField] private Button _createPostButton;

        [SerializeField] private Button _addToHomeScreenButton;

        [SerializeField] private Button _addToFavoritesButton;

        [SerializeField] private Button _authorizePlayerButton;

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
                _shareButton.onClick.AddListener(OnShareButtonClicked);
                _inviteFriendsButton.onClick.AddListener(OnInviteFriendsButtonClicked);
                _joinCommunityButton.onClick.AddListener(OnJoinCommunityButtonClicked);
                _createPostButton.onClick.AddListener(OnCreatePostButtonClicked);
                _addToHomeScreenButton.onClick.AddListener(OnAddToHomeScreenButtonClicked);
                _addToFavoritesButton.onClick.AddListener(OnAddToFavoritesButtonClicked);
                _authorizePlayerButton.onClick.AddListener(OnAuthorizePlayerButtonClicked);

                InstantGamesBridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
                InstantGamesBridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;

                InstantGamesBridge.advertisement.SetMinimumDelayBetweenInterstitial(5);
                InstantGamesBridge.game.GetData(_coinsKey, OnGetGameDataCompleted);

                Log($"Platform ID: { InstantGamesBridge.platform.id }, language: { InstantGamesBridge.platform.language }, payload: { InstantGamesBridge.platform.payload }");

                Log($"Share supported: { InstantGamesBridge.social.isShareSupported }, " +
                    $"invite friends supported: { InstantGamesBridge.social.isInviteFriendsSupported }, " +
                    $"community supported: { InstantGamesBridge.social.isJoinCommunitySupported }, " +
                    $"create post supported: { InstantGamesBridge.social.isCreatePostSupported }, " +
                    $"add to home screen supported: { InstantGamesBridge.social.isAddToHomeScreenSupported }, " +
                    $"add to favorites supported: { InstantGamesBridge.social.isAddToFavoritesSupported }");

                Log($"Is authorization supported: { InstantGamesBridge.player.isAuthorizationSupported }, " +
                    $"is authorized: { InstantGamesBridge.player.isAuthorized }, " +
                    $"id: { InstantGamesBridge.player.id }, " +
                    $"player name: { InstantGamesBridge.player.name }");

                foreach (var playerPhoto in InstantGamesBridge.player.photos)
                    Log($"player photo url: { playerPhoto }");
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

        private void OnShareButtonClicked()
        {
            Log("Share");
            InstantGamesBridge.social.Share(OnShareCompleted);
        }

        private void OnInviteFriendsButtonClicked()
        {
            Log("Invite Friends");
            InstantGamesBridge.social.InviteFriends(OnInviteFriendsCompleted);
        }

        private void OnJoinCommunityButtonClicked()
        {
            Log("Join Community");
            InstantGamesBridge.social.JoinCommunity(OnJoinCommunityCompleted);
        }

        private void OnCreatePostButtonClicked()
        {
            Log("Create Post");
            InstantGamesBridge.social.CreatePost("Example text", OnCreatePostCompleted);
        }

        private void OnAddToHomeScreenButtonClicked()
        {
            Log("Add To Home Screen");
            InstantGamesBridge.social.AddToHomeScreen(OnAddToHomeScreenCompleted);
        }

        private void OnAddToFavoritesButtonClicked()
        {
            Log("Add To Favorites");
            InstantGamesBridge.social.AddToFavorites(OnAddToFavoritesCompleted);
        }

        private void OnAuthorizePlayerButtonClicked()
        {
            Log("Authorize Player");
            InstantGamesBridge.player.Authorize(OnAuthorizePlayerCompleted);
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

        private void OnShareCompleted(bool result)
        {
            Log($"OnShareCompleted, result: { result }");
        }

        private void OnInviteFriendsCompleted(bool result)
        {
            Log($"OnInviteFriendsCompleted, result: { result }");
        }

        private void OnJoinCommunityCompleted(bool result)
        {
            Log($"OnJoinCommunityCompleted, result: { result }");
        }

        private void OnCreatePostCompleted(bool result)
        {
            Log($"OnCreatePostCompleted, result: { result }");
        }

        private void OnAddToHomeScreenCompleted(bool result)
        {
            Log($"OnAddToHomeScreenCompleted, result: { result }");
        }

        private void OnAddToFavoritesCompleted(bool result)
        {
            Log($"OnAddToFavoritesCompleted, result: { result }");
        }

        private void OnAuthorizePlayerCompleted(bool result)
        {
            Log($"OnAuthorizePlayerCompleted, result: { result }");

            if (result)
            {
                Log($"is authorized: { InstantGamesBridge.player.isAuthorized }, " +
                    $"id: { InstantGamesBridge.player.id }, " +
                    $"player name: { InstantGamesBridge.player.name }");

                foreach (var playerPhoto in InstantGamesBridge.player.photos)
                    Log($"player photo url: { playerPhoto }");
            }
        }


        private void Log(string text)
        {
            _text.text += $"\n{text}";
            _scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}
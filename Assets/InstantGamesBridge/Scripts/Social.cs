#if UNITY_WEBGL
using System;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class Social : MonoBehaviour
    {
        public bool isShareSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsShareSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isInviteFriendsSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsInviteFriendsSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isJoinCommunitySupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsJoinCommunitySupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isCreatePostSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsCreatePostSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isAddToHomeScreenSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsAddToHomeScreenSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isAddToFavoritesSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsAddToFavoritesSupported() == "true";
#else
                return false;
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsShareSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsInviteFriendsSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsJoinCommunitySupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsCreatePostSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsAddToHomeScreenSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsAddToFavoritesSupported();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShare();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInviteFriends();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeJoinCommunity();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeCreatePost(string text);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeAddToHomeScreen();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeAddToFavorites();
#endif

        private Action<bool> _shareCallback;

        private Action<bool> _inviteFriendsCallback;

        private Action<bool> _joinCommunityCallback;

        private Action<bool> _createPostCallback;

        private Action<bool> _addToHomeScreenCallback;

        private Action<bool> _addToFavoritesCallback;


        public void Share(Action<bool> onComplete = null)
        {
            _shareCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeShare();
#else
            OnShareCompleted("false");
#endif
        }

        public void InviteFriends(Action<bool> onComplete = null)
        {
            _inviteFriendsCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeInviteFriends();
#else
            OnInviteFriendsCompleted("false");
#endif
        }

        public void JoinCommunity(Action<bool> onComplete = null)
        {
            _joinCommunityCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeJoinCommunity();
#else
            OnJoinCommunityCompleted("false");
#endif
        }

        public void CreatePost(string text, Action<bool> onComplete = null)
        {
            _createPostCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeCreatePost(text);
#else
            OnCreatePostCompleted("false");
#endif
        }

        public void AddToHomeScreen(Action<bool> onComplete = null)
        {
            _addToHomeScreenCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeAddToHomeScreen();
#else
            OnAddToHomeScreenCompleted("false");
#endif
        }

        public void AddToFavorites(Action<bool> onComplete = null)
        {
            _addToFavoritesCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeAddToFavorites();
#else
            OnAddToFavoritesCompleted("false");
#endif
        }


        // Called from JS
        private void OnShareCompleted(string result)
        {
            var isSuccess = result == "true";
            _shareCallback?.Invoke(isSuccess);
            _shareCallback = null;
        }

        private void OnInviteFriendsCompleted(string result)
        {
            var isSuccess = result == "true";
            _inviteFriendsCallback?.Invoke(isSuccess);
            _inviteFriendsCallback = null;
        }

        private void OnJoinCommunityCompleted(string result)
        {
            var isSuccess = result == "true";
            _joinCommunityCallback?.Invoke(isSuccess);
            _joinCommunityCallback = null;
        }

        private void OnCreatePostCompleted(string result)
        {
            var isSuccess = result == "true";
            _createPostCallback?.Invoke(isSuccess);
            _createPostCallback = null;
        }

        private void OnAddToHomeScreenCompleted(string result)
        {
            var isSuccess = result == "true";
            _addToHomeScreenCallback?.Invoke(isSuccess);
            _addToHomeScreenCallback = null;
        }

        private void OnAddToFavoritesCompleted(string result)
        {
            var isSuccess = result == "true";
            _addToFavoritesCallback?.Invoke(isSuccess);
            _addToFavoritesCallback = null;
        }
    }
}
#endif
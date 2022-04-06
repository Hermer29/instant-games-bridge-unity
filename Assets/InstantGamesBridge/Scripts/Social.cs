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

        public bool isCommunitySupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsCommunitySupported() == "true";
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
        private static extern string InstantGamesBridgeIsCommunitySupported();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShare();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInviteFriends();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeJoinCommunity();
#endif

        private Action<bool> _shareCallback;

        private Action<bool> _inviteFriendsCallback;

        private Action<bool> _joinCommunityCallback;


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
    }
}
#endif
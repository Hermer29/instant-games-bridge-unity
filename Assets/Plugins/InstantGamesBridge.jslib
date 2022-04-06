mergeInto(LibraryManager.library, {

    InstantGamesBridgeInitialize: function(settings) {
        window.initialize(Pointer_stringify(settings))
    },

    InstantGamesBridgeGetPlatformId: function() {
        var platformId = window.getPlatformId()
        var bufferSize = lengthBytesUTF8(platformId) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformId, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformLanguage: function() {
        var platformLanguage = window.getPlatformLanguage()
        var bufferSize = lengthBytesUTF8(platformLanguage) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformLanguage, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformPayload: function() {
        var platformPayload = window.getPlatformPayload()
        var bufferSize = lengthBytesUTF8(platformPayload) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformPayload, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeSetMinimumDelayBetweenInterstitial: function(seconds) {
        window.setMinimumDelayBetweenInterstitial(seconds)
    },

    InstantGamesBridgeShowInterstitial: function(ignoreDelay) {
        window.showInterstitial(ignoreDelay)
    },

    InstantGamesBridgeShowRewarded: function() {
        window.showRewarded()
    },

    InstantGamesBridgeGetGameData: function(key) {
        window.getGameData(Pointer_stringify(key))
    },

    InstantGamesBridgeSetGameData: function(key, value) {
        window.setGameData(Pointer_stringify(key), Pointer_stringify(value))
    },

    InstantGamesBridgeIsShareSupported: function() {
        var isShareSupported = window.getIsShareSupported()
        var bufferSize = lengthBytesUTF8(isShareSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isShareSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsInviteFriendsSupported: function() {
        var isInviteFriendsSupported = window.getIsInviteFriendsSupported()
        var bufferSize = lengthBytesUTF8(isInviteFriendsSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isInviteFriendsSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsCommunitySupported: function() {
        var isCommunitySupported = window.getIsCommunitySupported()
        var bufferSize = lengthBytesUTF8(isCommunitySupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isCommunitySupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeShare: function() {
        window.share()
    },

    InstantGamesBridgeInviteFriends: function() {
        window.inviteFriends()
    },

    InstantGamesBridgeJoinCommunity: function() {
        window.joinCommunity()
    }

});